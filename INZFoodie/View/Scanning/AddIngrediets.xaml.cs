using INZFoodie.ViewModel.Scanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie.View.Scanning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddIngrediets : ContentPage
    {
        public AddIngrediets(Model.Product product)
        {
            InitializeComponent();
            BindingContext = new AddIngredientsViewModel(product);
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as AddIngredientsViewModel;            

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                IngredientsCollectionView.ItemsSource = _container.IngredientsList;
            else
                IngredientsCollectionView.ItemsSource = _container.IngredientsList.Where(i => i.Name.Contains(e.NewTextValue));
        }
    }
}