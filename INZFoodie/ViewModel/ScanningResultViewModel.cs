using INZFoodie.Model;
using INZFoodie.View;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace INZFoodie.ViewModel
{
    public class ScanningResultViewModel 
    {
        public ObservableRangeCollection<Ingredient> ingredientsList { get ; set; }
        public Product product { get; set; }
        public ScanningResultViewModel(Model.Product barcode, List<Model.Ingredient> ingredients)
        {
            ingredientsList = new ObservableRangeCollection<Ingredient>();
            product = barcode;
            ingredientsList.AddRange(barcode.Ingredients);
    

        }

        Ingredient selectedIngredient;
        public Ingredient SelectedIngredient
        {
            get => selectedIngredient;
            set
            {
                if(value != null)
                {
                    Application.Current.MainPage.DisplayAlert(value.Name, value.Info, "Ok");
                }
                selectedIngredient = value;

            }
        }
    }
}
