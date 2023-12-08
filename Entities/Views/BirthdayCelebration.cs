namespace Healthcare.API.Entities.Views;

public partial class BirthdayCelebration
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
}
