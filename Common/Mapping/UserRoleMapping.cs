using AutoMapper;
using Contacts.Common.Entities;
using Contacts.Common.Resources;

namespace Contacts.Common.Mappings;

public class UserRoleMapping : Profile
{
    public UserRoleMapping()
    {
        CreateMap<UserRoleEntity, UserRoleResource>();
        CreateMap<UserRoleResource, UserRoleEntity>();
    }
}
