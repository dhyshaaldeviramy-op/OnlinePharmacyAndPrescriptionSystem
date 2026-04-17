using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class CartService: ICartService
    {


      
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CartDto dto)
        {
            var med = await _context.Medicines.FindAsync(dto.MedicineId);

            var item = new CartItem
            {
                UserName = dto.UserName,
                MedicineId = med.Id,
                MedicineName = med.Name,
                Price = med.Price,
                Quantity = dto.Quantity,
                IsPrescriptionRequired = med.IsPrescriptionRequired
            };

            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItem>> GetByUserAsync(string userName)
        {
            return await _context.CartItems
                .Where(x => x.UserName == userName)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.CartItems.FindAsync(id);

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}

