namespace OnlinePharmacyAndPrescriptionSystem.DTOs
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public string? RejectReason { get; set; }
    }
}
