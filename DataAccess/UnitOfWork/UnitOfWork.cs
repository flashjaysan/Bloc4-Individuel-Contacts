using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ContactsDbContext _dbContext;

    public UnitOfWork(ContactsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveIntoDbContextAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
