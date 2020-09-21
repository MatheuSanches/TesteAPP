using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testeMOB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MainPage());
        }


        private void GoPage1(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new ClientesPage());
            IsPresented = false;
        }
        private void GoPage2(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new ProdutosPage());
            IsPresented = false;
        }
    }
}