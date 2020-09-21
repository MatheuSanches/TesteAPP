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
}