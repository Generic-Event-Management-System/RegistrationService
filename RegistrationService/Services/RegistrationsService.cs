using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegistrationService.ExceptionHandling;
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

        public async Task<IEnumerable<Registration>> GetRegistrations()
        {
            return await _dbContext.Registrations.ToListAsync();
        }

        public async Task<Registration> GetRegistraion(int registrationId)
        {
            return await GetRegistrationOrThrowNotFoundException(registrationId);
        }

        public async Task<Registration> UpdateRegistration(int registrationId, RegistrationDto registrationDto)
        {
            var registration = await GetRegistrationOrThrowNotFoundException(registrationId);

            _mapper.Map(registrationDto, registration);

            await _dbContext.SaveChangesAsync();

            return registration;
        }

        private async Task<Registration> GetRegistrationOrThrowNotFoundException(int registrationId)
        {
            var registration = await _dbContext.Registrations.FirstOrDefaultAsync(r => r.Id == registrationId);

            if (registration == null)
                throw new NotFoundException("Registration not found.");

            return registration;
        }
    }
}
