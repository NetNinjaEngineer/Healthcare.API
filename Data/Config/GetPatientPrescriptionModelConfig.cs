using Healthcare.API.Entities.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class GetPatientPrescriptionModelConfig : IEntityTypeConfiguration<GetPatientPrescriptionModel>
{
    public void Configure(EntityTypeBuilder<GetPatientPrescriptionModel> builder)
    {
        builder.HasNoKey();
    }
}
