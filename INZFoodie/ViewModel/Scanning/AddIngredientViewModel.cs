using INZFoodie.Model;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel.Scanning
{
    internal class AddIngredientViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AsyncCommand SaveIngCommand { get; }

        public AddIngredientViewModel()
        {
            SaveIngCommand = new AsyncCommand(Save);
        }

        string nameIng;
        public string NameIng
        {
            get { return $"{nameIng}"; }
            set { nameIng= value ; }
        }
        string infoIng;
        public string InfoIng
        {
            get { return $"{infoIng}"; }
            set { infoIng= value ; }
        }
        string healthInfo;
        public string HealthInfo
        { 
            get { return healthInfo; }
            set { healthInfo = value; }
        }

        async Task Save()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = nameIng;
            ingredient.Info = infoIng;
            if(HealthInfo == "Nieporządane")
            {
                ingredient.HealthInfo = 2;
            }
            else if(HealthInfo == "Neutralne")
            {
                ingredient.HealthInfo = 1;
            }
            else
            {
                ingredient.HealthInfo = 0;
            }

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject( ingredient );
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                var resultJson = await httpClient.PostAsync($"https://xn--infoodie-43b.azurewebsites.net/AddIngrediet", content);
                string result = resultJson.Content.ReadAsStringAsync().Result;

                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Błąd połaczenia z serwerem", "OK");
                return;
            }
        }

    }
}
