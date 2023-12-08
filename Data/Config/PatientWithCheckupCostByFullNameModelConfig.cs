using Healthcare.API.Entities.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class PatientWithCheckupCostByFullNameModelConfig :
    IEntityTypeConfiguration<PatientWithCheckupCostByFullNameModel>
{
    public void Configure(EntityTypeBuilder<PatientWithCheckupCostByFullNameModel> builder)
    {
        builder.HasNoKey();
    }
}
