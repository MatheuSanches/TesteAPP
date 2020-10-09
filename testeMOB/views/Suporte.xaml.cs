using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace testeMOB.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Suporte : ContentPage
    {
        public Suporte()
        {
            InitializeComponent();
        }

        private async void Send(object sender, EventArgs e)
        {
            try
            {
                Chat.Open("+5544991097779");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Sair", "Tem certeza que deseja sair?", "Sim", "Não");
            if (resposta)
            {
                Application.Current.MainPage = new LoginPage();
            }
        }
    }
}