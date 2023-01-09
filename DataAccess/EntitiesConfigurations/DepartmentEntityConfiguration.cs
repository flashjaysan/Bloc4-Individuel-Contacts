using Contacts.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.DataAccess.EntitiesConfigurations;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
    {
        builder.HasKey(departmentEntity => departmentEntity.Id);
        builder.ToTable("Departments");
    }
}
