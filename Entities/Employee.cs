using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class Employee
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

    public byte[]? Image { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; } = new List<EmployeeSchedule>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
