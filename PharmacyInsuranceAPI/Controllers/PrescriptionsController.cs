
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
    public class PrescriptionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrescriptionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPrescription), new { id = prescription.Id }, prescription);
        }

        [HttpPost("{id}/dispense")]
        public async Task<IActionResult> DispensePrescription(int id, [FromBody] string location)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null || prescription.IsDispensed)
                return BadRequest("Prescription either not found or already dispensed.");

            prescription.IsDispensed = true;
            _context.DispenseRecords.Add(new DispenseRecord
            {
                PrescriptionId = id,
                DispensedOn = DateTime.UtcNow,
                DispensedByLocation = location
            });
            await _context.SaveChangesAsync();
            return Ok(prescription);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null) return NotFound();
            return Ok(prescription);
        }
    }
}
