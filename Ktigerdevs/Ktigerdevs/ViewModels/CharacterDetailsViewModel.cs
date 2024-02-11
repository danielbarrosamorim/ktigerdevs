using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Ktigerdevs.Models;
using Ktigerdevs.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Ktigerdevs.ViewModels
{
    [QueryProperty(nameof(JsonResult), nameof(JsonResult))]
    public partial class CharacterDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Result result;

        private string jsonResult;

        [ObservableProperty]
        private ObservableCollection<Episode> episodes;

        private readonly APIService _apiService;

        public CharacterDetailsViewModel()
        {
            _apiService = new APIService();
            Episodes = new ObservableCollection<Episode>();
        }

        public string JsonResult
        {
            get => jsonResult;
            set
            {
                if (SetProperty(ref jsonResult, value))
                {
                    InitializeViewModel();
                }
            }
        }

        private void InitializeViewModel()
        {
            Result = JsonConvert.DeserializeObject<Result>(Uri.UnescapeDataString(jsonResult));
            if (Result?.episode.Count > 0)
            {
                ProcessEpisodesAsync(Result.episode);
            }
        }

        private async Task ProcessEpisodesAsync(IEnumerable<string> episodeUrls)
        {
            foreach (var episodeUrl in episodeUrls)
            {
                await GetEpisodeAsync(episodeUrl).ConfigureAwait(false);
            }
        }

        private async Task GetEpisodeAsync(string urlEpisode)
        {
            try
            {
                var episode = await _apiService.GetEpisodeAsync(urlEpisode);
                Device.BeginInvokeOnMainThread(() => Episodes.Add(episode));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching episode data: {ex.Message}");
            }
        }
    }
}
