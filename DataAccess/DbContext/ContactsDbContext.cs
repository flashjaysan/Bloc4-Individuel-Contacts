using Contacts.DataAccess.EntitiesConfigurations;
using Contacts.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DataAccess.DbContext;

public class ContactsDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRoleEntity> UsersRoles { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<PlaceEntity> Places { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }

    public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
    }
}
