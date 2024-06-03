namespace MedApp.Models.DTOs
{
    public class GetPatientDto
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public List<GetPrescriptionDto> Prescriptions { get; set; }
    }
}
