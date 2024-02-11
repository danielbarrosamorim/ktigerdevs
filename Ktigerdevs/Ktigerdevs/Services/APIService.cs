using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ktigerdevs.Models;
using Newtonsoft.Json;

namespace Ktigerdevs.Services
{
    public class APIService
    {
        private readonly HttpClient _httpClient;

        public APIService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Character> GetCharacterAsync()
        {
            try
            {
                string urlCharacter = "https://rickandmortyapi.com/api/character";
                var response = await _httpClient.GetAsync(urlCharacter);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Character>(json);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.Write($"API Service - GetCharacterAsync error : {ex}");
            }

            return null;
        }

        public async Task<Episode> GetEpisodeAsync(string urlEpisode)
        {
            try
            {
                //string urlEpisode = "https://rickandmortyapi.com/api/episode";
                var response = await _httpClient.GetAsync(urlEpisode);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Episode>(json);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.Write($"API Service - GetEpisodeAsync error : {ex}");
            }
            return null;
        }

    }
}

