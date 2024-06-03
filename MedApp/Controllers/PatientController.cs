using MedApp.Repositories;
using MedApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{idPatient}")]
        public IActionResult GetPatient([FromRoute] int idPatient)
        {
            try
            {
                var patient = _patientService.GetPatient(idPatient);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
