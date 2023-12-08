namespace Healthcare.API.Entities.Views;

public partial class EmployeeLoginInfo
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string? AuthCode { get; set; }
}
