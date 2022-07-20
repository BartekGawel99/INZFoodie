using INZFoodie.ViewModel.Calculator.CalculatorMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie.View.Calculator.CalculatorMode
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaistToHeightRatioPage : ContentPage
    {
        public WaistToHeightRatioPage()
        {
            InitializeComponent();
            BindingContext = new WaistToHeightRatioPageViewModel();
        }
    }
}