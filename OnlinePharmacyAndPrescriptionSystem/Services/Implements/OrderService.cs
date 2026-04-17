using Microsoft.EntityFrameworkCore;
using OnlinePharmacyAndPrescriptionSystem.Data;
using OnlinePharmacyAndPrescriptionSystem.DTOs;
using OnlinePharmacyAndPrescriptionSystem.Models;
using OnlinePharmacyAndPrescriptionSystem.Services.Interfaces;

namespace OnlinePharmacyAndPrescriptionSystem.Services.Implements
{
    public class OrderService: IOrderService
    {


        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<object> CheckoutAsync(CheckoutDto dto)
        {
            var cart = await _context.CartItems
                .Where(x => x.UserName == dto.UserName)
                .ToListAsync();

            if (!cart.Any())
                throw new Exception("Cart Empty");

            decimal subtotal = cart.Sum(x => x.Price * x.Quantity);

            decimal tax = subtotal * 0.05m;

            decimal delivery = subtotal < 500 ? 50 : 0;

            decimal total = subtotal + tax + delivery;

            // Stock Validation
            foreach (var item in cart)
            {
                var med = await _context.Medicines.FindAsync(item.MedicineId);

                if (med.Stock < item.Quantity)
                    throw new Exception($"{med.Name} out of stock");

                med.Stock -= item.Quantity;
            }

            var order = new Order
            {
                UserName = dto.UserName,
                SubTotal = subtotal,
                Tax = tax,
                DeliveryFee = delivery,
                GrandTotal = total,
                PaymentMethod = dto.PaymentMethod,
                Status = "New"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in cart)
            {
                _context.OrderItems.Add(new OrderItem
                {
                    OrderId = order.Id,
                    MedicineName = item.MedicineName,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            _context.CartItems.RemoveRange(cart);

            await _context.SaveChangesAsync();

            return new
            {
                message = "Order Placed",
                orderId = order.Id,
                total = total
            };
        }
    
}
}
