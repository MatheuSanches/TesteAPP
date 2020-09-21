using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testeMOB.Android;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testeMOB.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditClientesPage : ContentPage
    {
        public EditClientesPage()
        {
            InitializeComponent();
        }
        protected void EditarClicked(object sender, EventArgs e)
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
                dados.AtualizarCliente(cliente);
            }
        }

        protected void ApagarClicked(object sender, EventArgs e)
        {
            
        }
    }
}