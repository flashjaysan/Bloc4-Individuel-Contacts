using Contacts.Common.Entities;
using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess.UnitOfWork.Repositories;

public class PlaceRepository : IRepository<PlaceEntity>
{
    private readonly ContactsDbContext _dbContext;

    public PlaceRepository(ContactsDbContext contactsDbContext)
    {
        _dbContext = contactsDbContext;
    }

    public void Add(PlaceEntity placeEntity)
    {
        _dbContext.Places.Add(placeEntity);
    }

    public List<PlaceEntity> GetAll()
    {
        return _dbContext.Places.ToList();
    }

    public PlaceEntity GetOne(int id)
    {
        return _dbContext.Places.FirstOrDefault(place => place.Id == id);
    }

    public void Remove(PlaceEntity placeEntity)
    {
        _dbContext.Places.Remove(placeEntity);
    }

    public void Update(PlaceEntity placeEntity)
    {
        _dbContext.Places.Update(placeEntity);
    }
}
