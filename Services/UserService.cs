using EssayAi.Brokers;
using EssayAi.Models;
using Microsoft.EntityFrameworkCore;

namespace EssayAi.Services;

public class UserService
{
    private readonly StorageBroker _dbContext;

    public UserService(StorageBroker dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<IEnumerable<User>> GetAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async ValueTask<User?> GetByIdAsync(Guid id)
    {
        var result = await _dbContext.Users.FindAsync(id);
        return result;
    }
    public async ValueTask<User> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        
        return user;
    }

    public async ValueTask<User> UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async ValueTask<User> DeleteAsync(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        
        return user;
    }
    
}