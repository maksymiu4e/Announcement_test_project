using Announcements.business.DTO;
using Announcements.data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcements.business.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<AnnouncementDto> CreateAnnouncementAsync(AnnouncementDto announcementDto);
        Task<Announcement> EditAnnouncementAsync(long id, AnnouncementDto announcementDto);
        Task<bool> DeleteAnnouncementAsync(long id);
        Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync();
        Task<AnnouncementDto> GetAnnouncementsDetailsAsync(long id);
    }
}
