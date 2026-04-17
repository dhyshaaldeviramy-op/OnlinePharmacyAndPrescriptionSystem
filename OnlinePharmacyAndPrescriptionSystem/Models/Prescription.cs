using System.ComponentModel.DataAnnotations;

namespace OnlinePharmacyAndPrescriptionSystem.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FilePath { get; set; }

        public string Status { get; set; } = "Pending";

        public string? RejectReason { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}
