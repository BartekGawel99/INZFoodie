using INZFoodie.View.Calculator.CalculatorMode;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel.Calculator
{
    public class CalculatorPageViewModel 
    {
        public AsyncCommand ShowInfoCommand { get; }
        public AsyncCommand CpmCommand { get; }
        public AsyncCommand BmiCommand { get;  }
        public AsyncCommand IdealBodyWeightCommand { get; }
        public AsyncCommand HarrisCommand { get; }
        public AsyncCommand MiffinCommand { get; }
        public AsyncCommand LeanBodyMassCommand { get; }
        public AsyncCommand WTHeightCommand { get; }
        public AsyncCommand WTHipCommand { get; }
        public AsyncCommand GlycemicCommand { get; }
        public CalculatorPageViewModel()
        {
            BmiCommand = new AsyncCommand(BMI);
            CpmCommand = new AsyncCommand(CPM);
            IdealBodyWeightCommand = new AsyncCommand(IdealBodyWeight);
            HarrisCommand = new AsyncCommand(Harris);
            MiffinCommand = new AsyncCommand(Miffin);
            LeanBodyMassCommand = new AsyncCommand(LeanBodyMass);
            WTHeightCommand = new AsyncCommand(WTHeight);
            WTHipCommand = new AsyncCommand(WTHip);
            GlycemicCommand = new AsyncCommand(Glycemic);
            ShowInfoCommand = new AsyncCommand(Info);
        }

        async Task BMI()
        {
            var route = $"{nameof(BMIPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task CPM()
        {
            var route = $"{nameof(CpmPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task IdealBodyWeight()
        {
            var route = $"{nameof(IdealBodyWeightPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task Harris()
        {
            var route = $"{nameof(HarrisPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task Miffin()
        {
            var route = $"{nameof(MiffinPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task LeanBodyMass()
        {
            var route = $"{nameof(LeanBodyMassPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task WTHeight()
        {
            var route = $"{nameof(WaistToHeightRatioPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task WTHip()
        {
            var route = $"{nameof(WaistToHipRatioPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task Glycemic()
        {
            var route = $"{nameof(GlycemicLoadPage)}";
            await Shell.Current.GoToAsync(route);
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
