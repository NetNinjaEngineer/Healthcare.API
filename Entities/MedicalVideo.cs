using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class MedicalVideo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[] Video { get; set; } = null!;

    public string Path { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
