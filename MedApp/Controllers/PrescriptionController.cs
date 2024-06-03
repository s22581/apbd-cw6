using MedApp.Services;
using MedApp.Repositories;
using MedApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [ApiController]
    [Route("api/prescriptions")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public IActionResult AddPrescription([FromBody] PrescriptionDto dto)
        {
            try
            {
                _prescriptionService.AddPrescription(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
