using System.ComponentModel.DataAnnotations;

namespace OnlinePharmacyAndPrescriptionSystem.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public int MedicineId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
