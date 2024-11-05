using RegistrationService.Models.Dto;
using RegistrationService.Models.Entities;

namespace RegistrationService.Services.Contracts
{
    public interface IRegistrationsService
    {
        Task<Registration> CreateRegistration(RegistrationDto registrationDto);
        Task<IEnumerable<Registration>> GetRegistrations();
    }
}
