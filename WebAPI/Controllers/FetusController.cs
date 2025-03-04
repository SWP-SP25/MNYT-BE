﻿using Application.IServices;
using Application.ViewModels.Fetus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetusController : ControllerBase
    {
        IFetusService _fetusService;

        public FetusController(IFetusService fetusService)
        {
            _fetusService = fetusService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(FetusAddVM fetusAddVM)
        {
            await _fetusService.AddSync(fetusAddVM);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FetusVM fetusVM)
        {
            await _fetusService.UpdateAsync(fetusVM);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _fetusService.DeleteAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var items = await _fetusService.GetAllAsync();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var item = await _fetusService.GetAsync(id);
            return Ok(item);
        }
    }
}
