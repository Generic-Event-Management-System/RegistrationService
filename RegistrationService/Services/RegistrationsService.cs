using AutoMapper;
using RegistrationService.Models.Dto;
using RegistrationService.Models.Entities;
using RegistrationService.Persistence;
using RegistrationService.Services.Contracts;

namespace RegistrationService.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly RegistrationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RegistrationsService(RegistrationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Registration> CreateRegistration(RegistrationDto registrationDto)
        {
            var registration = _mapper.Map<Registration>(registrationDto);
            _dbContext.Registrations.Add(registration);
            await _dbContext.SaveChangesAsync();
            return registration;
        }
    }
}
