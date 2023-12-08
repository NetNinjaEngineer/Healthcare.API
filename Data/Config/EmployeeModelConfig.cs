using Healthcare.API.Entities.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class EmployeeModelConfig : IEntityTypeConfiguration<EmployeeModel>
{
    public void Configure(EntityTypeBuilder<EmployeeModel> builder)
    {
        builder.HasNoKey();
    }
}
