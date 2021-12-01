using Announcements.data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Announcements.data.Initialization
{
    public static class DBInitialization
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Announcement[] announcements = new[]
            {
                new Announcement
                {
                    Id = 1,
                    Name = "New Announcement",
                    Description = "Check seed functionality",
                    CreationDate = DateTime.Now
                },

                new Announcement
                {
                    Id = 2,
                    Name = "Another announcement",
                    Description = "Great description",
                    CreationDate = DateTime.Now
                }
            };

            modelBuilder.Entity<Announcement>().HasData(announcements);
        }
    }
}
