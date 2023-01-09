namespace Contacts.Common.Resources;

public class RoleResource : Enumeration
{
    public static RoleResource Admin = new RoleResource(1, "SuperAdmin");
    public static RoleResource Employee = new RoleResource(2, "Employee");
    public static RoleResource Client = new RoleResource(3, "Client");

    public RoleResource(int id, string name)
      : base(id, name)
    {
    }

    public static IEnumerable<RoleResource> List() => new[] { Admin, Employee, Client };

    public static RoleResource FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new Exception($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static RoleResource From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new Exception($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}
