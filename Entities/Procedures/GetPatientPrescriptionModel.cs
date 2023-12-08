namespace Healthcare.API.Entities.Procedures;

public class GetPatientPrescriptionModel
{
    public string? Patient { get; set; }
    public string? MedicineName { get; set; }
    public string? Dosage { get; set; }
    public string? Times { get; set; }
    public string? Diagnosis { get; set; }
}
