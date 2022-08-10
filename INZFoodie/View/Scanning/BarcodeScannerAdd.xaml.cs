using INZFoodie.ViewModel.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie.View.Scanning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerAdd : ContentPage
    {
        public BarcodeScannerAdd(string barcode)
        {
            InitializeComponent();
            BindingContext = new ScanningAddViewModel(barcode);
        }
    }
}