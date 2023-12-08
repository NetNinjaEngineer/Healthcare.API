using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class PatientsPrescription
{
    public int Id { get; set; }

    public int? PrescriptionId { get; set; }

    public string MedicineName { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string Times { get; set; } = null!;

    public virtual Prescription? Prescription { get; set; }
}
