using INZFoodie.Model;
using INZFoodie.View.Scanning;
using INZFoodie.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerView : ContentPage
    {
        public BarcodeScannerView()
        {
            InitializeComponent();

        }

        private async void scanView_OnScanResult(ZXing.Result result)
        {            
            var httpClient = new HttpClient();
            try
            {
                var resultJson = await httpClient.GetStringAsync($"http://192.168.0.221:5016/api/Product/{result.Text}");
                Product resultProduct = JsonConvert.DeserializeObject<Product>(resultJson);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushAsync(new BarcodeScannerResult(resultProduct));
                });
            }     
            catch (Exception ex)
            { 
                return;
            }

            

            

        }

    }
}