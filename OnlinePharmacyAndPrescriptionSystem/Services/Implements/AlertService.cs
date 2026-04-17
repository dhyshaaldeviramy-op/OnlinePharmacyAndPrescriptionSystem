using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class AlertService: IAlertService
    {
        private readonly AppDbContext _context;

        public AlertService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetAlertsAsync()
        {
            var lowStock = await _context.Medicines
                .Where(x => x.Stock <= 10)
                .ToListAsync();

            var expirySoon = await _context.Medicines
                .Where(x => x.ExpiryDate <= DateTime.Now.AddMonths(1))
                .ToListAsync();

            return new
            {
                lowStock,
                expirySoon
            };
        }
    
}
}
