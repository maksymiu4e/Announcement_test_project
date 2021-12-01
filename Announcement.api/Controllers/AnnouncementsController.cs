using Announcements.business.DTO;
using Announcements.business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Announcements.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAnnouncement(AnnouncementDto announcementDto)
        {
            if (announcementDto is null)
            {
                return StatusCode(422, "Cannot create announcement");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _announcementService.CreateAnnouncementAsync(announcementDto);

            return Ok(announcementDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> EditAnnouncement(long id, AnnouncementDto announcementDto)
        {
            var announcementToEdit = await _announcementService.GetAnnouncementsDetailsAsync(id);
            if (announcementToEdit is null)
            {
                return StatusCode(422, "Announcement not found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           

            var updatedAnnouncement = await _announcementService.EditAnnouncementAsync(id, announcementDto);
            return Ok(updatedAnnouncement);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAnnouncement(long id)
        {
            var foundAnnouncement = await _announcementService.GetAnnouncementsDetailsAsync(id);
            if (foundAnnouncement is null)
            {
                return StatusCode(404, "Announcement not found");
            }

            await _announcementService.DeleteAnnouncementAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAllAnnouncement()
        {
            var announcements = await _announcementService.GetAllAnnouncementsAsync();
            if (announcements is null)
            {
                return StatusCode(404, "Announcement not found");
            }
            return Ok(announcements);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAnnouncementDetails(long id)
        {
            var announcement = await _announcementService.GetAnnouncementsDetailsAsync(id);
            if (announcement is null)
            {
                return StatusCode(404, "Announcement not found");
            }
            return Ok(announcement);
        }
    }
}
