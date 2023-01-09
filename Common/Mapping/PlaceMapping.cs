using AutoMapper;
using Contacts.Common.Entities;
using Contacts.Common.Resources;

namespace Contacts.Common.Mappings;

public class PlaceMapping : Profile
{
    public PlaceMapping()
    {
        CreateMap<PlaceEntity, PlaceResource>();
        CreateMap<PlaceResource, PlaceEntity>();
    }
}
