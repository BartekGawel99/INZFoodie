using INZFoodie.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var isLoogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            var userId = Xamarin.Essentials.SecureStorage.GetAsync("Id").Result;
            //MainPage = new MainPage();
            if (isLoogged == "1")            
            {                
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginView();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
