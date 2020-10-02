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
            //! adicione o Plugin.Media;
            await CrossMedia.Current.Initialize();

            // Se você quiser tirar uma foto use isso:
            // if(!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
            // Se você quiser selecionar da galeria use isso:
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Sem suporte", "Seu ceular não suporta esta funcionalidade", "Ok");
                return;
            }

            //! added using Plugin.Media.Abstractions;
            // Se você quiser tirar uma foto use StoreCameraMediaOptions ao invés de PickMediaOptions
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            // Se você quiser tirar uma foto use TakePhotoAsync ao invés de PickPhotoAsync
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