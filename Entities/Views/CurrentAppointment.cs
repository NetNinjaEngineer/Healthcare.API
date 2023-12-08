using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class CurrentAppointment
{
    public int AppointmentId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string PatientName { get; set; } = null!;

    public string Paid { get; set; } = null!;
}
