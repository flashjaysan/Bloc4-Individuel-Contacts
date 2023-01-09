using AutoMapper;
using Contacts.Business;
using Contacts.Common.Entities;
using Contacts.Common.Resources;
using Contacts.DataAccess.UnitOfWork.Repositories;
using Contacts.DataAccess.UnitOfWork;

namespace Contacts.Service;

public class UserRoleService : IService<UserRoleResource>
{
    private readonly IRepository<UserRoleEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleService(IRepository<UserRoleEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserRoleResource> Add(UserRoleResource UserRoleResource)
    {
        UserRoleEntity newUserRole = _mapper.Map<UserRoleEntity>(UserRoleResource);
        _repository.Add(newUserRole);
        await _unitOfWork.SaveIntoDbContextAsync();
        return UserRoleResource;
    }

    public async Task Delete(int id)
    {
        UserRoleEntity UserRoleEntity = _repository.GetOne(id);

        if (UserRoleEntity != null)
        {
            _repository.Remove(UserRoleEntity);
        }

        await _unitOfWork.SaveIntoDbContextAsync();
    }

    public Task<List<UserRoleResource>> GetAll()
    {
        List<UserRoleEntity> UserRoleEntities = _repository.GetAll();
        List<UserRoleResource> UserRoleResources = _mapper.Map<List<UserRoleResource>>(UserRoleEntities);
        return Task.FromResult(UserRoleResources);
    }

    public Task<UserRoleResource> GetItemById(int id)
    {
        UserRoleEntity UserRoleEntity = _repository.GetOne(id);
        UserRoleResource UserRoleResource = _mapper.Map<UserRoleEntity, UserRoleResource>(UserRoleEntity);
        return Task.FromResult(UserRoleResource);
    }

    public async Task<UserRoleResource> Update(UserRoleResource UserRoleResource)
    {
        UserRoleEntity UserRoleEntity = _repository.GetOne(UserRoleResource.Id);

        if (UserRoleEntity == null)
        {
            throw new Exception("UserRole doesn't exist.");
        }

        UserRoleEntity updatedUserRoleEntity = _mapper.Map(UserRoleResource, UserRoleEntity);
        _repository.Update(updatedUserRoleEntity);
        await _unitOfWork.SaveIntoDbContextAsync();
        UserRoleResource updatedUserRoleResource = _mapper.Map<UserRoleEntity, UserRoleResource>(updatedUserRoleEntity);
        return updatedUserRoleResource;
    }
}
