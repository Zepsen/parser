using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PersonRepo
    {
        public async Task UpsertProfile(ProfileModel profile)
        {
            using (var db = new AppContext())
            {
                await UpsertPerson(db, profile);
            }
        }

        /// <summary>
        /// Update or insert profile
        /// </summary>
        /// <param name="db"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        private async Task UpsertPerson(AppContext db, ProfileModel profile)
        {
            var entity = await db.Persons.FindAsync(profile.Id);
            var person = new Person()
            {
                Id = profile.Id,
                Link = profile.Link,
                Name = profile.Name,
                Photo = profile.Photo
            };

            if (entity != null)
            {
                db.Persons.Update(person);
            }
            else
            {
                await db.Persons.AddAsync(person);
            }


            await db.SaveChangesAsync();
        }

        private async Task UpdateInterests(AppContext db, ProfileModel model)
        {
            var interests = await db.Interests.AsNoTracking()
                .Where(i => model.Interests.Contains(i.Title)).ToListAsync();

            var newIntrsts = interests.Select(i => i.Title).Except(model.Interests).Select(i => new Interest { Title = i });
            await db.Interests.AddRangeAsync(newIntrsts);
            await db.SaveChangesAsync();

            var ids = await db.Interests.AsNoTracking()
                .Where(i => model.Interests.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personInterests = await db.PersonInterests.Where(i => i.PersonId == model.Id).ToListAsync();
            db.PersonInterests.RemoveRange(personInterests);
            await db.PersonInterests.AddRangeAsync(ids.Select(i => new PersonInterest()
                {InterestId = i, PersonId = model.Id}));

            await db.SaveChangesAsync();
        }

        private async Task UpdateWants(AppContext db, ProfileModel model)
        {
            var wants = await db.Wants.AsNoTracking()
                .Where(i => model.Wants.Contains(i.Title)).ToListAsync();

            var newWants = wants.Select(i => i.Title).Except(model.Wants).Select(i => new Want { Title = i });
            await db.Wants.AddRangeAsync(newWants);
            await db.SaveChangesAsync();

            var ids = await db.Wants.AsNoTracking()
                .Where(i => model.Wants.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personWants = await db.PersonWants.Where(i => i.PersonId == model.Id).ToListAsync();
            db.PersonWants.RemoveRange(personWants);
            await db.PersonWants.AddRangeAsync(ids.Select(i => new PersonWant()
                { WantId = i, PersonId = model.Id }));

            await db.SaveChangesAsync();
        }

        private async Task UpdateHaves(AppContext db, ProfileModel model)
        {
            var haves = await db.Haves.AsNoTracking()
                .Where(i => model.Haves.Contains(i.Title)).ToListAsync();

            var newHaves = haves.Select(i => i.Title).Except(model.Haves).Select(i => new Have { Title = i });
            await db.Haves.AddRangeAsync(newHaves);
            await db.SaveChangesAsync();

            var ids = await db.Haves.AsNoTracking()
                .Where(i => model.Haves.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personHaves = await db.PersonHaves.Where(i => i.PersonId == model.Id).ToListAsync();
            db.PersonHaves.RemoveRange(personHaves);
            await db.PersonHaves.AddRangeAsync(ids.Select(i => new PersonHave()
                { HaveId = i, PersonId = model.Id }));

            await db.SaveChangesAsync();
        }

        private async Task UpdateLanguages(AppContext db, ProfileModel model)
        {
            var languages = await db.Languages.AsNoTracking()
                .Where(i => model.Languages.Contains(i.Title)).ToListAsync();

            var newIntrsts = languages.Select(i => i.Title).Except(model.Languages).Select(i => new Language { Title = i });
            await db.Languages.AddRangeAsync(newIntrsts);
            await db.SaveChangesAsync();

            var ids = await db.Languages.AsNoTracking()
                .Where(i => model.Languages.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personLanguages = await db.PersonLanguages.Where(i => i.PersonId == model.Id).ToListAsync();
            db.PersonLanguages.RemoveRange(personLanguages);
            await db.PersonLanguages.AddRangeAsync(ids.Select(i => new PersonLanguage()
                { LanguageId = i, PersonId = model.Id }));

            await db.SaveChangesAsync();
        }
    }

}
