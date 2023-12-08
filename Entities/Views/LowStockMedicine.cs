namespace Healthcare.API.Entities.Views;

public partial class LowStockMedicine
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public int CurrentQuantity { get; set; }

    public int BoxQuantity { get; set; }

    public string StockStatus { get; set; } = null!;
}
