using System;
using System.ComponentModel.DataAnnotations;

namespace Announcements.business.DTO
{
    public class AnnouncementDto
    {
        [Required(ErrorMessage = "Shouldn't be empty")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Shouldn't be empty")]
        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
