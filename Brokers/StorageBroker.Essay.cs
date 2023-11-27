using EssayAi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EssayAi.Brokers;

public partial class StorageBroker
{
    public DbSet<Essay> Essays => Set<Essay>();

    public void ConfigureEssay(EntityTypeBuilder<Essay> builder)
    {
        builder.HasOne(essay => essay.EssayResult)
                        .WithOne(result => result.Essay);
    }
}