namespace Healthcare.API.Entities.Views;

public partial class GetMedicinesWithDosage
{
    public int MedicineId { get; set; }

    public string Name { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public DateTime ExpireDate { get; set; }

    public decimal UnitPrice { get; set; }

    public int StockQuantity { get; set; }

    public byte[]? Image { get; set; }

    public string? ImagePath { get; set; }

}
