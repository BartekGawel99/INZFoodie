using INZFoodie.ViewModel;
using INZFoodie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie.View.Personal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPersonalPage2 : ContentPage
    {
        public AddPersonalPage2(Model.Personal per)
        {
            InitializeComponent();
            BindingContext  = new AddPersonalPage2ViewModel(per);
        }
    }
}