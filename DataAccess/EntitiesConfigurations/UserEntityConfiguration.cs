using Contacts.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.DataAccess.EntitiesConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(userEntity => userEntity.Id);
        builder.ToTable("Users");
        builder.Property(userEntity => userEntity.Id).ValueGeneratedOnAdd();

        builder
            .HasMany<UserRoleEntity>()
            .WithOne(userRoleEntity => userRoleEntity.User)
            .HasForeignKey(userRoleEntity => userRoleEntity.UserId)
            .IsRequired();
    }
}
