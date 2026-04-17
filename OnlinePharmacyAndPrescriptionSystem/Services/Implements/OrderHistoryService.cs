using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.Models;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class OrderHistoryService: IOrderHistoryService
    {
        private readonly AppDbContext _context;

        public OrderHistoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetByUserAsync(string userName)
        {
            return await _context.Orders
                .Where(x => x.UserName == userName)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}
