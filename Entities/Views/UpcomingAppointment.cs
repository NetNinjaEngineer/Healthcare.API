namespace HealthCareAPI.Models.Views;

public partial class UpcomingAppointment
{
    public int AppointmentId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string PatientName { get; set; } = null!;

    public string Paid { get; set; } = null!;
}
