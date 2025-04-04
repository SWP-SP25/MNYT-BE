﻿using Application.Services.IServices;
using Application.ViewModels.ScheduleUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleUserController : ControllerBase
    {
        private readonly IScheduleUserService _scheduleUserService;
        public ScheduleUserController(IScheduleUserService service)
        {
            _scheduleUserService = service;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddAsync(ScheduleUserAddVM item)
        {            
            await _scheduleUserService.AddAsync(item);
            return Ok(item);
        }
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(ScheduleUserVM item)
        {
            await _scheduleUserService.UpdateAsync(item);

            return Ok();
        }
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _scheduleUserService.DeleteAsync(id);
            return Ok();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var items = await _scheduleUserService.GetAllAsync();
            return Ok(items);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var item = await _scheduleUserService.GetAsync(id);
            return Ok(item);
        }
        [HttpGet("pregnancyId/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByPregnancyId(int id)
        {
            var items = await _scheduleUserService.GetAllByPregnancyIdAsync(id);
            return Ok(items);
        }
        [HttpGet("v2/pregnancyId/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTrueSchedule(int id)
        {
            var items = await _scheduleUserService.GetAllByPregnancyIdAsyncV2(id);
            return Ok(items);
        }
    }
}
