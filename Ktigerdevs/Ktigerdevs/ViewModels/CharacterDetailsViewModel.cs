using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;
using Newtonsoft.Json;
using Ktigerdevs.Models;
using System.Collections.ObjectModel;

namespace Ktigerdevs.ViewModels
{
    [QueryProperty(nameof(JsonResult), nameof(JsonResult))]
    public partial class CharacterDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Result result;
        private string jsonResult;

        public string JsonResult
        {
            get => jsonResult;
            set
            {
                if (SetProperty(ref jsonResult, value))
                {
                    // Deserialize the JsonResult string into Result object
                    Result = JsonConvert.DeserializeObject<Result>(Uri.UnescapeDataString(jsonResult));
                }
            }
        }
    }
}

