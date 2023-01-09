using Contacts.Common.Entities;
using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess.UnitOfWork.Repositories;

public class UserRoleRepository : IRepository<UserRoleEntity>
{
    private readonly ContactsDbContext _dbContext;

    public UserRoleRepository(ContactsDbContext contactsDbContext)
    {
        _dbContext = contactsDbContext;
    }

    public void Add(UserRoleEntity userRoleEntity)
    {
        _dbContext.UsersRoles.Add(userRoleEntity);
    }

    public List<UserRoleEntity> GetAll()
    {
        return _dbContext.UsersRoles.ToList();
    }

    public UserRoleEntity GetOne(int id)
    {
        return _dbContext.UsersRoles.FirstOrDefault(userRole => userRole.Id == id);
    }

    public void Remove(UserRoleEntity userRoleEntity)
    {
        _dbContext.UsersRoles.Remove(userRoleEntity);
    }

    public void Update(UserRoleEntity userRoleEntity)
    {
        _dbContext.UsersRoles.Update(userRoleEntity);
    }
}
