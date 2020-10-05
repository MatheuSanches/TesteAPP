using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testeMOB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        public GalleryPage()
        {
            InitializeComponent();
        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Sem suporte", "Seu ceular não suporta esta funcionalidade", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
        
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImage == null)
            {
                await DisplayAlert("Error", "Não foi possível pegar a imagem, tente novamante", "Ok");
                return;
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }
    }
}

//http://www.macoratti.net/20/03/xf_lvmvvm1.htm
//https://github.com/poz1/Poz1.ImageGallery/blob/master/Poz1.ImageGallery/Poz1.ImageGallery/MainPage.xaml
//https://docs.microsoft.com/pt-br/xamarin/xamarin-forms/user-interface/layouts/custom