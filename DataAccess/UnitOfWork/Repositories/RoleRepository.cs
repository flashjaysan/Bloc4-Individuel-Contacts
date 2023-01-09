using Contacts.Common.Entities;
using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess.UnitOfWork.Repositories;

public class RoleRepository : IRepository<RoleEntity>
{
    private readonly ContactsDbContext _dbContext;

    public RoleRepository(ContactsDbContext contactsDbContext)
    {
        _dbContext = contactsDbContext;
    }

    public void Add(RoleEntity roleEntity)
    {
        _dbContext.Roles.Add(roleEntity);
    }

    public List<RoleEntity> GetAll()
    {
        return _dbContext.Roles.ToList();
    }

    public RoleEntity GetOne(int id)
    {
        return _dbContext.Roles.FirstOrDefault(role => role.Id == id);
    }

    public void Remove(RoleEntity roleEntity)
    {
        _dbContext.Roles.Remove(roleEntity);
    }

    public void Update(RoleEntity roleEntity)
    {
        _dbContext.Roles.Update(roleEntity);
    }
}
