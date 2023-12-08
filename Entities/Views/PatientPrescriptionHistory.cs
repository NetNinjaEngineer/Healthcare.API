using System;
using System.Collections.Generic;

namespace Healthcare.API.Entities.Views;

public partial class PatientPrescriptionHistory
{
    public string PatientName { get; set; } = null!;

    public string Diagnosis { get; set; } = null!;

    public string? PrescribedMedicines { get; set; }
}
