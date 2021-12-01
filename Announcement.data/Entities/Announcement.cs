using System;

namespace Announcements.data.Entities
{
    public class Announcement : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
