using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {

        private readonly IAlertService _service;

        public AlertController(IAlertService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAlertsAsync());
        }
    }
}
