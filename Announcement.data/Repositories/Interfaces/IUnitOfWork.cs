using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IAnnouncementRepository AnnouncementRepository { get; }

        Task SaveAsync();
    }
}
