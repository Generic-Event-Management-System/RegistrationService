using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationService.Models.Dto;
using RegistrationService.Services.Contracts;

namespace RegistrationService.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationsService _registrationsService;

        public RegistrationsController(IRegistrationsService registrationsService)
        {
            _registrationsService = registrationsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration(RegistrationDto registrationDto)
        {
            return Ok(await _registrationsService.CreateRegistration(registrationDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            return Ok(await _registrationsService.GetRegistrations());
        }
    }
}
