namespace Contacts.DataAccess.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveIntoDbContextAsync();
}
