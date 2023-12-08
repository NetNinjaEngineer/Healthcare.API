using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities.Views;

public partial class GetTotalCheckupCostForDepartment
{
    public string? DepartmentName { get; set; }

    public int? TotalAppointments { get; set; }

    public decimal? TotalCost { get; set; }
}
