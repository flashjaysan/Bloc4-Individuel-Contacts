using Contacts.Common;
using Contacts.Common.Entities;
using Contacts.DataAccess.DbContext;

namespace Contacts.DataAccess;

public class DbSeed
{
    public async Task SeedAsync(ContactsDbContext context)
    {
        using (context)
        {
            SeedRoleData<RoleEntity>(context);
            await context.SaveChangesAsync();
        }
    }

    public void SeedRoleData<T>(ContactsDbContext context) where T : Enumeration
    {
        List<T> newSeeds = Enumeration.GetAll<T>().ToList();

        List<T> existingData = context.Set<T>().ToList();

        foreach (T seed in newSeeds)
        {
            if (existingData.Any(x => x.Id == seed.Id))
            {
                existingData.FirstOrDefault(x => x.Id == seed.Id).Update(seed);
            }
            else
            {
                context.Set<T>().Add(seed);
            }
        }
        // we don't delete the existing one that aren't in the seedfile because of possible FK reference logical delete possible or if cascade
        // delete if we are sure about the datas lost
    }
}
