using OnlinePharmacyAndPrescriptionSystem.DTOs;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Interfaces
{
    public interface IPrescriptionService
    {

        Task<List<PrescriptionDto>> GetAllAsync();
        Task UploadAsync(IFormFile file, string userName);
        Task ApproveAsync(int id);
        Task RejectAsync(int id, string reason);
    }

 
}
