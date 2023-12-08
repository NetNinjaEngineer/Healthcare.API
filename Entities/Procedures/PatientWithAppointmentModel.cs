namespace Healthcare.API.Entities.Procedures;

public class PatientWithAppointmentModel : BaseEntity
{
    public int AppointmentId { get; set; }
    public string? Patient { get; set; }
    public string? Doctor { get; set; }
    public decimal DepartmentCost { get; set; }
    public string? Paid { get; set; }
}
