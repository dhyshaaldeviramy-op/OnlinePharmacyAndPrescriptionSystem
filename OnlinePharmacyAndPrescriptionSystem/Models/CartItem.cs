using System.ComponentModel.DataAnnotations;

namespace OnlinePharmacyAndPrescriptionSystem.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public int MedicineId { get; set; }

        public string MedicineName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsPrescriptionRequired { get; set; }
    }
}
