using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class EmployeeSchedule
{
    public int SchedualId { get; set; }

    public int DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
