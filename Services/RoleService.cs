using AutoMapper;
using Contacts.Business;
using Contacts.Common.Entities;
using Contacts.Common.Resources;
using Contacts.DataAccess.UnitOfWork;
using Contacts.DataAccess.UnitOfWork.Repositories;

namespace Contacts.Service;

public class RoleService : IService<RoleResource>
{
    private readonly IRepository<RoleEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IRepository<RoleEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<RoleResource> Add(RoleResource roleResource)
    {
        RoleEntity newRole = _mapper.Map<RoleEntity>(roleResource);
        _repository.Add(newRole);
        await _unitOfWork.SaveIntoDbContextAsync();
        return roleResource;
    }

    public async Task Delete(int id)
    {
        RoleEntity roleEntity = _repository.GetOne(id);
        
        if (roleEntity != null)
        {
            _repository.Remove(roleEntity);
        }

        await _unitOfWork.SaveIntoDbContextAsync();
    }

    public Task<List<RoleResource>> GetAll()
    {
        List<RoleEntity> roleEntities = _repository.GetAll();
        List<RoleResource> roleResources = _mapper.Map<List<RoleResource>>(roleEntities);
        return Task.FromResult(roleResources);
    }

    public Task<RoleResource> GetItemById(int id)
    {
        RoleEntity roleEntity = _repository.GetOne(id);
        RoleResource roleResource = _mapper.Map<RoleEntity, RoleResource>(roleEntity);
        return Task.FromResult(roleResource);
    }

    public async Task<RoleResource> Update(RoleResource roleResource)
    {
        RoleEntity roleEntity = _repository.GetOne(roleResource.Id);

        if (roleEntity == null)
        {
            throw new Exception("Role doesn't exist.");
        }

        RoleEntity updatedRoleEntity = _mapper.Map(roleResource, roleEntity);
        _repository.Update(updatedRoleEntity);
        await _unitOfWork.SaveIntoDbContextAsync();
        RoleResource updatedRoleResource = _mapper.Map<RoleEntity, RoleResource>(updatedRoleEntity);
        return updatedRoleResource;
    }
}
