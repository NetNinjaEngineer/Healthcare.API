namespace Healthcare.API.Entities.Procedures;

public class BaseEntity
{
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
}