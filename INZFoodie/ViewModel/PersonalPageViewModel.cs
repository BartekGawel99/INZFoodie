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
using System.Net.Http.Headers;
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
        public AsyncCommand AddCommand { get;  }
        public AsyncCommand<Personal> EditCommand { get;  }
        public AsyncCommand<int> DeleteCommand { get;  }
        public AsyncCommand DelayLoadMoreCommand { get; }

        public PersonalPageViewModel()
        {
            PersonalsList = new ObservableRangeCollection<Personal>();
            PersonalsListGroups = new ObservableRangeCollection<Grouping<string,Personal>>();

            LoadMore();

            AddCommand = new AsyncCommand(add);
            RefreshCommand = new AsyncCommand(Refresh);
            EditCommand = new AsyncCommand<Personal>(Edit);
            DeleteCommand = new AsyncCommand<int>(Delete);
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

            PersonalsListGroups.Clear();
            PersonalsList.Clear();
            LoadMore();

            IsBusy = false;
        }
        async void LoadMore()
        {
            try
            {
                var userId = Xamarin.Essentials.SecureStorage.GetAsync("Id").Result;
                userId = userId.Replace("\"", "");
                if (PersonalsListGroups.Count >= 20)
                    return;

                HttpClient httpClient = new HttpClient();

                var resultJson = await httpClient.GetAsync($"https://xn--infoodie-43b.azurewebsites.net/api/Personel/{userId}");
                var content = await resultJson.Content.ReadAsStringAsync();


                List<Personal> sda = JsonConvert.DeserializeObject<List<Personal>>(content);
                sda.Reverse();
                foreach (Personal person in sda)
                {
                    PersonalsList.Add(person);
                    PersonalsListGroups.Add(new Grouping<string, Personal>(person.SaveTime.ToString(), PersonalsList.Where(c => c.SaveTime == person.SaveTime)));
                }

            }
            catch (Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        async Task Edit(Personal personal)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EditPersonalPage(personal));
        }
        async Task Delete(int personalID)
        {

            var action = await Application.Current.MainPage.DisplayAlert("Usuwanie", "Jesteś pewny że chcesz usunąć pomiar?", "Tak", "Nie");
            if (action)
            {
                var httpClient = new HttpClient();
                try
                {
                    await httpClient.DeleteAsync($"https://xn--infoodie-43b.azurewebsites.net/api/Personel/{personalID}");
                    await Refresh();                    
                }
                catch (Exception ex)
                {
                    await Refresh();
                    await Application.Current.MainPage.DisplayAlert("Error", "nie udało sie", "OK");
                    
                }
        
            }
            
        }

    }
}
