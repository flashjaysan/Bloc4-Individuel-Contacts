using AutoMapper;
using Contacts.Business;
using Contacts.Common.Entities;
using Contacts.Common.Resources;
using Contacts.DataAccess.UnitOfWork;
using Contacts.DataAccess.UnitOfWork.Repositories;

namespace Contacts.Service;

public class PlaceService : IService<PlaceResource>
{
    private readonly IRepository<PlaceEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PlaceService(IRepository<PlaceEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PlaceResource> Add(PlaceResource placeResource)
    {
        PlaceEntity newPlace = _mapper.Map<PlaceEntity>(placeResource);
        _repository.Add(newPlace);
        await _unitOfWork.SaveIntoDbContextAsync();
        return placeResource;
    }

    public async Task Delete(int id)
    {
        PlaceEntity placeEntity = _repository.GetOne(id);
        
        if (placeEntity != null)
        {
            _repository.Remove(placeEntity);
        }

        await _unitOfWork.SaveIntoDbContextAsync();
    }

    public Task<List<PlaceResource>> GetAll()
    {
        List<PlaceEntity> placeEntities = _repository.GetAll();
        List<PlaceResource> placeResources = _mapper.Map<List<PlaceResource>>(placeEntities);
        return Task.FromResult(placeResources);
    }

    public Task<PlaceResource> GetItemById(int id)
    {
        PlaceEntity placeEntity = _repository.GetOne(id);
        PlaceResource placeResource = _mapper.Map<PlaceEntity, PlaceResource>(placeEntity);
        return Task.FromResult(placeResource);
    }

    public async Task<PlaceResource> Update(PlaceResource placeResource)
    {
        PlaceEntity placeEntity = _repository.GetOne(placeResource.Id);

        if (placeEntity == null)
        {
            throw new Exception("Place doesn't exist.");
        }

        PlaceEntity updatedPlaceEntity = _mapper.Map(placeResource, placeEntity);
        _repository.Update(updatedPlaceEntity);
        await _unitOfWork.SaveIntoDbContextAsync();
        PlaceResource updatedPlaceResource = _mapper.Map<PlaceEntity, PlaceResource>(updatedPlaceEntity);
        return updatedPlaceResource;
    }
}
