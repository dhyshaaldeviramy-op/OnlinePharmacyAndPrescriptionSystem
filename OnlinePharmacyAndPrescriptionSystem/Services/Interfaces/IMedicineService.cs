using OnlinePharmacyAndPrescriptionSystem.DTOs;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<List<MedicineDto>> GetAllAsync();
        Task<MedicineDto> AddAsync(MedicineDto dto);
        Task<MedicineDto> UpdateAsync(int id, MedicineDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<MedicineDto>> SearchAsync(string term);
    }

}
