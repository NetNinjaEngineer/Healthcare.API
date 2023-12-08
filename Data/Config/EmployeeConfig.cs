using Healthcare.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.Image)
            .HasColumnName("Image")
            .HasColumnType("VARBINARY(MAX)")
            .IsRequired(false);

        builder.Property(x => x.ImageUrl)
           .HasColumnName("ImageUrl")
           .HasColumnType("VARCHAR(50)")
           .IsRequired(false);
    }
}
