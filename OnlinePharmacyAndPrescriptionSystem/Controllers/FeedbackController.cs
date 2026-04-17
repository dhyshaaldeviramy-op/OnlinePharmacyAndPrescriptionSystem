using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(FeedbackDto dto)
        {
            return Ok(new { message = await _service.AddAsync(dto) });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
