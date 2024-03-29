﻿using INZFoodie.Model;
using INZFoodie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INZFoodie.View.Scanning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerResult : ContentPage
    {
        public BarcodeScannerResult(Model.Product product)
        {
            InitializeComponent();
            BindingContext = new ScanningResultViewModel(product);
        }


    }
}