namespace Healthcare.API.Entities.Procedures;

public class EmployeeModel
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int DepartmentId { get; set; }
}
