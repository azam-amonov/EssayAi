using EssayAi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EssayAi.Brokers;

public partial class StorageBroker
{
    public DbSet<User> Users => Set<User>();

    public void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        builder
                .HasMany(user => user.Essay)
                .WithOne(essay => essay.User)
                .HasForeignKey(essay => essay.UserId);
    }
}