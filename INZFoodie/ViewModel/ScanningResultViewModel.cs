using INZFoodie.Model;
using INZFoodie.View;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace INZFoodie.ViewModel
{
    public class ScanningResultViewModel : ContentView
    {
        public ObservableRangeCollection<Ingredient> IngredientsList { get ; set; }
        public AsyncCommand<Ingredient> SelectedCommand { get; set; }
        public Product Product { get; set; }

        public ScanningResultViewModel(Model.Product productObj)
        {
            IngredientsList = new ObservableRangeCollection<Ingredient>();
            Product = new Product();
            Product = productObj;
            foreach (var item in productObj.Ingredients)
            {
                if (item.HealthInfo == 0)
                {
                    item.Color = "Green";
                    IngredientsList.Add(item);                        
                }
                else if (item.HealthInfo == 1)
                {
                    item.Color = "White";
                    IngredientsList.Add(item);
                }
                else
                {
                    item.Color = "Red";
                    IngredientsList.Add(item);
                }            
            }
        }

        async Task Selected(Ingredient ingredient)
        {
            
            if (ingredient == null)
                return;

            await Application.Current.MainPage.DisplayAlert(ingredient.Name, ingredient.Info, "OK");
        }
        

    }

}

