using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class GetSuppliersWithMedicinesProvided
{
    public string SupplierName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? MedicinesProvided { get; set; }
}
