
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyInsuranceAPI.Data;
using PharmacyInsuranceAPI.Models;

namespace PharmacyInsuranceAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPatient(int id, Patient patient)
        {
            var existing = await _context.Patients.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Name = patient.Name;
            existing.Age = patient.Age;
            existing.ContactInfo = patient.ContactInfo;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/assign-insurance")]
        public async Task<IActionResult> AssignInsurance(int id, InsuranceCompany insurance)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            _context.InsuranceCompanies.Add(insurance);
            await _context.SaveChangesAsync();

            patient.InsuranceCompanyId = insurance.Id;
            await _context.SaveChangesAsync();

            return Ok(patient);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.InsuranceCompany)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null) return NotFound();
            return Ok(patient);
        }
    }
}
