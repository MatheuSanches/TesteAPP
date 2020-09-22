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
    public partial class ClientesPage : ContentPage
    {
        public ClientesPage()
        {
            InitializeComponent();

            using (var dados = new AcessoDB())
            {
                this.ListaCliente.ItemsSource = dados.GetClientes();
            }
        }
        protected void SalvarClicked(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                Nome = this.NomeCliente.Text,
                Email = this.EmailCliente.Text,
                Usuario = this.UsuarioCliente.Text,
                Senha = this.SenhaCliente.Text
            };

            using (var dados = new AcessoDB())
            {
                dados.InserirCliente(cliente);
                this.ListaCliente.ItemsSource = dados.GetClientes();
            }
            //
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
