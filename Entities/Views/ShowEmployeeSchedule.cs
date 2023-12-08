using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities.Views;

public partial class ShowEmployeeSchedule
{
    public string EmployeeName { get; set; } = null!;

    public string? Days { get; set; }

    public string? Schedule { get; set; }
}
