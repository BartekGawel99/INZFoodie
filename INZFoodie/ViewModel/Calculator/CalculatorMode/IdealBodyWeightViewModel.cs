using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel.Calculator.CalculatorMode
{
    public  class IdealBodyWeightViewModel : BaseViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public AsyncCommand ShowInfoCommand { get; }
        public AsyncCommand IdealBodyMassResult { get; }
        public IdealBodyWeightViewModel()
        {

            IdealBodyMassResult = new AsyncCommand(Cpm);
            ShowInfoCommand = new AsyncCommand(Info);
            OnPropertyChanged(nameof(Result));

        }


        string patternValue;
        public string PatternValue
        {
            get { return patternValue; }
            set { patternValue = value; }
        }

        string height;
        public string Height
        {
            get { return height; }
            set { height = value; }
        }
        string sexValue;
        public string SexValue
        {
            get { return sexValue; }
            set { sexValue = value; }
        }

        private string result;
        public string Result
        {
            get
            {
                return $"{result}";
            }
        }

        async Task Cpm()
        {
            try
            {
                CalculatorViewModelcs vm = new CalculatorViewModelcs();
                result = vm.idealBodyWeight(height, sexValue , patternValue);
                OnPropertyChanged(nameof(Result));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wszytskie pola muszą mieć wartość", "OK");

            }

        }

        async Task Info()
        {
            string info = "\nBMI (Body Mass Index) pozwala osobie dorosłej, " +
                "bez większej masy mięśniowej, obliczyć prawidłową masa ciała. \n" +
                "Poniżej wyjaśnienie co dana wartość MOŻE oznaczać: \n \n" +
                "mniej niż 16 - wygłodzenie \n" +
                "16 - 16.99 - wychudzenie \n" +
                "17 - 18.49 - niedowaga \n" +
                "18.5 - 24.99 - wartość prawidłowa \n" +
                "25 - 29.99 - nadwaga \n" +
                "30 - 34.99 - I stopień otyłości \n" +
                "35 - 39.99 - II stopień otyłości \n" +
                "powyżej 40 - otyłość skrajna";

            await Application.Current.MainPage.DisplayAlert
                ("Po co liczyć?", info, "OK");
        }

    }
}
