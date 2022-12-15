using INZFoodie.Model;
using INZFoodie.ViewModel.Calculator.CalculatorMode;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel
{
    public class EditPersonalPage2ViewModel : BaseViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public AsyncCommand ResultCommand { get; }
        public AsyncCommand OKCommand { get; }
        public Personal personal2 { get; set; }
        protected bool IsClicked = false;
        public EditPersonalPage2ViewModel(Personal personal)
        {
            ResultCommand = new AsyncCommand(ResultTask);
            OKCommand = new AsyncCommand(Save);

            OnPropertyChanged(nameof(CpmTarget));
            OnPropertyChanged(nameof(ProteinResult));
            OnPropertyChanged(nameof(FatResult));
            OnPropertyChanged(nameof(CarbontesResult));

            personal2 = personal;
            protein = personal2.ProteinPer * 100;
            carbonates = personal2.CarbonatesPer * 100;
            fat = personal2.FatPer * 100;
        }

        double protein;
        public double Protein
        {
            get { return protein; }
            set { protein = value; }
        }
        double carbonates;
        public double Carbonates
        {
            get { return carbonates ; }
            set { carbonates = value; }
        }

        double fat;
        public double Fat
        {
            get { return fat ; }
            set { fat = value; }
        }
        string cpmTarget;
        public string CpmTarget
        {
            get
            {
                return $"{cpmTarget}";
            }
        }
        string proteinResult;
        public string ProteinResult
        {
            get
            {
                return $"{proteinResult}";
            }
        }
        string fatResult;
        public string FatResult
        {
            get
            {
                return $"{fatResult}";
            }
        }
        string carbontesResult;
        public string CarbontesResult
        {
            get
            {
                return $"{carbontesResult}";
            }
        }

        async Task ResultTask()
        {
            CalculatorViewModelcs vm = new CalculatorViewModelcs();

            personal2.CarbonatesPer = carbonates / 100;
            personal2.FatPer = fat / 100;
            personal2.ProteinPer = protein / 100;
            if (personal2.FatPer + personal2.CarbonatesPer + personal2.ProteinPer != 1)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Łączna wartość na wszytskich polach powinna wynieść 100", "OK");
                return;
            }
            IsClicked = true;
            personal2 = vm.PersonalCal(personal2);

            cpmTarget = personal2.CPMTarget;
            fatResult = personal2.Fat;
            carbontesResult = personal2.Carbonates;
            proteinResult = personal2.Protein;

            OnPropertyChanged(nameof(CpmTarget));
            OnPropertyChanged(nameof(ProteinResult));
            OnPropertyChanged(nameof(FatResult));
            OnPropertyChanged(nameof(CarbontesResult));
        }
        async Task Save()
        {
            if (!IsClicked)
            {
                await ResultTask();
            }
            personal2.SaveTime = DateTime.Now;
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(personal2);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                var resultJson = await httpClient.PutAsync($"https://xn--infoodie-43b.azurewebsites.net/api/Personel/" + personal2.Id, content);
                string result = resultJson.Content.ReadAsStringAsync().Result;

                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Błąd połaczenia z serwerem", "OK");
                return;
            }
        }
    }
}