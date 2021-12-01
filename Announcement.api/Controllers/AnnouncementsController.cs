using Announcements.business.DTO;
using Announcements.business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Announcements.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> PostAnnouncement(AnnouncementDto announcementDto)
        {
            if (announcementDto is null)
            {
                return StatusCode(422, "Cannot create announcement");
            }
            await _announcementService.CreateAnnouncementAsync(announcementDto);

            return Ok(announcementDto);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> EditAnnouncement(AnnouncementDto announcementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (announcementDto is null)
            {
                return StatusCode(422, "Cannot edit announcement");
            }

            await _announcementService.EditAnnouncementAsync(announcementDto);
            return Ok(announcementDto);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
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
        [Route("[action]/all")]
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
        [Route("[action]/{id}")]
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
