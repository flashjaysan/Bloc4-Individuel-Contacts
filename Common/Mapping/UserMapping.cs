using AutoMapper;
using Contacts.Common.Entities;
using Contacts.Common.Resources;

namespace Contacts.Common.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserEntity, UserResource>();
        CreateMap<UserResource, UserEntity>();
    }
}
