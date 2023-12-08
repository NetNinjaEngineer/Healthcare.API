namespace Healthcare.API.Entities.Views;

public partial class PatientsWithCheckupCost
{
    public string Patient { get; set; } = null!;

    public string Doctor { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public string Gender { get; set; } = null!;

    public decimal? CostOfDiagnosis { get; set; }

    public string Paid { get; set; } = null!;
}
