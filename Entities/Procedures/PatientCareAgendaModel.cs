namespace Healthcare.API.Entities.Procedures;

public class PatientCareAgendaModel : BaseEntity
{
    public string? Doctor { get; set; }
    public string? Patient { get; set; }
}
