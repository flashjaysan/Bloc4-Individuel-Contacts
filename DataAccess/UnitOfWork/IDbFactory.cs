using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess.UnitOfWork;

public interface IDbFactory
{
    ContactsDbContext ContactsDbContext { get; }
}
