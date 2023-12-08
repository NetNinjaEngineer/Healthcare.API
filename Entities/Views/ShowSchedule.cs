using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class ShowSchedule
{
    public string Employee { get; set; } = null!;

    public string DayOfWeek { get; set; } = null!;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string JobTitle { get; set; } = null!;
}
