using System;
using System.Collections.Generic;
using System.Text;

namespace Announcements.business.DTO
{
    public class AnnouncementDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
