using INZFoodie.Model;
using INZFoodie.View.Scanning;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel.Scanning
{
    public class ScanningAddViewModel : BaseViewModel
    {
        public Product product { get; set; }
        public ObservableRangeCollection<Ingredient> IngredientsList { get; set; }
        public AsyncCommand AddIngredietnsCommand { get; set; }

        public ScanningAddViewModel(string barcode)
        {
            product = new Product();
            AddIngredietnsCommand = new AsyncCommand(AddToList);
            IngredientsList = new ObservableRangeCollection<Ingredient>();
            product.Barcode = barcode;
        }

        string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        string producer;
        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }
        string productWeight;
        public string ProductWeight
        {
            get { return productWeight; }
            set { productWeight = value; }
        }
        string kcal100;
        public string Kcal100
        {
            get { return kcal100; }
            set { kcal100 = value; }
        }
        string kcalTotal;
        public string KcalTotal
        {
            get { return kcalTotal; }
            set { kcalTotal = value; }
        }
        string fat;
        public string Fat
        {
            get { return fat; }
            set { fat = value; }
        }
        string saturatesFat;
        public string SaturatesFat
        {
            get { return saturatesFat; }
            set { saturatesFat = value; }
        }
        string carbohydrate;
        public string Carbohydrate
        {
            get { return carbohydrate; }
            set { carbohydrate = value; }
        }

        string sugar;
        public string Sugar
        {
            get { return sugar; }
            set { sugar = value; }
        }
        string protein;
        public string Protein
        {
            get { return protein; }
            set { protein = value; }

        }
        string salt;
        public string Salt
        {
            get { return salt; }
            set { salt = value; }
        }

        async Task AddToList()
        {
            if (string.IsNullOrEmpty(fat) || string.IsNullOrEmpty(saturatesFat) || string.IsNullOrEmpty(carbohydrate) ||
                string.IsNullOrEmpty(sugar) || string.IsNullOrEmpty(protein) || string.IsNullOrEmpty(salt) ||
                string.IsNullOrEmpty(productWeight) || string.IsNullOrEmpty(kcal100) || string.IsNullOrEmpty(kcalTotal) ||
                string.IsNullOrEmpty(producer) || string.IsNullOrEmpty(productName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wprowadź wszystkie dane", "OK");
                return;
            }
            else
            {
                product.Fat = fat;
                product.SaturatesFat = saturatesFat;
                product.Carbohydrate = carbohydrate;
                product.Sugar = sugar;
                product.Protein = protein;
                product.Salt = salt;
                product.ProductWeight = productWeight;
                product.Kcal100 = kcal100;
                product.KcalTotal = kcalTotal;
                product.Producer = producer;
                product.ProductName = productName;
            }


            await Application.Current.MainPage.Navigation.PushAsync(new AddIngrediets(product));
        }
    }
}
