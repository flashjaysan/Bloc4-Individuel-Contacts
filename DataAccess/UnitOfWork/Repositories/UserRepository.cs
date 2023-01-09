using Contacts.Common.Entities;
using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess.UnitOfWork.Repositories;

public class UserRepository : IRepository<UserEntity>
{
    private readonly ContactsDbContext _dbContext;

    public UserRepository(ContactsDbContext contactsDbContext)
    {
        _dbContext = contactsDbContext;
    }

    public void Add(UserEntity userEntity)
    {
        _dbContext.Users.Add(userEntity);
    }

    public List<UserEntity> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public UserEntity GetOne(int id)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Id == id);
    }

    public void Remove(UserEntity userEntity)
    {
        _dbContext.Users.Remove(userEntity);
    }

    public void Update(UserEntity userEntity)
    {
        _dbContext.Users.Update(userEntity);
    }
}
