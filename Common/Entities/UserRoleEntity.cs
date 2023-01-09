using Contacts.Common.Core;

namespace Contacts.Common.Entities;

public class UserRoleEntity : Entity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public UserEntity User { get; set; }
    public RoleEntity Role { get; set; }
}
