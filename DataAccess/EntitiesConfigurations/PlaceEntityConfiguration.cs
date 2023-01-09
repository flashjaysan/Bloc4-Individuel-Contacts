using Contacts.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.DataAccess.EntitiesConfigurations;

public class PlaceEntityConfiguration : IEntityTypeConfiguration<PlaceEntity>
{
    public void Configure(EntityTypeBuilder<PlaceEntity> builder)
    {
        builder.HasKey(placeEntity => placeEntity.Id);
        builder.ToTable("Places");
    }
}
