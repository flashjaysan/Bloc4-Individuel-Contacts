using Contacts.Common.Entities;
using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess.UnitOfWork.Repositories;

public class DepartmentRepository : IRepository<DepartmentEntity>
{
    private readonly ContactsDbContext _dbContext;

    public DepartmentRepository(ContactsDbContext contactsDbContext)
    {
        _dbContext = contactsDbContext;
    }

    public void Add(DepartmentEntity departmentEntity)
    {
        _dbContext.Departments.Add(departmentEntity);
    }

    public List<DepartmentEntity> GetAll()
    {
        return _dbContext.Departments.ToList();
    }

    public DepartmentEntity GetOne(int id)
    {
        return _dbContext.Departments.FirstOrDefault(department => department.Id == id);
    }

    public void Remove(DepartmentEntity departmentEntity)
    {
        _dbContext.Departments.Remove(departmentEntity);
    }

    public void Update(DepartmentEntity departmentEntity)
    {
        _dbContext.Departments.Update(departmentEntity);
    }
}
