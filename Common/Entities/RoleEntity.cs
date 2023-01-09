namespace Contacts.Common.Entities;

public class RoleEntity : Enumeration
{
    public static RoleEntity Admin = new RoleEntity(1, "SuperAdmin");
    public static RoleEntity Employee = new RoleEntity(2, "Employee");
    public static RoleEntity Client = new RoleEntity(3, "Client");

    public RoleEntity(int id, string name)
      : base(id, name)
    {
    }

    public static IEnumerable<RoleEntity> List() => new[] { Admin, Employee, Client };

    public static RoleEntity FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new Exception($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static RoleEntity From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new Exception($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}
