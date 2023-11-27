using EssayAi.Models;
using Microsoft.EntityFrameworkCore;

namespace EssayAi.Brokers;

public partial class StorageBroker : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host = localhost,Port = 5234;Database = beTarteeb; Username = postgres; Password = qwerty;");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureUser(modelBuilder.Entity<User>());
        ConfigureEssay(modelBuilder.Entity<Essay>());
        ConfigureEssayResult(modelBuilder.Entity<EssayResult>());
        base.OnModelCreating(modelBuilder);
    }
}