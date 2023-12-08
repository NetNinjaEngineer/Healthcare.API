namespace Healthcare.API.Entities.Views;

public partial class GetEmployeesWithDepartment
{
    public string Employee { get; set; } = null!;

    public string? DepartmentName { get; set; }

    public string JobTitle { get; set; } = null!;
}
