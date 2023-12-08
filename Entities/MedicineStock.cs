using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class MedicineStock
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public DateTime ExpireDate { get; set; }

    public int StockQuantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int CurrentQuantity { get; set; }

    public int BoxQuantity { get; set; }

    public DateTime LastUpdated { get; set; }
}
