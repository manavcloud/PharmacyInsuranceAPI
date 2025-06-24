
namespace PharmacyInsuranceAPI.Models
{
    public class InsuranceCompany
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string PolicyNumber { get; set; } = string.Empty;
        public DateTime PolicyValidTill { get; set; }
    }
}
