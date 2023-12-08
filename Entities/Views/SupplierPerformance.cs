using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class SupplierPerformance
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public int? SuppliedMedicineCount { get; set; }

    public DateTime? LatestSupplyExpiry { get; set; }
}
