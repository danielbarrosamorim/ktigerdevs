using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ktigerdevs.Models;
using Ktigerdevs.Services;
using Ktigerdevs.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Ktigerdevs.ViewModels
{

    public partial class MainFeedViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Character> characters;

        [ObservableProperty]
        private ObservableCollection<Result> results;

        private APIService _apiService;

        public MainFeedViewModel()
        {
            _apiService = new APIService();
            Characters = new ObservableCollection<Character>();
            Results = new ObservableCollection<Result>();
          // LoadCharacters();
        }

        public async Task LoadCharactersAsync()
        {
            
            var resultAPIService = await _apiService.GetCharacterAsync();
            var resultOrdered = resultAPIService.results.OrderBy(n => n.name);
            Results = new ObservableCollection<Result>(resultOrdered);
        }

        [RelayCommand]
        private async Task GoToCharacterDetailsPage(Result result)
        {
            var jsonResult = JsonConvert.SerializeObject(result);
            var route = $"{nameof(CharacterDetailsPage)}?JsonResult={Uri.EscapeDataString(jsonResult)}";
            await Shell.Current.GoToAsync(route);
        }

        [RelayCommand]
        private async Task GoToAppDetailsPage()
        {
            var route = $"{nameof(AppDetailsPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}