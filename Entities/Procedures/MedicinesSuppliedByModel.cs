namespace Healthcare.API.Entities.Procedures;

public class MedicinesSuppliedByModel
{
    public int MedicineId { get; set; }
    public string? Name { get; set; }
    public string? Dosage { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public string? SupplierName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
