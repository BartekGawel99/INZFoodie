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
    [QueryProperty(nameof(product), nameof(product))]
    public class ScanningResultViewModel : ContentView
    {
        public ObservableRangeCollection<Ingredient> HealthIngList { get ; set; }
        public ObservableRangeCollection<Ingredient> NeutralIngList { get; set; }
        public ObservableRangeCollection<Ingredient> UnHealthIngList { get; set; }
        public AsyncCommand<Ingredient> SelectedCommand { get; set; }
        public Product product { get; set; }
        public ScanningResultViewModel(Model.Product productObj)
        {
            HealthIngList = new ObservableRangeCollection<Ingredient>();
            NeutralIngList = new ObservableRangeCollection<Ingredient>();
            UnHealthIngList = new ObservableRangeCollection<Ingredient>();
            product = new Product();
            product = productObj;
            for( int i = 0; i < 5; i++)
            {
                foreach (var item in productObj.Ingredients)
                {
                    if (item.HealthInfo == 0)
                    {
                        HealthIngList.Add(item);
                    }
                    else if (item.HealthInfo == 1)
                    {
                        NeutralIngList.Add(item);
                    }
                    else
                    {
                        UnHealthIngList.Add(item);
                    }

                }
            }

            SelectedCommand = new AsyncCommand<Ingredient>(Selected);
        }

        async Task Selected(Ingredient ingredient)
        {
            
            if (ingredient == null)
                return;

            await Application.Current.MainPage.DisplayAlert(ingredient.Name, ingredient.Info, "OK");
        }
    }
}
