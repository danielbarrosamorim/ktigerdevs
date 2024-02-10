using System;
using System.Collections.Generic;
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

        public async Task<Character> GetCharacterAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Character>(json);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }

            return null;
        }
    }
}

