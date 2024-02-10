using Ktigerdevs.ViewModels;
using Xamarin.Forms;

namespace Ktigerdevs.Views
{
    public partial class CharacterDetailsPage : ContentPage
	{	
		public CharacterDetailsPage ()
		{
			InitializeComponent ();
            BindingContext = new CharacterDetailsViewModel();
        }
	}
}

