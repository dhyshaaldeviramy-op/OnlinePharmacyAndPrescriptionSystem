using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class DashboardService: IDashboardService
    {

     
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetStatsAsync()
        {
            var totalOrders = await _context.Orders.CountAsync();

            var revenue = await _context.Orders
                .SumAsync(x => (decimal?)x.GrandTotal) ?? 0;

            var delivered = await _context.Orders
                .CountAsync(x => x.Status == "Delivered");

            var pending = await _context.Orders
                .CountAsync(x => x.Status != "Delivered");

            var medicines = await _context.Medicines.CountAsync();

            return new
            {
                totalOrders,
                revenue,
                delivered,
                pending,
                medicines
            };
        }
    }
}

