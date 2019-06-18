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

                await UpdateJob(db, profile);

                await UpdateEducationExp(db, profile);
                await UpdateWorkExp(db, profile);

                await UpdateHaves(db, profile);
                await UpdateInterests(db, profile);
                await UpdateLanguages(db, profile);
                await UpdateWants(db, profile);
            }
        }

        private async Task UpdateJob(AppContext db, ProfileModel model)
        {
            if (model.CurrentJob != null)
            {
                var job = await db.Jobs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.PersonId == model.Id);

                if (job != null)
                {
                    job.Title = model.CurrentJob.Title;
                    job.Status = model.CurrentJob.Status;

                    db.Jobs.Update(job);
                }
                else
                {
                    var newJob = new Job
                    {
                        Title = model.CurrentJob.Title,
                        Status = model.CurrentJob.Status,
                    };

                    await db.Jobs.AddAsync(newJob);
                }

                await db.SaveChangesAsync(); 
            }
        }

        private async Task UpdateWorkExp(AppContext db, ProfileModel model)
        {
            if (model.Works.Any())
            {
                var works = await db.Works.AsNoTracking()
                    .Where(i => i.PersonId == model.Id).ToListAsync();
                
                if(works.Any()) db.Works.RemoveRange(works);
                await db.Works.AddRangeAsync(model.Works.Select(w => new Models.Work
                {
                    Title = w.Title,
                    Date = w.Date,
                    PersonId = model.Id,
                }));

                await db.SaveChangesAsync();
            }
        }

        private async Task UpdateEducationExp(AppContext db, ProfileModel model)
        {
            if (model.Educations.Any())
            {
                var edu = await db.Educations.AsNoTracking()
                    .Where(i => i.PersonId == model.Id).ToListAsync();

                if (edu.Any()) db.Educations.RemoveRange(edu);
                await db.Educations.AddRangeAsync(model.Educations.Select(w => new Models.Education
                {
                    School = w.School,
                    Date = w.Date,
                    Notes = w.Notes,
                    PersonId = model.Id,
                }));

                await db.SaveChangesAsync();
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

            if (entity != null)
            {
                UpdatePerson(db, profile, entity);
            }
            else
            {
                await InsertNewPerson(db, profile);
            }


            await db.SaveChangesAsync();
        }

        private static async Task InsertNewPerson(AppContext db, ProfileModel profile)
        {
            var person = new Person
            {
                Id = profile.Id,
                Link = profile.Link,
                Name = profile.Name,
                Photo = profile.Photo
            };

            await db.Persons.AddAsync(person);
        }

        private static void UpdatePerson(AppContext db, ProfileModel profile, Person entity)
        {
            entity.Link = profile.Link;
            entity.Name = profile.Name;
            entity.Photo = profile.Photo;

            db.Persons.Update(entity);
        }

        private async Task UpdateInterests(AppContext db, ProfileModel model)
        {
            var interests = await db.Interests.AsNoTracking()
                .Where(i => model.Interests.Contains(i.Title)).ToListAsync();

            if (model.Interests.Any())
            {
                await InsertNewInterests(db, model, interests);
                await UpdatePersonInterests(db, model);
            }
        }

        private static async Task UpdatePersonInterests(AppContext db, ProfileModel model)
        {
            var ids = await db.Interests.AsNoTracking()
                .Where(i => model.Interests.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personInterests = await db.PersonInterests.Where(i => i.PersonId == model.Id).ToListAsync();
            //db.PersonInterests.RemoveRange(personInterests);
            ids = ids.Except(personInterests.Select(i => i.InterestId)).ToList();
            if (ids.Any())
            {
                await db.PersonInterests.AddRangeAsync(ids.Select(i => new PersonInterest()
                { InterestId = i, PersonId = model.Id }));

                await db.SaveChangesAsync();
            }
        }

        private static async Task InsertNewInterests(AppContext db, ProfileModel model, List<Interest> interests)
        {
            var newIntrsts = model.Interests.Except(interests.Select(i => i.Title)).Select(i => new Interest { Title = i }).ToList();
            if (newIntrsts.Any())
            {
                await db.Interests.AddRangeAsync(newIntrsts);
                await db.SaveChangesAsync();
            }
        }

        private async Task UpdateWants(AppContext db, ProfileModel model)
        {
            var wants = await db.Wants.AsNoTracking()
                .Where(i => model.Wants.Contains(i.Title)).ToListAsync();

            if (model.Wants.Any())
            {
                await InsertNewWants(db, model, wants);
                await UpdatePersonWants(db, model);
            }
        }

        private static async Task UpdatePersonWants(AppContext db, ProfileModel model)
        {
            var ids = await db.Wants.AsNoTracking()
                .Where(i => model.Wants.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personWants = await db.PersonWants.Where(i => i.PersonId == model.Id).ToListAsync();
            //db.PersonWants.RemoveRange(personWants);
            ids = ids.Except(personWants.Select(i => i.WantId)).ToList();
            if (ids.Any())
            {
                await db.PersonWants.AddRangeAsync(ids.Select(i => new PersonWant()
                { WantId = i, PersonId = model.Id }));

                await db.SaveChangesAsync();
            }
        }

        private static async Task InsertNewWants(AppContext db, ProfileModel model, List<Want> wants)
        {
            var newWants = model.Wants.Except(wants.Select(i => i.Title)).Select(i => new Want { Title = i }).ToList();
            if (newWants.Any())
            {
                await db.Wants.AddRangeAsync(newWants);
                await db.SaveChangesAsync();
            }
        }

        private async Task UpdateHaves(AppContext db, ProfileModel model)
        {
            var haves = await db.Haves.AsNoTracking()
                .Where(i => model.Haves.Contains(i.Title)).ToListAsync();

            if (model.Haves.Any())
            {
                await InsertNewHaves(db, model, haves);
                await UpdatePersonH(db, model);
            }
        }

        private static async Task UpdatePersonH(AppContext db, ProfileModel model)
        {
            var ids = await db.Haves.AsNoTracking()
                .Where(i => model.Haves.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personHaves = await db.PersonHaves.Where(i => i.PersonId == model.Id).ToListAsync();
            //db.PersonHaves.RemoveRange(personHaves);
            ids = ids.Except(personHaves.Select(i => i.HaveId)).ToList();
            if (ids.Any())
            {
                await db.PersonHaves.AddRangeAsync(ids.Select(i => new PersonHave()
                { HaveId = i, PersonId = model.Id }));

                await db.SaveChangesAsync();
            }
        }

        private static async Task InsertNewHaves(AppContext db, ProfileModel model, List<Have> haves)
        {
            var newHaves = model.Haves.Except(haves.Select(i => i.Title)).Select(i => new Have { Title = i }).ToList();
            if (newHaves.Any())
            {
                await db.Haves.AddRangeAsync(newHaves);
                await db.SaveChangesAsync();
            }
        }

        private async Task UpdateLanguages(AppContext db, ProfileModel model)
        {
            var languages = await db.Languages.AsNoTracking()
                .Where(i => model.Languages.Contains(i.Title)).ToListAsync();

            if (model.Languages.Any())
            {
                await InsertNewLangs(db, model, languages);
                await UpdatePersonLanguages(db, model);
            }
        }

        private static async Task UpdatePersonLanguages(AppContext db, ProfileModel model)
        {
            var ids = await db.Languages.AsNoTracking()
                .Where(i => model.Languages.Contains(i.Title)).Select(i => i.Id).ToListAsync();

            var personLanguages = await db.PersonLanguages.Where(i => i.PersonId == model.Id).ToListAsync();
            //db.PersonLanguages.RemoveRange(personLanguages);
            ids = ids.Except(personLanguages.Select(i => i.LanguageId)).ToList();
            if (ids.Any())
            {
                await db.PersonLanguages.AddRangeAsync(ids.Select(i => new PersonLanguage
                { LanguageId = i, PersonId = model.Id }));

                await db.SaveChangesAsync();
            }
        }

        private static async Task InsertNewLangs(AppContext db, ProfileModel model, List<Language> languages)
        {
            var newLangs = model.Languages.Except(languages.Select(i => i.Title))
                .Select(i => new Language { Title = i }).ToList();

            if (newLangs.Any())
            {
                await db.Languages.AddRangeAsync(newLangs);
                await db.SaveChangesAsync();
            }
        }
    }

}
