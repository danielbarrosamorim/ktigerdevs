using System;
using System.Collections.Generic;
using Ktigerdevs.ViewModels;
using Xamarin.Forms;

namespace Ktigerdevs.Views
{	
	public partial class MainFeedPage : ContentPage
	{	
		public MainFeedPage ()
		{
			InitializeComponent ();
			BindingContext = new MainFeedViewModel();
        }
	}
}

