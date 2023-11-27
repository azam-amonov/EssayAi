// See https://aka.ms/new-console-template for more information

using EssayAi.Brokers;
using EssayAi.Models;
using EssayAi.Services;

await using var dbContext = new StorageBroker();

var userService = new UserService(dbContext);
var essayService = new EssayService(dbContext);
var resultService = new EssayResultService(dbContext);

// await userService.CreateAsync(new User("Shomurod","Doe", "Shomurod@example.com")); 
 
// await essayService.CreateAsync(new Essay("Test", "Test", Guid.Parse("bd8a4a28-e70a-4411-b830-516970041d06")));


await resultService.CreateAsync(new EssayResult(
                Guid.Parse("9383d287-2742-48fa-a53c-d68222f8afed"),
                59, 
                "Test"));

// var users = await userService.GetAsync();
// var essays = await essayService.GetAsync();
// var results = await resultService.GetAsync();

// foreach (var user in users)
// {
//     Console.WriteLine(user);
// }

// foreach (var essay in essays)
// {
//     Console.WriteLine(essay);
// }

// foreach (var result in results)
// {
//     Console.WriteLine(result);
// }

Console.WriteLine("Done!");

