using Announcements.data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.data.Configurations
{
    class AnnouncementEntityConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcement");

            builder.Property(b => b.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(100)");

            builder.Property(b => b.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("VARCHAR(5000)");

            builder.Property(b => b.CreationDate)
                .IsRequired()
                .HasColumnName("CreationDate")
                .HasColumnType("DATETIME");
        }
    }
}
