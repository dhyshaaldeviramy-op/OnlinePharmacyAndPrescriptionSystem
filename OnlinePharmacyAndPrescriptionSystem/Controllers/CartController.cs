using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

  
        private readonly ICartService _service;
        private readonly AppDbContext _context;

        public CartController(ICartService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CartDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            return Ok(await _service.GetByUserAsync(userName));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("validate/{userName}")]
        public async Task<IActionResult> Validate(string userName)
        {
            var cart = await _context.CartItems
                .Where(x => x.UserName == userName)
                .ToListAsync();

            bool requiresRx = cart.Any(x => x.IsPrescriptionRequired);

            bool verified = await _context.Prescriptions
                .AnyAsync(x =>
                    x.UserName == userName &&
                    x.Status == "Verified");

            return Ok(new
            {
                requiresRx,
                verified,
                canCheckout = !requiresRx || verified
            });
        }
    }
}

