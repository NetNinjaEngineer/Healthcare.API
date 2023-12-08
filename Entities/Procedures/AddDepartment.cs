using System.ComponentModel.DataAnnotations;

namespace Healthcare.API.Entities.Procedures;

public class AddDepartment
{
    [RegularExpression(@"^[a-z A-Z]+$")]
    public string? DepartmentName { get; set; }
    public decimal DepartmentCost { get; set; }
}
