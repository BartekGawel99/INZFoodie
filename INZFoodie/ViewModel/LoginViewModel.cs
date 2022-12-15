using INZFoodie.Model;
using INZFoodie.View;
using INZFoodie.View.Scanning;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace INZFoodie.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {

        public AsyncCommand LoginCommand { get; set; }
        public AsyncCommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new AsyncCommand(login);
            RegisterCommand = new AsyncCommand(register);
        }

        string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        async Task login()
        {
            var httpClient = new HttpClient();
            try
            {               
                var hashpassword = SHA512StringHash(password);
                User user = new User();
                user.username = username;
                user.password = hashpassword;
                var json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var resultJson = await httpClient.PostAsync("https://xn--infoodie-43b.azurewebsites.net/api/Login/Login", content);
                string result = resultJson.Content.ReadAsStringAsync().Result;
                if (!resultJson.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Problem", "OK");
                    return;
                }
                await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                await Xamarin.Essentials.SecureStorage.SetAsync("Id", result);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wszytskie pola muszą mieć wartość", "OK");
            }
        }
        async Task register()
        {
            var httpClient = new HttpClient();            
            try
            {
                var hashpassword = SHA512StringHash(password);
                User user = new User();
                user.username = username;
                user.password = hashpassword;
                var json = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");              
                var resultJson = await httpClient.PostAsync("https://xn--infoodie-43b.azurewebsites.net/api/Login/Register", content);
                await Application.Current.MainPage.DisplayAlert("Zarejestrowane", "Zaloguj się", "OK");
              
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Problem", "OK");

            }
        }

        public string SHA512StringHash(String input)
        {
            SHA512 shaM = new SHA512Managed();

            byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            input = sBuilder.ToString();
            return (input);
        }    
    }
}
