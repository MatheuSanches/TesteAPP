using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testeMOB.Android;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testeMOB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        AcessoDB userData;
        public LoginPage()
        {
            InitializeComponent();
            userData = new AcessoDB();
            // Define o binding context
            this.BindingContext = this;
            // Define a propriedade
            this.IsBusy = false;
            //Define o evento Click do botão de login
            BtnLogin.Clicked += BtnLogin_Clicked;
            BtnRegistrar.Clicked += BtnRegistrar_Clicked;

        }
        //define a propriedade IsBusy como true
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //ativa o ActivityIndicator
            this.IsBusy = true;
            if (NomeUsuario.Text != null && Senha.Text != null)
            {
                var validData = userData.LoginValidate(NomeUsuario.Text, Senha.Text);
                if (validData)
                {
                    await Momento(5000);
                    Application.Current.MainPage = new Menu();
                }
                else
                {
                    this.IsBusy = false;
                    await DisplayAlert("Falha no Login", "Usuário ou Senha incorretos", "OK");
                }
            }
            else
            {
                this.IsBusy = false;
                await DisplayAlert("Campos em branco", "Coloque seu usuário e senha", "OK");
            }

            //await Momento(5000);
            //Application.Current.MainPage = new Menu();
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            //ativa o ActivityIndicator
            this.IsBusy = true;
            await Momento(5000);
            Application.Current.MainPage = new RegisterPage();
        }
        //Dá uma pausa de 5 segundos
        async Task Momento(int valor)
        {
            await Task.Delay(valor);
        }
    }
}