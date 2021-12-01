using Announcements.business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.business.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<AnnouncementDto> CreateAnnouncementAsync(AnnouncementDto announcementDto);
        Task EditAnnouncementAsync(AnnouncementDto announcementDto);
        Task<bool> DeleteAnnouncementAsync(long id);
        Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync();
        Task<AnnouncementDto> GetAnnouncementsDetailsAsync(long id);
    }
}
