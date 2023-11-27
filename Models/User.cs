using System.Text.Json.Serialization;

namespace EssayAi.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string EmailAddress { get; set; }
    
    [JsonIgnore]
    public virtual IEnumerable<Essay>? Essay { get; set; }

    public User()
    {
        
    }
    public User( string firstName, string lastName, string emailAddress)
    {
        Id = Guid.Empty;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
    }
    
    public override string  ToString()
    {
        return $"User: {FirstName} {LastName} " +
               $"UserId: {Id}\n" +
               $"Essay: {Essay}\n";
    }
}