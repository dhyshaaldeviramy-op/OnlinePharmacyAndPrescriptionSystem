namespace OnlinePharmacyAndPrescriptionSystem.DTOs
{
    public class MedicineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsPrescriptionRequired { get; set; }
    }
}
