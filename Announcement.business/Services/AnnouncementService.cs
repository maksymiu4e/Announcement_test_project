using Announcements.business.DTO;
using Announcements.business.Services.Interfaces;
using Announcements.data.Entities;
using Announcements.data.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcements.business.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnnouncementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AnnouncementDto> CreateAnnouncementAsync(AnnouncementDto announcementDto)
        {
            var announcement = _mapper.Map<Announcement>(announcementDto);

            await _unitOfWork.AnnouncementRepository.AddAsync(announcement);
            await _unitOfWork.SaveAsync();

            return announcementDto;
        }

        public async Task<bool> DeleteAnnouncementAsync(long id)
        {
            return await _unitOfWork.AnnouncementRepository.DeleteAsync(id);
        }

        public async Task<Announcement> EditAnnouncementAsync(long id, AnnouncementDto announcementDto)
        {
            var announcementToEdit = await _unitOfWork.AnnouncementRepository.GetDetailsAsync(id);
            if (announcementToEdit != null)
            {
                announcementToEdit.Name = announcementDto.Name;
                announcementToEdit.Description = announcementDto.Description;
                announcementToEdit.CreationDate = announcementDto.CreationDate;

                await _unitOfWork.SaveAsync();
                return announcementToEdit;
            }

            throw new ArgumentNullException();
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync()
        {
            var announcements = await _unitOfWork.AnnouncementRepository.GetAllAsync();
            return _mapper.Map<IList<AnnouncementDto>>(announcements);                       
        }

        public async Task<AnnouncementDto> GetAnnouncementsDetailsAsync(long id)
        {
            var announcement = await _unitOfWork.AnnouncementRepository.GetDetailsAsync(id);
            return _mapper.Map<AnnouncementDto>(announcement);
        }
    }
}
