using Contacts.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Contacts.DataAccess.DbContextFactory;

public class ContactsDbContextFactory : IDesignTimeDbContextFactory<ContactsDbContext>
{
    readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();

    public ContactsDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ContactsDbContext> builder = new DbContextOptionsBuilder<ContactsDbContext>();
        builder.UseSqlServer(_configuration.GetConnectionString("ContactsDb"), builder => builder.MigrationsAssembly("Contacts.DataAccess"));
        return new ContactsDbContext(builder.Options);
    }
}
