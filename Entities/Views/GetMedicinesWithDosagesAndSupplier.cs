namespace Healthcare.API.Entities.Views;

public partial class GetMedicinesWithDosagesAndSupplier
{
    public int MedicineId { get; set; }

    public string Name { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public DateTime ExpireDate { get; set; }

    public decimal UnitPrice { get; set; }

    public int StockQuantity { get; set; }

    public string SupplierName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
