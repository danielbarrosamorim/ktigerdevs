using Ktigerdevs.Views;
using Xamarin.Forms;

namespace Ktigerdevs
{
    public partial class AppShell : Shell
    {	
		public AppShell ()
		{
			InitializeComponent ();
            Routing.RegisterRoute(nameof(AppDetailsPage), typeof(AppDetailsPage));
            Routing.RegisterRoute(nameof(CharacterDetailsPage), typeof(CharacterDetailsPage));
            Routing.RegisterRoute(nameof(MainFeedPage), typeof(MainFeedPage));
        }
	}
}

