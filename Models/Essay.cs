using EssayAi.Services;
using Newtonsoft.Json;

namespace EssayAi.Models;

public class Essay
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Title { get; set; }
    
    public string Context { get; set; }
    
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    public virtual User User { get; set; }
    
    [JsonIgnore]
    public virtual EssayResult EssayResult { get; set; }

    public Essay()
    {
        
    }
    public Essay( string title, string context, Guid userId)
    {
        Id = Guid.Empty;
        Title = title;
        Context = context;
        UserId = userId;
    }

    public override string ToString()
    {
        return $"{Title} {Context} EssayId {Id}";
    }
}