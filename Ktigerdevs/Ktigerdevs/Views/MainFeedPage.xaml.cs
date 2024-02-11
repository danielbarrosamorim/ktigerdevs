using System.Threading.Tasks;
using Ktigerdevs.ViewModels;
using Xamarin.Forms;

namespace Ktigerdevs.Views
{
    public partial class MainFeedPage : ContentPage
	{	
		public MainFeedPage ()
		{
			InitializeComponent ();
			MainFeedViewModel vm; 
			BindingContext = vm =  new MainFeedViewModel();
			Task.Run(async () => await vm.LoadCharactersAsync());

        }
	}
}

