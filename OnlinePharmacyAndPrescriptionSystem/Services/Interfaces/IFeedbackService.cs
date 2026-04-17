using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<string> AddAsync(FeedbackDto dto);
        Task<List<Feedback>> GetAllAsync();
    }
}
