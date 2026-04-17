using OnlinePharmacyAndPrescriptionSystem.Models;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        Task<List<Order>> GetByUserAsync(string userName);
    }
}
