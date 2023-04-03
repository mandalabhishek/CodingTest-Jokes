using System.Text.Json;
using Web.Models;
using Web.Utility;

namespace Web.Services.Jokes
{
    public class JokeService : IJokeService
    {
        public async Task<Joke> GetJokes()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://dad-jokes.p.rapidapi.com/random/joke"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "c2a868c61cmsh6ab745991f1348ep15ee92jsn99ffb704f296" },
                        { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<Response<List<Joke>>>(body);
                    if (result != null && result.body != null)
                        return result.body.First();
                    return await Task.FromResult(new Joke());
                }
            }
            catch
            {
                return await Task.FromResult(new Joke());
            }
        }
        public async Task<int> GetJokesCount()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://dad-jokes.p.rapidapi.com/joke/count"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "c2a868c61cmsh6ab745991f1348ep15ee92jsn99ffb704f296" },
                        { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<Response<int>>(body);
                    return result != null ? result.body : await Task.FromResult(0);
                }
            }
            catch
            {
                return await Task.FromResult(0);
            }
        }
    }
}
