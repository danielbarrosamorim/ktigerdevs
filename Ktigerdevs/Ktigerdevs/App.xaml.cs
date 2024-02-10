using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Ktigerdevs
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new AppShell();

           // MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
            string appSecret = "3ff69d59-7c11-4406-b34f-0f4584c7ef9e";
            AppCenter.Start($"ios={appSecret};" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here};" +
                  "macos={Your macOS App secret here};",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

