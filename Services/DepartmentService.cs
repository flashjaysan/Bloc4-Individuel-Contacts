using AutoMapper;
using Contacts.Business;
using Contacts.Common.Entities;
using Contacts.Common.Resources;
using Contacts.DataAccess.UnitOfWork;
using Contacts.DataAccess.UnitOfWork.Repositories;

namespace Contacts.Service;

public class DepartmentService : IService<DepartmentResource>
{
    private readonly IRepository<DepartmentEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IRepository<DepartmentEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DepartmentResource> Add(DepartmentResource departmentResource)
    {
        DepartmentEntity newDepartment = _mapper.Map<DepartmentEntity>(departmentResource);
        _repository.Add(newDepartment);
        await _unitOfWork.SaveIntoDbContextAsync();
        return departmentResource;
    }

    public async Task Delete(int id)
    {
        DepartmentEntity departmentEntity = _repository.GetOne(id);
        
        if (departmentEntity != null)
        {
            _repository.Remove(departmentEntity);
        }

        await _unitOfWork.SaveIntoDbContextAsync();
    }

    public Task<List<DepartmentResource>> GetAll()
    {
        List<DepartmentEntity> departmentEntities = _repository.GetAll();
        List<DepartmentResource> departmentResources = _mapper.Map<List<DepartmentResource>>(departmentEntities);
        return Task.FromResult(departmentResources);
    }

    public Task<DepartmentResource> GetItemById(int id)
    {
        DepartmentEntity departmentEntity = _repository.GetOne(id);
        DepartmentResource departmentResource = _mapper.Map<DepartmentEntity, DepartmentResource>(departmentEntity);
        return Task.FromResult(departmentResource);
    }

    public async Task<DepartmentResource> Update(DepartmentResource departmentResource)
    {
        DepartmentEntity departmentEntity = _repository.GetOne(departmentResource.Id);

        if (departmentEntity == null)
        {
            throw new Exception("Department doesn't exist.");
        }

        DepartmentEntity updatedDepartmentEntity = _mapper.Map(departmentResource, departmentEntity);
        _repository.Update(updatedDepartmentEntity);
        await _unitOfWork.SaveIntoDbContextAsync();
        DepartmentResource updatedDepartmentResource = _mapper.Map<DepartmentEntity, DepartmentResource>(updatedDepartmentEntity);
        return updatedDepartmentResource;
    }
}
