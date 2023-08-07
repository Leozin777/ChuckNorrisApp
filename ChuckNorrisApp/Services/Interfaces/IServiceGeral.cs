using ChuckNorrisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisApp.Services.Interfaces;

public interface IServiceGeral
{
    public Task<Joke> GetRandomJoke();
    public Task<IEnumerable<string>> GetAllCategories();
    public Task<Joke> GetJokeForCategory(string p_category);
    public Task<SearchItem> GetJokeSearch(string p_search);
}
