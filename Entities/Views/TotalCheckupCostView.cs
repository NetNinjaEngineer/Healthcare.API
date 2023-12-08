namespace HealthCareAPI.Models.Views;

public class TotalCheckupCostView
{
    public string? DepartmentName { get; set; }
    public int TotalAppointments { get; set; }
    public decimal? TotalCost { get; set; }
}
