using Microsoft.EntityFrameworkCore;
using Announcements.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Announcements.data.Configurations;
using Announcements.data.Initialization;

namespace Announcements.data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AnnouncementEntityConfiguration());

            //modelBuilder.Seed();
        }
    }
}
