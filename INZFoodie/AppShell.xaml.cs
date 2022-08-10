using INZFoodie.View;
using INZFoodie.View.Calculator;
using INZFoodie.View.Calculator.CalculatorMode;
using INZFoodie.View.Personal;
using INZFoodie.View.Scanning;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();            
            Routing.RegisterRoute(nameof(PersonalPage),typeof(PersonalPage));
            Routing.RegisterRoute(nameof(CalculatorPage), typeof(CalculatorPage));
            Routing.RegisterRoute(nameof(BMIPage), typeof(BMIPage));
            Routing.RegisterRoute(nameof(CpmPage), typeof(CpmPage));
            Routing.RegisterRoute(nameof(GlycemicLoadPage), typeof(GlycemicLoadPage));
            Routing.RegisterRoute(nameof(HarrisPage), typeof(HarrisPage));
            Routing.RegisterRoute(nameof(IdealBodyWeightPage), typeof(IdealBodyWeightPage));
            Routing.RegisterRoute(nameof(LeanBodyMassPage), typeof(LeanBodyMassPage));
            Routing.RegisterRoute(nameof(MiffinPage), typeof(MiffinPage));
            Routing.RegisterRoute(nameof(WaistToHeightRatioPage), typeof(WaistToHeightRatioPage));
            Routing.RegisterRoute(nameof(WaistToHipRatioPage), typeof(WaistToHipRatioPage));
            Routing.RegisterRoute(nameof(AddPersonalPage), typeof(AddPersonalPage));
            Routing.RegisterRoute(nameof(AddIngrediets), typeof(AddIngrediets));
            Routing.RegisterRoute(nameof(AddIngredient), typeof(AddIngredient));


        }


        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "0");
            Xamarin.Essentials.SecureStorage.SetAsync("Id", "");
            Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }
    }
}