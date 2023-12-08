using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities.Views;

public partial class GetTotalAppointmentsForDepartment
{
    public string? DepartmentName { get; set; }

    public int? TotalAppointments { get; set; }
}
