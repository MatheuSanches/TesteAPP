using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;

namespace testeMOB
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new testeMOB.MainPageViewModel();
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Sair", "Tem certeza que deseja sair?", "Sim","Não");
            if (resposta)
            {
                Application.Current.MainPage = new LoginPage();
            }
        }
    }
}