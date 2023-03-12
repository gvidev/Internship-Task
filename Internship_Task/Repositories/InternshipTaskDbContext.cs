using Internship_Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internship_Task.Repositories
{
    public class InternshipTaskDbContext : DbContext
    {


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Entities.Manager> Managers { get; set; }

        public InternshipTaskDbContext()
        {
            this.Employees = this.Set<Employee>();
            this.Tasks = this.Set<Entities.Task>();
            this.Managers = this.Set<Entities.Manager>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;" +
                "Database=InternshipTaskDb;" +
                "User Id=gvidev;Password=adminpass;" +
                "TrustServerCertificate=True");
        }


        //configure for easy testing without creating new entries in database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Manager>().HasData
               (
                new Manager()
                {
                    Id= 1,
                    FullName = "Angel Despinov",
                    Email = "adespinov@gmail.com",
                    PhoneNumber = "+359882563",
                    Address = "Struma 13",
                    Department = "service",
                    DateOfStart = new DateTime(2022, 08, 13, 0, 0, 0),
                    MonthlySalary = 4023.52m
                },
                new Manager()
                {
                    Id = 2,
                    FullName = "Vanina Despinova",
                    Email = "vdespinova@gmail.com",
                    PhoneNumber = "+35988223563",
                    Address = "Struma 12",
                    Department = "service",
                    DateOfStart = new DateTime(2022, 07, 13, 0, 0, 0),
                    MonthlySalary = 3023.52m
                },
                new Manager()
                {
                    Id = 3,
                    FullName = "Tania Videva",
                    Email = "tvideva@gmail.com",
                    PhoneNumber = "+359886572563",
                    Address = "Petur Beron 13",
                    Department = "service",
                    DateOfStart = new DateTime(2021, 08, 13, 0, 0, 0),
                    MonthlySalary = 4223.11m
                },
                new Manager()
                {
                    Id = 4,
                    FullName = "Nikolai Videv",
                    Email = "nvidev@gmail.com",
                    PhoneNumber = "+35988762563",
                    Address = "Petur Beron 6",
                    Department = "service",
                    DateOfStart = new DateTime(2002, 08, 13, 0, 0, 0),
                    MonthlySalary = 5013.22m
                }

                );
            modelBuilder.Entity<Employee>().HasData
                 (
                 new Employee()
                 {
                     Id = 1,
                     FullName = "Georgi Nikolaev Videv",
                     Email = "videvgeorge@gmail.com",
                     PhoneNumber = "+359884550043",
                     DateOfBirth = new DateTime(2002, 05, 20, 0, 0, 0),
                     MonthlySalary = 400.52m,
                     ManagerId = 1
                 },
                 new Employee()
                 {
                     Id = 2,
                     FullName = "Hristina Angelova Despinova",
                     Email = "hdespinova@gmail.com",
                     PhoneNumber = "+35923102309",
                     DateOfBirth = new DateTime(2002, 11, 28, 0, 0, 0),
                     MonthlySalary = 432.52m,
                     ManagerId = 1
                 },
                 new Employee()
                 {
                     Id = 3,
                     FullName = "Angel Pavlov Pavlov",
                     Email = "apavlov@gmail.com",
                     PhoneNumber = "+359882321313",
                     DateOfBirth = new DateTime(2002, 08, 13, 0, 0, 0),
                     MonthlySalary = 931.52m,
                     ManagerId = 2
                 },
                 new Employee()
                 {
                     Id = 4,
                     FullName = "Mila Hristova Cenova",
                     Email = "mcenova@gmail.com",
                     PhoneNumber = "+35988485043",
                     DateOfBirth = new DateTime(2002, 11, 14, 0, 0, 0),
                     MonthlySalary = 410.52m,
                     ManagerId = 2
                 },
                 new Employee()
                 {
                     Id = 5,
                     FullName = "Maria Dimitrova Dimitrova",
                     Email = "mdimitrova@gmail.com",
                     PhoneNumber = "+359877643",
                     DateOfBirth = new DateTime(2002, 03, 28, 0, 0, 0),
                     MonthlySalary = 231.52m,
                     ManagerId = 2
                 },
                 new Employee()
                 {
                     Id = 6,
                     FullName = "Magdalena Miroslavova Jekova",
                     Email = "mjekova@gmail.com",
                     PhoneNumber = "+35988786743",
                     DateOfBirth = new DateTime(2003, 09, 6, 0, 0, 0),
                     MonthlySalary = 230.52m,
                     ManagerId = 3
                 }
                 ); ;

            modelBuilder.Entity<Entities.Task>().HasData
               (
               new Entities.Task()
               {
                   Id = 1,
                   Title = "Task 1",
                   Description = "something...",
                   DueDate = new DateTime(2023, 02, 05, 0, 0, 0),
                   AssigneeId = 3
               },
               new Entities.Task()
               {
                   Id = 2,
                   Title = "Task 2",
                   Description = "something...",
                   DueDate = new DateTime(2023, 02, 25, 0, 0, 0),
                   AssigneeId = 2
               },
               new Entities.Task()
               {
                   Id = 3,
                   Title = "Task 3",
                   Description = "something...",
                   DueDate = new DateTime(2023, 02, 19, 0, 0, 0),
                   AssigneeId = 4
               },
               new Entities.Task()
               {
                   Id = 4,
                   Title = "Task 4",
                   Description = "something...",
                   DueDate = new DateTime(2023, 02, 18, 0, 0, 0),
                   AssigneeId = 2
               },
               new Entities.Task()
               {
                   Id = 5,
                   Title = "Task 5",
                   Description = "something...",
                   DueDate = new DateTime(2023, 03, 6, 0, 0, 0),
                   AssigneeId = 3
               },
               new Entities.Task()
               {
                   Id = 6,
                   Title = "Task 6",
                   Description = "something...",
                   DueDate = new DateTime(2023, 03, 6, 0, 0, 0),
                   AssigneeId = 2
               },
               new Entities.Task()
               {
                   Id = 7,
                   Title = "Task 7",
                   Description = "something...",
                   DueDate = new DateTime(2023, 02, 14, 0, 0, 0),
                   AssigneeId = 1
               },
               new Entities.Task()
               {
                   Id = 8,
                   Title = "Task 8",
                   Description = "something...",
                   DueDate = new DateTime(2023, 02, 10, 0, 0, 0),
                   AssigneeId = 1
               },
               new Entities.Task()
               {
                   Id = 9,
                   Title = "Task 9",
                   Description = "something...",
                   DueDate = new DateTime(2023, 02, 8, 0, 0, 0),
                   AssigneeId = 1
               },
                new Entities.Task()
                {
                    Id = 10,
                    Title = "Task 10",
                    Description = "something...",
                    DueDate = new DateTime(2023, 02, 8, 0, 0, 0),
                    AssigneeId = 5
                }

               );





        }


    }
}
