using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace testeMOB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutosPage : ContentPage
    {
        public ProdutosPage()
        {
            InitializeComponent();
            using (var dados = new AcessoDB())
            {
                this.ListaProd.ItemsSource = dados.GetProd();
            }
        }
        protected void SalvarClicked(object sender, EventArgs e)
        {
            var produto = new Produto
            {
                Nome = this.NomeProd.Text,
                Tipo = this.TipoProd.Text,
                CDB= this.CodBProd.Text,
                Preco= this.PrecoProd.Text
            };

            using (var dados = new AcessoDB())
            {
                dados.InserirProduto(produto);
                this.ListaProd.ItemsSource = dados.GetProd();
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