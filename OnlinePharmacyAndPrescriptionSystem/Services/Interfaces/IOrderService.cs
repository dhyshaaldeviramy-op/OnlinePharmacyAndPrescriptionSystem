using OnlinePharmacyAndPrescriptionSystem.DTOs;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Interfaces
{
    public interface IOrderService
    {

        Task<object> CheckoutAsync(CheckoutDto dto);
    }
}
