using CommunityToolkit.Mvvm.ComponentModel;
using Ktigerdevs.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ktigerdevs.Services;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using Ktigerdevs.Views;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace Ktigerdevs.ViewModels
{

    public partial class MainFeedViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Character> characters;

        [ObservableProperty]
        private ObservableCollection<Result> results;

        private APIService _characterService;

        public MainFeedViewModel()
        {
            _characterService = new APIService();
            Characters = new ObservableCollection<Character>();

            Results = new ObservableCollection<Result>();
            LoadCharacters();
        }

        private async void LoadCharacters()
        {
            string url = "https://rickandmortyapi.com/api/character";
            var Character = await _characterService.GetCharacterAsync(url);

            Results = new ObservableCollection<Result>(Character.results);
            //foreach (var character in characters)
            //{
            //    Characters.Add(character);
            //}
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Result result)
        {
            var jsonResult = JsonConvert.SerializeObject(result);
            var route = $"{nameof(CharacterDetailsPage)}?JsonResult={Uri.EscapeDataString(jsonResult)}";
            await Shell.Current.GoToAsync(route);
        }


    }
}