using AutoMapper;
using RegistrationService.Constants;
using RegistrationService.Models.Dto;
using RegistrationService.Models.Entities;

namespace RegistrationService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationDto, Registration>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom((src, dest) => string.IsNullOrEmpty(dest.Status) ? RegistrationStatus.Pending : dest.Status))
                .ForMember(dest => dest.Date, opt => opt.MapFrom((src, dest) => string.IsNullOrEmpty(dest.Date) ? DateTime.UtcNow.ToString("yyyy-MM-dd") : dest.Date));

            CreateMap<Registration, RegistrationDto>();
        }
    }
}
