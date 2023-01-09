using AutoMapper;
using Contacts.Common.Entities;
using Contacts.Common.Resources;

namespace Contacts.Common.Mappings;

public class DepartmentMapping : Profile
{
    public DepartmentMapping()
    {
        CreateMap<DepartmentEntity, DepartmentResource>();
        CreateMap<DepartmentResource, DepartmentEntity>();
    }
}
