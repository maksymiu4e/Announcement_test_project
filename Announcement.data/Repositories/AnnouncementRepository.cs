using Announcements.data.Entities;
using Announcements.data.Repositories.Interfaces;

namespace Announcements.data.Repositories
{
    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
