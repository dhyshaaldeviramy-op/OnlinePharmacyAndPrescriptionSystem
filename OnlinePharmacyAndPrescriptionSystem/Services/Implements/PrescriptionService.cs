using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class PrescriptionService: IPrescriptionService
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PrescriptionService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task UploadAsync(IFormFile file, string userName)
        {
            var folder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(folder, fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            var item = new Prescription
            {
                UserName = userName,
                FilePath = "/uploads/" + fileName,
                Status = "Pending"
            };

            _context.Prescriptions.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PrescriptionDto>> GetAllAsync()
        {
            return await _context.Prescriptions
                .Select(x => new PrescriptionDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FilePath = x.FilePath,
                    Status = x.Status,
                    RejectReason = x.RejectReason
                }).ToListAsync();
        }

        public async Task ApproveAsync(int id)
        {
            var item = await _context.Prescriptions.FindAsync(id);
            item.Status = "Verified";
            await _context.SaveChangesAsync();
        }

        public async Task RejectAsync(int id, string reason)
        {
            var item = await _context.Prescriptions.FindAsync(id);
            item.Status = "Rejected";
            item.RejectReason = reason;
            await _context.SaveChangesAsync();
        }
    }

}
