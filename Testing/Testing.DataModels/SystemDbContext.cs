using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.DataModels
{
 public class SystemDbContext: DbContext
    {
        public SystemDbContext(DbContextOptions options)
            : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Student
            modelBuilder
                .Entity<Student>()
                .ToTable("Students")
                .HasKey(s => s.StudentNumber);

            modelBuilder
               .Entity<Student>()
               .Property(p => p.FullName)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder
               .Entity<Student>()
               .Property(p => p.EmailAddress)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder
               .Entity<Student>()
               .Property(p => p.PhoneNumber)
               .HasMaxLength(12)
               .IsRequired();

            //Subject
            modelBuilder
                .Entity<Subject>()
                .ToTable("Subjects")
                .HasKey(s => s.Name);

            //relations
            modelBuilder
                .Entity<Subject>()
                .HasOne(s => s.Student1)
                .WithMany(s => s.Subjects)
                .HasForeignKey(s => s.StudentId);


            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Student>()
                .HasData(
                new Student()
                {
                    StudentNumber = 1,
                    FullName = "Viktorija Jovanovska",
                    EmailAddress = "viktorijajovanovska@gmail.com",
                    PhoneNumber = "+38970123456"

                });


            modelBuilder
                .Entity<Subject>()
                .HasData(
                 new Subject()
                 {
                     StudentId = 1,
                     Name = "History",
                     Credits = 3,
                     Semestar = 2,
                 },
                 new Subject()
                 {
                     StudentId = 1,
                     Name = "Chemistry",
                     Credits = 2,
                     Semestar = 2,
                 },
                      new Subject()
                      {
                          StudentId = 1,
                          Name = "English",
                          Credits = 2,
                          Semestar = 2,
                      }, new Subject()
                      {
                          StudentId = 1,
                          Name = "French",
                          Credits = 2,
                          Semestar = 2,
                      });
                 
                 
        }
    }
    
    
}
