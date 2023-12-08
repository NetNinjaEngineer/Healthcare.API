namespace Healthcare.API.Entities.Views;

public partial class OutOfStockMedicine
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public int CurrentQuantity { get; set; }
}
