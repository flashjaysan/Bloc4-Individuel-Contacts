using Contacts.Common.Core;

namespace Contacts.Common.Resources;

public class UserRoleResource : Resource
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public UserResource User { get; set; }
    public RoleResource Role { get; set; }
}
