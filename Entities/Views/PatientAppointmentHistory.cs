using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities.Views;

public partial class PatientAppointmentHistory
{
    public string PatientName { get; set; } = null!;

    public int? TotalAppointments { get; set; }

    public DateTime? FirstAppointment { get; set; }

    public DateTime? LastAppointment { get; set; }
}
