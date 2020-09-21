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
                Chat.Open("+554432287571");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}