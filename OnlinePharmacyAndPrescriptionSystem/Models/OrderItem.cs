using System.ComponentModel.DataAnnotations;

namespace OnlinePharmacyAndPrescriptionSystem.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string MedicineName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
