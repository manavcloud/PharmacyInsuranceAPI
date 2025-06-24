
namespace PharmacyInsuranceAPI.Models
{
    public class DispenseRecord
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public DateTime DispensedOn { get; set; }
        public string DispensedByLocation { get; set; } = string.Empty;
    }
}
