using ChuckNorrisApp.Models;
using ChuckNorrisApp.Services.Interfaces;
using System.Text.Json;

namespace ChuckNorrisApp.Services
{
    public class ServiceGeral : IServiceGeral
    {
        private readonly HttpClient _httpClient;
        public ServiceGeral(HttpClient p_httpClient)
        {
            _httpClient = p_httpClient;
        }

        public async Task<IEnumerable<string>> GetAllCategories()
        {
            var m_endereco = "https://api.chucknorris.io/jokes/categories";
            var response = await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                (await _httpClient.GetStreamAsync(m_endereco), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response;
        }

        public async Task<Joke> GetJokeForCategory(string p_category)
        {
            var m_endereco = $"https://api.chucknorris.io/jokes/random?category={p_category}";
            var response = await JsonSerializer.DeserializeAsync<Joke>(await _httpClient.GetStreamAsync(m_endereco), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response;
        }

        public async Task<SearchItem> GetJokeSearch(string p_search)
        {
            var m_endereco = $"https://api.chucknorris.io/jokes/search?query={p_search}";
            var response = await JsonSerializer.DeserializeAsync<SearchItem>(await _httpClient.GetStreamAsync(m_endereco), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response;
        }

        public async Task<Joke> GetRandomJoke()
        {
            var m_endereco = "https://api.chucknorris.io/jokes/random";
            var response = await JsonSerializer.DeserializeAsync<Joke>(await _httpClient.GetStreamAsync(m_endereco), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response;
        }
    }
}
