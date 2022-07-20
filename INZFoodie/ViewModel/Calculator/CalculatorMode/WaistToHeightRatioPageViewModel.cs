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
    internal class WaistToHeightRatioPageViewModel : BaseViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public AsyncCommand ShowInfoCommand { get; }
        public AsyncCommand CpmResult { get; }
        public WaistToHeightRatioPageViewModel()
        {

            CpmResult = new AsyncCommand(WTHipR);
            ShowInfoCommand = new AsyncCommand(Info);
            OnPropertyChanged(nameof(Result));

        }

        string age;
        public string Age
        {
            get { return age; }
            set { age = value;  }
        }
       
        string height;
        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        string waist;
        public string Waist
        {
            get { return waist; }
            set { waist = value; }
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

        async Task WTHipR()
        {
            try
            {
                CalculatorViewModelcs vm = new CalculatorViewModelcs();
                result = vm.waistToHeightRatio(sexValue, waist, height, age);
                OnPropertyChanged(nameof(Result));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wszytskie pola muszą mieć wartość", "OK");

            }

        }

        async Task Info()
        {
            string info = "\nWHtR jest to stosunek obwodu talii do wzrostu. Jest to wskaźnik oceniający stan odżywienia, " +
                "zaraz obok BMI oraz WHR. Pomiar ten bierze pod uwagę okolice brzucha (liczony obwód talii), czyli miejsce, " +
                "w którym gromadzi się najwięcej tkanki tłuszczowej. \n" +
                "Poniżej wyjaśnienie co dana wartość MOŻE oznaczać: \n \n" +
                "WHtR - normy u kobiet: \n \n" +
                ">0,8 - typ androidalny (jabłko) \n" +
                " <0,8 - typ gynoidalny (gruszka)  \n\n" +
                "WHtR - normy u mężczyzn:  \n\n" +
                ">1 - typ androidalny (jabłko) \n" +
                "<1 - typ gynoidalny (gruszka) \n";

            await Application.Current.MainPage.DisplayAlert
                ("Po co liczyć?", info, "OK");
        }

    }
}
