using EssayAi.Brokers;
using EssayAi.Models;
using Microsoft.EntityFrameworkCore;

namespace EssayAi.Services;

public class EssayService
{
    private readonly StorageBroker _dbContext;

    public EssayService(StorageBroker dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<IEnumerable<Essay>> GetAsync()
    {
        return await _dbContext.Essays.ToListAsync();
    }

    public async ValueTask<Essay?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Essays.FindAsync(id);
    }
    
    public async ValueTask<Essay> CreateAsync(Essay essay)
    {
         await _dbContext.Essays.AddAsync(essay);
         await _dbContext.SaveChangesAsync();

        return essay;
    }

    public async ValueTask<Essay> DeleteAsync(Essay essay,CancellationToken cancellationToken = default(CancellationToken))
    {
        var result =  _dbContext.Essays.Remove(essay);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return essay;
    }
    
}