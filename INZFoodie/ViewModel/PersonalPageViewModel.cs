using INZFoodie.Model;
using INZFoodie.View.Personal;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel
{
    public class PersonalPageViewModel :BaseViewModel
    {
        public ObservableRangeCollection<Personal> PersonalsList { get; set; }
        public ObservableRangeCollection<Grouping<string, Personal>> PersonalsListGroups { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; set; }

        public PersonalPageViewModel()
        {
            PersonalsList = new ObservableRangeCollection<Personal>();
            PersonalsListGroups = new ObservableRangeCollection<Grouping<string,Personal>>();

            LoadMore();

            AddCommand = new AsyncCommand(add);
            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task add()
        {
            var route = $"{nameof(AddPersonalPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            PersonalsList.Clear();
            LoadMore();

            IsBusy = false;
        }
        async void LoadMore()
        {
            var userId = Xamarin.Essentials.SecureStorage.GetAsync("Id").Result;
            userId = userId.Replace("\"", "");
            if (PersonalsList.Count >= 20)
                return;

            HttpClient httpClient = new HttpClient();

            var resultJson = await httpClient.GetAsync($"http://192.168.0.221:5016/api/Personel/Personal/{userId}");  
            var content = await resultJson.Content.ReadAsStringAsync();

                
                List<Personal> sda = JsonConvert.DeserializeObject<List<Personal>>(content);
                foreach(Personal person in sda)
                {
                PersonalsList.Add(person);
                PersonalsListGroups.Add(new Grouping<string, Personal>(person.SaveTime.ToString(), PersonalsList.Where(c => c.SaveTime == person.SaveTime)));
                }





        }

    }
}
