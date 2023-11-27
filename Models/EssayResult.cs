using Newtonsoft.Json;

namespace EssayAi.Models;

public class EssayResult
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public int Score { get; set; }
    
    public string Feedback { get; set; }
    
    public Guid EssayId {get; set; }
    
    [JsonIgnore]
    public virtual Essay? Essay  { get; set; }


    public EssayResult() { }
    
    
    public EssayResult( Guid essayId, int score, string feedback)
    {
        EssayId = essayId;
        Score = score;
        Feedback = feedback;
    }

    public override string ToString()
    {
        return $"Score: {Score} Feedback: {Feedback}";
    }
}