using Contacts.Common.Core;

namespace Contacts.Common.Entities;

public class UserEntity : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string EncryptedPassword { get; set; }
    public int WorkPhoneNumber { get; set; }
    public int MobilePhoneNumber { get; set; }
    public List<UserRoleEntity> UsersRoles { get; set; }

    public UserEntity()
    {
        UsersRoles = new List<UserRoleEntity>();
    }
}
