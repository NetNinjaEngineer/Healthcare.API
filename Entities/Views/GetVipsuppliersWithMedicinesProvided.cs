namespace Healthcare.API.Entities.Views;

public partial class GetVipsuppliersWithMedicinesProvided
{
    public string SupplierName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? MedicinesProvided { get; set; }
}
