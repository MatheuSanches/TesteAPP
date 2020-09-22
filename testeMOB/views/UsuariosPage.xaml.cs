using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testeMOB

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuariosPage : ContentPage
    {
        AcessoDB userData = new AcessoDB();
        public UsuariosPage()
        {
            InitializeComponent();
            var sourceData = userData.GetUsers();
            listUser.ItemsSource = sourceData;
        }
    }
    //public async void MenuItem_OnClicked(object sender, EventArgs e)
    //{
    //    var resposta = await DisplayAlert("Sair", "Tem certeza que deseja sair?", "Sim", "Não");
    //    if (resposta)
    //    {
    //        Application.Current.MainPage = new LoginPage();
    //    }
    //}
}