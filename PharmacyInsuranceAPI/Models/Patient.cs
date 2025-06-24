
namespace PharmacyInsuranceAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
        public int? InsuranceCompanyId { get; set; }
        public InsuranceCompany? InsuranceCompany { get; set; }
    }
}
