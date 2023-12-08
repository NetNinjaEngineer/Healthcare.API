namespace Healthcare.API.Entities.Views;

public partial class ExpiringMedicine
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public DateTime ExpireDate { get; set; }

    public string ExpiryStatus { get; set; } = null!;
}
