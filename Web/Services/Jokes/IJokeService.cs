using Web.Models;

namespace Web.Services.Jokes
{
    public interface IJokeService
    {
        Task<Joke> GetJokes();
        Task<int> GetJokesCount();
    }
}
