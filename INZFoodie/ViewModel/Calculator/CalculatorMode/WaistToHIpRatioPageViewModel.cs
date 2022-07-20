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
    public class WaistToHIpRatioPageViewModel : BaseViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public AsyncCommand ShowInfoCommand { get; }
        public AsyncCommand CpmResult { get; }
        public WaistToHIpRatioPageViewModel()
        {

            CpmResult = new AsyncCommand(WTHR);
            ShowInfoCommand = new AsyncCommand(Info);
            OnPropertyChanged(nameof(Result));

        }

        string hip;
        public string Hip
        {
            get { return hip; }
            set { hip = value; }
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

        async Task WTHR()
        {
            try
            {
                CalculatorViewModelcs vm = new CalculatorViewModelcs();
                result = vm.waistToHipRatio(sexValue, waist, hip);
                OnPropertyChanged(nameof(Result));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wszytskie pola muszą mieć wartość", "OK");

            }

        }

        async Task Info()
        {
            string info = "\nWykorzystując kalkulator WHR, można dowiedzieć się," +
                " czy stosunek obwodu bioder do talii jest prawidłowy, a na jego podstawie określić typ sylwetki, który posiadamy. \n" +
                " \n" +
                "WHR - normy u kobiet: \n \n" +
                ">0,8 - typ androidalny (jabłko) \n" +
                " <0,8 - typ gynoidalny (gruszka)  \n\n" +
                "WHR - normy u mężczyzn:  \n\n" +
                ">1 - typ androidalny (jabłko) \n" +
                "<1 - typ gynoidalny (gruszka) \n";


            await Application.Current.MainPage.DisplayAlert
                ("Po co liczyć?", info, "OK");
        }

    }
}
