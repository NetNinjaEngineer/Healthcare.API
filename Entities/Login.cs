using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class Login
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? AuthCode { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
