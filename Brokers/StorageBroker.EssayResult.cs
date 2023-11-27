using EssayAi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EssayAi.Brokers;

public partial class StorageBroker
{
    public DbSet<EssayResult> EssayResults => Set<EssayResult>();

    public void ConfigureEssayResult(EntityTypeBuilder<EssayResult> builder)
    {
        builder.HasOne(essayResult => essayResult.Essay)
                        .WithOne(essay => essay.EssayResult);
    }
    
}