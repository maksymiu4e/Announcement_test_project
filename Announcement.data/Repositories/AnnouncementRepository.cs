using Announcements.data.Entities;
using Announcements.data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Announcements.data.Repositories
{
    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
