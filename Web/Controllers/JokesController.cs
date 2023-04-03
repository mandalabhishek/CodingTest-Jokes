using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services.Jokes;

namespace Web.Controllers
{
    public class JokesController : Controller
    {
        private readonly IJokeService _iJokeService;
        public JokesController(IJokeService iJokeService)
        {
            _iJokeService = iJokeService;
        }
        public async Task<Joke> GetJokes()
        {
            return await _iJokeService.GetJokes();
        }
        public async Task<int> GetJokesCount()
        {
            return await _iJokeService.GetJokesCount();
        }
    }
}
