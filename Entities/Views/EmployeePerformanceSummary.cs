namespace Healthcare.API.Entities.Views;

public partial class EmployeePerformanceSummary
{
    public string Employee { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public int? TotalAppointments { get; set; }
}
