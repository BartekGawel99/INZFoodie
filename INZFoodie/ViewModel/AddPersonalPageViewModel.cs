using INZFoodie.Model;
using INZFoodie.View.Personal;
using INZFoodie.ViewModel.Calculator.CalculatorMode;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel
{
    public  class AddPersonalPageViewModel : BaseViewModel
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        public AsyncCommand ResultCommand { get; }

        public AddPersonalPageViewModel()
        {
            ResultCommand = new AsyncCommand(per);
            OnPropertyChanged(nameof(Result));
        }

        string age;
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        string ppmValue;
        public string TargetValue
        {
            get { return ppmValue; }
            set { ppmValue = value; }
        }

        string height;
        public string Height
        {
            get { return height; }
            set { height = value; }
        }
        string mass;
        public string Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        string sexValue;
        public string SexValue
        {
            get { return sexValue; }
            set { sexValue = value; }
        }
        string palValue;
        public string PalValue
        {
            get { return palValue; }
            set { palValue = value; }
        }
        private string result;
        public string Result
        {
            get
            {
                return $"{result}";
            }
        }

        async Task per()
        {
            if(Height == null  || PalValue == null || Age == null || SexValue == null || Mass == null || TargetValue == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wszystkie pola musza być zapełnione", "OK");
                return;
            }
            if (Height == "" || PalValue == "" || Age == "" || SexValue == "" || Mass == "" || TargetValue == "")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wszystkie pola musza być zapełnione", "OK");
                return;
            }
            try
            {
                Personal personal = new Personal();
                var userId = Xamarin.Essentials.SecureStorage.GetAsync("Id").Result;
                userId = userId.Replace("\"", "").ToString();
                personal.IdUser = Guid.Parse(userId);
                personal.Mass = mass;
                personal.Age = age;
                personal.Height = height;
                personal.Target = TargetValue;
                personal.Pal = palValue;
                personal.Gender = sexValue;

                await Application.Current.MainPage.Navigation.PushAsync(new AddPersonalPage2(personal));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}
