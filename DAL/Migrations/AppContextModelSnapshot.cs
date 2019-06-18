﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date");

                    b.Property<string>("Notes");

                    b.Property<string>("PersonId");

                    b.Property<string>("School");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("DAL.Models.Have", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Haves");
                });

            modelBuilder.Entity("DAL.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("DAL.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonId");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("DAL.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("DAL.Models.Person", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DAL.Models.PersonHave", b =>
                {
                    b.Property<string>("PersonId");

                    b.Property<int>("HaveId");

                    b.HasKey("PersonId", "HaveId");

                    b.HasIndex("HaveId");

                    b.ToTable("PersonHaves");
                });

            modelBuilder.Entity("DAL.Models.PersonInterest", b =>
                {
                    b.Property<string>("PersonId");

                    b.Property<int>("InterestId");

                    b.HasKey("PersonId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("PersonInterests");
                });

            modelBuilder.Entity("DAL.Models.PersonLanguage", b =>
                {
                    b.Property<string>("PersonId");

                    b.Property<int>("LanguageId");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");
                });

            modelBuilder.Entity("DAL.Models.PersonWant", b =>
                {
                    b.Property<string>("PersonId");

                    b.Property<int>("WantId");

                    b.HasKey("PersonId", "WantId");

                    b.HasIndex("WantId");

                    b.ToTable("PersonWants");
                });

            modelBuilder.Entity("DAL.Models.Want", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Wants");
                });

            modelBuilder.Entity("DAL.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date");

                    b.Property<string>("PersonId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("DAL.Models.Education", b =>
                {
                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("Educations")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("DAL.Models.Job", b =>
                {
                    b.HasOne("DAL.Models.Person", "Person")
                        .WithOne("CurrentJob")
                        .HasForeignKey("DAL.Models.Job", "PersonId");
                });

            modelBuilder.Entity("DAL.Models.PersonHave", b =>
                {
                    b.HasOne("DAL.Models.Have", "Have")
                        .WithMany("PersonHaves")
                        .HasForeignKey("HaveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("PersonHaves")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.PersonInterest", b =>
                {
                    b.HasOne("DAL.Models.Interest", "Interest")
                        .WithMany("PersonInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("PersonInterests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.PersonLanguage", b =>
                {
                    b.HasOne("DAL.Models.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.PersonWant", b =>
                {
                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("PersonWants")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Want", "Want")
                        .WithMany("PersonWants")
                        .HasForeignKey("WantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Work", b =>
                {
                    b.HasOne("DAL.Models.Person", "Person")
                        .WithMany("Works")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
