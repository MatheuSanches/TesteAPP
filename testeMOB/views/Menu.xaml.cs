using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testeMOB.views;
using testeMOB.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testeMOB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }
        public Menu()
        {
            InitializeComponent();
            //AcessoDB userData = new AcessoDB();
            //NavigationPage.SetHasBackButton(this, false);
            //var sourceData = userData.GetUsers();
            //listUser.ItemsSource = sourceData;
            MenuList = new List<MasterPageItem>
            {
                // incluindo items de menu e definindo : title ,page and icon
                new MasterPageItem()
                {
                    Title = "Home",
                    Icon = "solo1.png",
                    TargetType =
typeof(MainPage)
                },
                new MasterPageItem()
                {
                    Title = "Clientes",
                    Icon = "solo3.png",
                    TargetType =
typeof(ClientesPage)
                },
                new MasterPageItem()
                {
                    Title = "Produtos",
                    Icon = "Beru_Chibi.png",
                    TargetType =
typeof(ProdutosPage)
                },
                new MasterPageItem()
                {
                    Title = "Usuarios",
                    Icon = "solo4.png",
                    TargetType =
typeof(UsuariosPage)
                },
                new MasterPageItem()
                {
                    Title = "Suporte",
                    Icon = "solo2.png",
                    TargetType =
typeof(Suporte)
                },
                new MasterPageItem()
                {
                    Title = "Galeria",
                    Icon = "solo5.png",
                    TargetType =
typeof(ImageWrapLayoutPage)
                },
                new MasterPageItem()
                {
                    Title = "Galeria",
                    Icon = "solo6.png",
                    TargetType =
typeof(Views.ChatPage)
                }
            };
            // Configurando o ItemSource fpara o ListView na MainPage.xaml
            paginaMestreList.ItemsSource = MenuList;
            // navegação inicial
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
        }
        // Evento para a seleção de item no menu
        // trata a seleção do usuário no ListView

        //AcessoDB userData = new AcessoDB();
        //public UsersListPage()
        //{
        //    InitializeComponent();
        //    NavigationPage.SetHasBackButton(this, false);
        //    var sourceData = userData.GetUsers();
        //    listUser.ItemsSource = sourceData;
        //}
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}