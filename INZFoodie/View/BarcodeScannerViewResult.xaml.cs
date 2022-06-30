using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using INZFoodie.Model;
using INZFoodie.ViewModel;
using System.Collections.Generic;

namespace INZFoodie.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerViewResult : ContentPage
    {
        public BarcodeScannerViewResult(Model.Product barcode)
        {
            InitializeComponent();
            BindingContext = new ScanningResultViewModel(barcode, barcode.Ingredients);
        }




    }
}