using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Interfaces
{
    public interface IOrderWorkflowService
    {

        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetByStatusAsync(string status);
        Task<string> UpdateStatusAsync(UpdateOrderStatusDto dto);
       
    }
}
