using System.Threading.Tasks;
using DAL.Models;
using AppContext = DAL.AppContext;

namespace _1.BLL
{
    public class ProfileRepo
    {

        public async Task UpsertPerson(Person person)
        {
            using (var db = new AppContext())
            {
                var entity = await db.Persons.FindAsync(person.Id);
                if (entity != null)
                {
                    entity.Link = person.Link;
                    db.Persons.Update(entity);
                }
                else
                {
                    await db.Persons.AddAsync(person);
                }


                await db.SaveChangesAsync();
            }
        }
    }
}
