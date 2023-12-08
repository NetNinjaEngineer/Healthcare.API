using Healthcare.API.Entities.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCareAPI.Data.Config;

public class PateintsByFullNameModelConfig : IEntityTypeConfiguration<PateintsByFullNameModel>
{
    public void Configure(EntityTypeBuilder<PateintsByFullNameModel> builder)
    {
        builder.HasNoKey();
    }
}
