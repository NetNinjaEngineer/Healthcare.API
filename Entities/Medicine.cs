using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class Medicine
{
    public int MedicineId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime ExpireDate { get; set; }

    public int StockQuantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int CurrentQuantity { get; set; }

    public byte[]? Image { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<PharmacyTransaction> PharmacyTransactions { get; set; } = new List<PharmacyTransaction>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
