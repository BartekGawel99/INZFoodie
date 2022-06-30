using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
       async void Button_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var resultJson = await httpClient.GetStringAsync("http://192.168.0.221:5016/WeatherForecast");
            var resultForcasts = JsonConvert.DeserializeObject<WeatherForecast[]>(resultJson);

            forecasts.ItemsSource = resultForcasts;
        }
    }
}
