namespace MedApp.Models.DTOs
{
    public class PrescriptionDto
    {
        public PatientDto Patient { get; set; }
        public List<MedicamentDto> Medicaments { get; set; }
        public string Date { get; set; }
        public string DueDate { get; set; }
        public int IdDoctor { get; set; }

    }
}
