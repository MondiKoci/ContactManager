using Microsoft.EntityFrameworkCore;
using System;

namespace ContactManager.Models
{
    public class ContContext : DbContext
    {
        public ContContext(DbContextOptions<ContContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Friends" },
                new Category { CategoryId = 2, Name = "Work" },
                new Category { CategoryId = 3, Name = "Family" },
                new Category { CategoryId = 4, Name = "Other" }
            );
            modelBuilder.Entity<Contact>().HasData(
                new Contact {
                    ContactId = 1,
                    FirstName = "Esmeralda",
                    LastName = "Koci",
                    Phone = "314-143-3141",
                    Email = "delijaalda@mail.com",
                    Organization = "Shkodra Web",
                    DateAdded = DateTime.Now,
                    CategoryId = 3       
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Laszlo",
                    LastName = "Torok",
                    Phone = "416-828-7552",
                    Email = "select@hotmail.com",
                    Organization = "Select Protection Services",
                    DateAdded = DateTime.Now,
                    CategoryId = 2
                    },
                new Contact
                {
                    ContactId = 3,
                    FirstName = "Frederic",
                    LastName = "Knoestah",
                    Phone = "416-578-4188",
                    Email = "frederic.knoestah@georgebrown.ca",
                    DateAdded = DateTime.Now,
                    CategoryId = 1
                }
            );
        }
    }
}
