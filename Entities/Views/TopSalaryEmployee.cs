using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class TopSalaryEmployee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public decimal Salary { get; set; }
}
