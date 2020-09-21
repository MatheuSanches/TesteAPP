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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            //dhttps://cursos.alura.com.br/forum/topico-projeto-aula-2-erro-no-initializecomponent-94604
            InitializeComponent();
            // Define o binding context
            this.BindingContext = this;
            // Define a propriedade
            this.IsBusy = false;
            //Define o evento Click do botão de 
        }
        //define a propriedade IsBusy como true
        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            //ativa o ActivityIndicator
            this.IsBusy = true;
            var registro = new Usuario
            {
                Nome = this.Nome.Text,
                Email = this.Email.Text,
                Usu = this.NomeUsuario.Text,
                Senha = this.Senha.Text
            };
            using (var dados = new AcessoDB())
            {
                dados.AddUser(registro);

            }
            await Momento(1000);
            Application.Current.MainPage = new LoginPage();

        }

        private async void BtnReturn_Clicked(object sender, EventArgs e)
        {
            //ativa o ActivityIndicator
            await Momento(1000);
            Application.Current.MainPage = new LoginPage();
        }
        //Dá uma pausa de 5 segundos
        async Task Momento(int valor)
        {
            await Task.Delay(valor);
        }
    }
}