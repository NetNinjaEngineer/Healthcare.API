using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class MedicineDosage
{
    public int? MedicineId { get; set; }

    public string Dosage { get; set; } = null!;

    public virtual Medicine? Medicine { get; set; }
}
