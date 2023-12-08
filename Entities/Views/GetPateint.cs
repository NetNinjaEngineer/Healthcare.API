using System;
using System.Collections.Generic;

namespace HealthCareAPI.Models.Views;

public partial class GetPateint
{
    public string FullName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;
}
