namespace Healthcare.API.Entities.Procedures;

public class PatientWithCheckupCostByFullNameModel : BaseEntity
{
    public string? Patient { get; set; }
    public string? Doctor { get; set; }
    public string? Gender { get; set; }
    public decimal CostOfDiagnosis { get; set; }
}
