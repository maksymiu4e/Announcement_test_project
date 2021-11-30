using Announcements.business.DTO;
using Announcements.data.Entities;
using AutoMapper;

namespace Announcements.business.ModelMapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
        }
    }
}
