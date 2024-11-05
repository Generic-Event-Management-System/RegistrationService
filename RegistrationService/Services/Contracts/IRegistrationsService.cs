using RegistrationService.Models.Dto;
using RegistrationService.Models.Entities;

namespace RegistrationService.Services.Contracts
{
    public interface IRegistrationsService
    {
        Task<Registration> CreateRegistration(RegistrationDto registrationDto);
        Task<IEnumerable<Registration>> GetRegistrations();
        Task<Registration> GetRegistraion(int registrationId);
        Task<Registration> UpdateRegistration(int registrationId, RegistrationDto registrationDto);
        Task DeleteRegistration(int registrationId);
    }
}
