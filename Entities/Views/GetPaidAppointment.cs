namespace Healthcare.API.Entities.Views;

public partial class GetPaidAppointment
{
    public int AppointmentId { get; set; }

    public string Patient { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public string Doctor { get; set; } = null!;

    public decimal? DepartmentCost { get; set; }

    public string Paid { get; set; } = null!;
}
