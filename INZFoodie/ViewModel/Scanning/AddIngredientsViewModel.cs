using INZFoodie.Model;
using INZFoodie.View.Scanning;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace INZFoodie.ViewModel.Scanning
{
    public class AddIngredientsViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableRangeCollection<Ingredient> IngredientsList { get; set; }
        public AsyncCommand RefreshCommand { get; set; }
        public AsyncCommand AddCommand { get; set; }
        public AsyncCommand SaveIngredientCommand { get; set; }
        public Product  pro { get; set; }
        public AddIngredientsViewModel(Model.Product product)
        {
            pro = product;
            LoadMore();
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(add);
            IngredientsList = new ObservableRangeCollection<Ingredient>();
            IngredientsListSelected = new List<object> ();
            result = ingredients.Count.ToString();
            SaveIngredientCommand = new AsyncCommand(Save);
            OnPropertyChanged(nameof(Result));
        }        

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { if(searchText != value) 
                { searchText = value; OnPropertyChanged(nameof(SearchText)); } }
        }

        private string result;
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                if(result != value)
                { result = ingredients.Count.ToString(); OnPropertyChanged(nameof(Result)); }
            }
        }

        private List<object> ingredients;
        public List<object> IngredientsListSelected
        {
            get
            {
                return ingredients;
            }
            set
            {
                if(ingredients != value)
                {
                    ingredients = value; 
                }                
            }
        }
        async Task Save()
        {
            List<Ingredient> ingredientsList = new List<Ingredient>();
            foreach(var item in ingredients)
            {
                ingredientsList.Add(item as Ingredient);
            }

            pro.Ingredients = ingredientsList;
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(pro);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                var resultJson = await httpClient.PostAsync("http://192.168.0.221:5016/AddProduct", content);
                string result = resultJson.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

            }
        }

        async Task add()
        {
            var route = $"{nameof(AddIngredient)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);
            IngredientsListSelected.Clear();
            IngredientsList.Clear();

            LoadMore();

            IsBusy = false;
        }
        async void LoadMore()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                var resultJson = await httpClient.GetAsync($"http://192.168.0.221:5016/ListIngrediets");
                var content = await resultJson.Content.ReadAsStringAsync();

                List<Ingredient> sda = JsonConvert.DeserializeObject<List<Ingredient>>(content);
                sda.Reverse();

                foreach (Ingredient ingredient in sda)
                {
                    IngredientsList.Add(ingredient);
                }
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
