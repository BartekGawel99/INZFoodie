using INZFoodie.ViewModel;
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
    public partial class EditPersonalPage : ContentPage
    {
        public EditPersonalPage(Model.Personal personal)
        {
            InitializeComponent();
            BindingContext = new EditPersonalPageViewModel(personal);
        }
    }
}