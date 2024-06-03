namespace MedApp.Models.DTOs
{
    public class GetPrescriptionDto
    {
        public int IdPrescription { get; set; }
        public string Date { get; set; }
        public string DueDate { get; set; }
        public List<GetMedicamentDto> Medicaments { get; set; }
        public GetDoctorDto Doctor { get; set; }
    }
}
