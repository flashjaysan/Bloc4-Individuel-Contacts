using Contacts.Common.Core;

namespace Contacts.Common.Resources;

public class UserResource : Resource
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string EncryptedPassword { get; set; }
    public int WorkPhoneNumber { get; set; }
    public int MobilePhoneNumber { get; set; }
    public List<UserRoleResource> UsersRoles { get; set; }
    public PlaceResource Place { get; set; }
    public DepartmentResource Department { get; set; }

    public UserResource()
    {
        UsersRoles = new List<UserRoleResource>();
    }
}
