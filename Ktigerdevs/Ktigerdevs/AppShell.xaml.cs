using System;
using System.Collections.Generic;
using Ktigerdevs.Views;
using Xamarin.Forms;

namespace Ktigerdevs
{	
	public partial class AppShell : Shell
    {	
		public AppShell ()
		{
			InitializeComponent ();
            Routing.RegisterRoute("CharacterDetailsPage", typeof(CharacterDetailsPage));
            Routing.RegisterRoute("MainFeedPage", typeof(MainFeedPage));
        }
	}
}

