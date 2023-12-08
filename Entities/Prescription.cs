using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? PatientId { get; set; }

    public string Diagnosis { get; set; } = null!;

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<PatientsPrescription> PatientsPrescriptions { get; set; } = new List<PatientsPrescription>();

    public virtual ICollection<PharmacyTransaction> PharmacyTransactions { get; set; } = new List<PharmacyTransaction>();
}
