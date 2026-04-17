using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class OrderWorkflowService : IOrderWorkflowService
    {


        private readonly AppDbContext _context;

        public OrderWorkflowService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<Order>> GetByStatusAsync(string status)
        {
            return await _context.Orders
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<string> UpdateStatusAsync(UpdateOrderStatusDto dto)
        {
            var order = await _context.Orders.FindAsync(dto.OrderId);

            if (order == null)
                throw new Exception("Order not found");

            // Repair old empty status rows
            if (string.IsNullOrWhiteSpace(order.Status))
                order.Status = "New";

            if (order.Status == "New" && dto.Status == "Packing")
                order.Status = "Packing";

            else if (order.Status == "Packing" && dto.Status == "Dispatched")
                order.Status = "Dispatched";

            else if (order.Status == "Dispatched" && dto.Status == "Delivered")
                order.Status = "Delivered";

            else
                throw new Exception($"Current status is {order.Status}. Cannot move to {dto.Status}");

            await _context.SaveChangesAsync();

            return "Status Updated";
        }
    }
    }

