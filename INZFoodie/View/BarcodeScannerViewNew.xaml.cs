using INZFoodie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerViewNew : ContentPage
    {
        public BarcodeScannerViewNew(string barcode)
        {
            InitializeComponent();

        }

    }
}