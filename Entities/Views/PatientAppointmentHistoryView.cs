namespace Healthcare.API.Entities.Views;

public class PatientAppointmentHistoryView
{
    public string? PatientName { get; set; }
    public int TotalAppointments { get; set; }
    public DateTime FirstAppointment { get; set; }
    public DateTime LastAppointment { get; set; }
}
