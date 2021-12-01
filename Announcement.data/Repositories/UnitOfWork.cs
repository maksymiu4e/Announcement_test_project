using Announcements.data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Announcements.data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private IAnnouncementRepository _announcementRepository;
        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IAnnouncementRepository AnnouncementRepository
        {
            get
            {
                return _announcementRepository = _announcementRepository ?? new AnnouncementRepository(_applicationContext);
            }
        }

        public void Dispose()
        {
            _applicationContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
