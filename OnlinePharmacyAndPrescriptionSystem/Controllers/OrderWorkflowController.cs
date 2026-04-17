using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderWorkflowController : ControllerBase
    {

        private readonly IOrderWorkflowService _service;

        public OrderWorkflowController(IOrderWorkflowService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            return Ok(await _service.GetByStatusAsync(status));
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> Update(UpdateOrderStatusDto dto)
        {
            return Ok(new { message = await _service.UpdateStatusAsync(dto) });
        }
    }
}
