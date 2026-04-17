using System.ComponentModel.DataAnnotations;

namespace OnlinePharmacyAndPrescriptionSystem.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal DeliveryFee { get; set; }
        public string Status { get; set; } = "New";
        public decimal GrandTotal { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime OrderedAt { get; set; } = DateTime.Now;
    }
}
