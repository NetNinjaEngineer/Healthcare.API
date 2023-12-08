using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int? EmployeeId { get; set; }

    public string Paid { get; set; } = null!;

    public int PatientId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
