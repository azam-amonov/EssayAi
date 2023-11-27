using System.Text;
using Newtonsoft.Json;

namespace EssayAi.Services
{
    public class EssayCheckerAi
    {
        private static readonly HttpClient _httpClient = new ();
        private static string _apiKey = @"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";
        private static readonly string _endPointUrl = @"https://api.openai.com/v1/chat/completions";

        public static async void Start()
        {
            var assistant = await OpenAiComplete(_apiKey, _endPointUrl);
            Console.WriteLine(assistant.ToString());
            Console.ReadLine();
        }

        public static async Task<string> OpenAiComplete(string key, string endpoint)
        {
            var payload = new
            {
                            model = "gpt-3.5-turbo-0301",
                            max_tokens = 256,
                            temprature = 0.9,
                            messages = new object[]
                            {
                                            new { role = "system", content = "You are essays examiner, how give feedback and score to essay " }, 
                                            new { reole = "user", content = "English essay" }
                            }
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Add("Authorization", $"Bearer {key}");
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.SendAsync(request);
            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}