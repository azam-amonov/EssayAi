using EssayAi.Brokers;
using EssayAi.Models;
using Microsoft.EntityFrameworkCore;

namespace EssayAi.Services;

public class EssayResultService
{
    private readonly StorageBroker _dbContext;

    public EssayResultService(StorageBroker dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async ValueTask<IEnumerable<EssayResult>> GetAsync()
    {
        return await _dbContext.EssayResults.ToListAsync();
    }

    public async ValueTask<EssayResult?> GetByIdAsync(Guid id)
    {
       return await _dbContext.EssayResults.FindAsync(id);
    }
    public async ValueTask<EssayResult> CreateAsync(EssayResult essayResult)
    {
        await _dbContext.EssayResults.AddAsync(essayResult);
        await _dbContext.SaveChangesAsync();
        
        return essayResult;
    }

    public async ValueTask<EssayResult> Delete(EssayResult essayResult)
    {
        _dbContext.EssayResults.Remove(essayResult);
        await _dbContext.SaveChangesAsync();
        
        return essayResult;
    }
}