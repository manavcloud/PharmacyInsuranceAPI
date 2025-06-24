
namespace PharmacyInsuranceAPI.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public string MedicationCode { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public int DaysSupply { get; set; }
        public bool IsDispensed { get; set; }
    }
}
