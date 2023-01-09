using AutoMapper;
using Contacts.Business;
using Contacts.Common.Entities;
using Contacts.Common.Resources;
using Contacts.DataAccess.UnitOfWork.Repositories;
using Contacts.DataAccess.UnitOfWork;

namespace Contacts.Service;

public class UserService : IService<UserResource>
{
    private readonly IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IRepository<UserEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserResource> Add(UserResource userResource)
    {
        UserEntity newUser = _mapper.Map<UserEntity>(userResource);
        _repository.Add(newUser);
        await _unitOfWork.SaveIntoDbContextAsync();
        return userResource;
    }

    public async Task Delete(int id)
    {
        UserEntity userEntity = _repository.GetOne(id);

        if (userEntity != null)
        {
            _repository.Remove(userEntity);
        }

        await _unitOfWork.SaveIntoDbContextAsync();
    }

    public Task<List<UserResource>> GetAll()
    {
        List<UserEntity> userEntities = _repository.GetAll();
        List<UserResource> userResources = _mapper.Map<List<UserResource>>(userEntities);
        return Task.FromResult(userResources);
    }

    public Task<UserResource> GetItemById(int id)
    {
        UserEntity userEntity = _repository.GetOne(id);
        UserResource userResource = _mapper.Map<UserEntity, UserResource>(userEntity);
        return Task.FromResult(userResource);
    }

    public async Task<UserResource> Update(UserResource userResource)
    {
        UserEntity userEntity = _repository.GetOne(userResource.Id);

        if (userEntity == null)
        {
            throw new Exception("User doesn't exist.");
        }

        UserEntity updatedUserEntity = _mapper.Map(userResource, userEntity);
        _repository.Update(updatedUserEntity);
        await _unitOfWork.SaveIntoDbContextAsync();
        UserResource updatedUserResource = _mapper.Map<UserEntity, UserResource>(updatedUserEntity);
        return updatedUserResource;
    }
}
