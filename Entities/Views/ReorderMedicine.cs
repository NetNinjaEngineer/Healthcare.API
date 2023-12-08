using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class ReorderMedicine
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public int CurrentQuantity { get; set; }

    public int BoxQuantity { get; set; }

    public string ReorderStatus { get; set; } = null!;
}
