using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class Stock
{
    public int StockId { get; set; }

    public int? MedicineId { get; set; }

    public int BoxQuantity { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual Medicine? Medicine { get; set; }
}
