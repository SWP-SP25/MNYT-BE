﻿using Application.Services.IServices;
using Application.ViewModels;
using Application.ViewModels.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VnPayController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;

        public VnPayController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpPost("CreatePayment")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDTO dto)
        {
            Console.WriteLine($"================My time : {DateTime.Now}");
            Console.WriteLine($"================My time UTC: {DateTime.UtcNow}");
            var paymentUrl = await _vnPayService.CreateVnPayPaymentAsync(dto.AccountId, dto.MembershipPlanId);
            return Ok(ApiResponse<string>.SuccessResponse(paymentUrl, "VNPAY payment URL generated successfully."));
        }

        [HttpGet("Callback")]
        [AllowAnonymous]
        public async Task<IActionResult> Callback()
        {
            var queryParams = new Dictionary<string, string>();
            foreach (var q in HttpContext.Request.Query)
            {
                queryParams[q.Key] = q.Value;
            }

            var success = await _vnPayService.HandleVnPayCallbackAsync(queryParams);
            if (!success)
            {
                return Redirect("https://unrivaled-puppy-dc2558.netlify.app/payment-fail");
            }

            if (queryParams.TryGetValue("vnp_ResponseCode", out var responseCode) && responseCode == "00")
            {
                return Redirect("https://unrivaled-puppy-dc2558.netlify.app/payment-success");
            }
            else
            {
                return Redirect("https://unrivaled-puppy-dc2558.netlify.app/payment-fail");
            }
        }
    }
}
