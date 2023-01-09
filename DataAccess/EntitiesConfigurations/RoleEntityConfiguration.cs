using Contacts.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.DataAccess.EntitiesConfigurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(roleEntity => roleEntity.Id);
        builder.ToTable("Roles");
        builder.Property(roleEntity => roleEntity.Id).ValueGeneratedNever();
        
        builder
            .HasMany<UserRoleEntity>()
            .WithOne(userRoleEntity => userRoleEntity.Role)
            .HasForeignKey(UserRoleEntity => UserRoleEntity.RoleId)
            .IsRequired();
    }
}
