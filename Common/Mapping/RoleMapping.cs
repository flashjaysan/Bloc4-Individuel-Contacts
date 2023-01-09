using AutoMapper;
using Contacts.Common.Entities;
using Contacts.Common.Resources;

namespace Contacts.Common.Mappings;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<RoleEntity, RoleResource>();
        CreateMap<RoleResource, RoleEntity>();
    }
}
