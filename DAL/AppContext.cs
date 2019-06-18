using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public sealed class AppContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Want> Wants { get; set; }
        public DbSet<Have> Haves { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Work> Works { get; set; }

        public DbSet<PersonHave> PersonHaves { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<PersonWant> PersonWants { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9K6B7B5\SQLEXPRESS;Initial Catalog=parserdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1t1
            modelBuilder.Entity<Person>()
                .HasOne(i => i.CurrentJob)
                .WithOne(i => i.Person)
                .HasForeignKey<Job>(i => i.PersonId);

            // 1t*
            modelBuilder.Entity<Person>()
                .HasMany(i => i.Educations)
                .WithOne(i => i.Person)
                .HasForeignKey(i => i.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(i => i.Works)
                .WithOne(i => i.Person)
                .HasForeignKey(i => i.PersonId);

            // *t*
            modelBuilder.Entity<PersonLanguage>()
                .HasKey(bc => new { bc.PersonId, bc.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(bc => bc.Person)
                .WithMany(b => b.PersonLanguages)
                .HasForeignKey(bc => bc.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(bc => bc.Language)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(bc => bc.LanguageId);


            modelBuilder.Entity<PersonHave>()
                .HasKey(bc => new { bc.PersonId, bc.HaveId });

            modelBuilder.Entity<PersonHave>()
                .HasOne(bc => bc.Person)
                .WithMany(b => b.PersonHaves)
                .HasForeignKey(bc => bc.PersonId);

            modelBuilder.Entity<PersonHave>()
                .HasOne(bc => bc.Have)
                .WithMany(c => c.PersonHaves)
                .HasForeignKey(bc => bc.HaveId);


            modelBuilder.Entity<PersonInterest>()
                .HasKey(bc => new { bc.PersonId, bc.InterestId });

            modelBuilder.Entity<PersonInterest>()
                .HasOne(bc => bc.Person)
                .WithMany(b => b.PersonInterests)
                .HasForeignKey(bc => bc.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(bc => bc.Interest)
                .WithMany(c => c.PersonInterests)
                .HasForeignKey(bc => bc.InterestId);


            modelBuilder.Entity<PersonWant>()
                .HasKey(bc => new { bc.PersonId, bc.WantId });

            modelBuilder.Entity<PersonWant>()
                .HasOne(bc => bc.Person)
                .WithMany(b => b.PersonWants)
                .HasForeignKey(bc => bc.PersonId);

            modelBuilder.Entity<PersonWant>()
                .HasOne(bc => bc.Want)
                .WithMany(c => c.PersonWants)
                .HasForeignKey(bc => bc.WantId);
        }
    }
}
