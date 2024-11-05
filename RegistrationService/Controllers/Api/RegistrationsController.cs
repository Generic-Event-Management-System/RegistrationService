﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegisration(int id)
        {
            return Ok(await _registrationsService.GetRegistraion(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, RegistrationDto registrationDto)
        {
            return Ok(await _registrationsService.UpdateRegistration(id, registrationDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            await _registrationsService.DeleteRegistration(id);
            return NoContent();
        }
    }
}
