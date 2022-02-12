using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JsonApp1
{
    public partial class MainPage : ContentPage
    {
        private ColorsViewModel colorsviewmodel;
        public MainPage()
        {
            InitializeComponent();
            colorsviewmodel = new ColorsViewModel();
            // установка контекста данных
            this.BindingContext = colorsviewmodel;
        }
    }
}
