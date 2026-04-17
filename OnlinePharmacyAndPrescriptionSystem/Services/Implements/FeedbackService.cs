using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class FeedbackService: IFeedbackService
    {
        private readonly AppDbContext _context;

        public FeedbackService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddAsync(FeedbackDto dto)
        {
            var item = new Feedback
            {
                UserName = dto.UserName,
                MedicineId = dto.MedicineId,
                Rating = dto.Rating,
                Comment = dto.Comment
            };

            _context.Feedbacks.Add(item);
            await _context.SaveChangesAsync();

            return "Feedback Submitted";
        }

        public async Task<List<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}
