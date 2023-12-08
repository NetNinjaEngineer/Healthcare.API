using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public decimal? DepartmentCost { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<MedicalVideo> MedicalVideos { get; set; } = new List<MedicalVideo>();
}
