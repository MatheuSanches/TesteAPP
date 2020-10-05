using Xamarin.Forms;
using System;
using testeMOB.Android;

namespace testeMOB
{
    public partial class UsuariosPage : ContentPage
    {
        public UsuariosPage()
        {
            InitializeComponent();
            AcessoDB userData = new AcessoDB();
            var sourceData = userData.GetUsers();
            listUser.ItemsSource = sourceData;
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