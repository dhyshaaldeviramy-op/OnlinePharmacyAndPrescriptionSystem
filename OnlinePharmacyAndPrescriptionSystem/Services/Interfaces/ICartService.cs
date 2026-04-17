using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Interfaces
{
    public interface ICartService
    {
        Task AddAsync(CartDto dto);
        Task<List<CartItem>> GetByUserAsync(string userName);
        Task DeleteAsync(int id);
    }
}
