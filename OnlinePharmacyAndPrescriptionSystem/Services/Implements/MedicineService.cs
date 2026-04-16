using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class MedicineService: IMedicineService
    {

        
        private readonly AppDbContext _context;

        public MedicineService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedicineDto>> GetAllAsync()
        {
            return await _context.Medicines
                .Where(x => x.IsActive)
                .Select(x => new MedicineDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Manufacturer = x.Manufacturer,
                    Category = x.Category,
                    Price = x.Price,
                    Stock = x.Stock,
                    ExpiryDate = x.ExpiryDate,
                    IsPrescriptionRequired = x.IsPrescriptionRequired
                }).ToListAsync();
        }

        public async Task<MedicineDto> AddAsync(MedicineDto dto)
        {
            if (dto.Price < 0 || dto.Stock < 0)
                throw new Exception("Invalid Price or Stock");

            var med = new Medicine
            {
                Name = dto.Name,
                Manufacturer = dto.Manufacturer,
                Category = dto.Category,
                Price = dto.Price,
                Stock = dto.Stock,
                ExpiryDate = dto.ExpiryDate,
                IsPrescriptionRequired = dto.IsPrescriptionRequired
            };

            _context.Medicines.Add(med);
            await _context.SaveChangesAsync();

            dto.Id = med.Id;
            return dto;
        }

        public async Task<MedicineDto> UpdateAsync(int id, MedicineDto dto)
        {
            var med = await _context.Medicines.FindAsync(id);
            if (med == null) throw new Exception("Not found");

            med.Name = dto.Name;
            med.Manufacturer = dto.Manufacturer;
            med.Category = dto.Category;
            med.Price = dto.Price;
            med.Stock = dto.Stock;
            med.ExpiryDate = dto.ExpiryDate;
            med.IsPrescriptionRequired = dto.IsPrescriptionRequired;

            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var med = await _context.Medicines.FindAsync(id);
            if (med == null) return false;

            med.IsActive = false; // Soft delete
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<MedicineDto>> SearchAsync(string term)
        {
            return await _context.Medicines
                .Where(x => x.IsActive &&
                       (x.Name.Contains(term) || x.Category.Contains(term)))
                .Select(x => new MedicineDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Manufacturer = x.Manufacturer,
                    Category = x.Category,
                    Price = x.Price,
                    Stock = x.Stock,
                    ExpiryDate = x.ExpiryDate,
                    IsPrescriptionRequired = x.IsPrescriptionRequired
                })
                .ToListAsync();
        }
    }
}

