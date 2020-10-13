using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using testeMOB.models;
using Xamarin.Forms;

namespace testeMOB
{
    public partial class ImageWrapLayoutPage : ContentPage
    {
        HttpClient _client;
        public ImageWrapLayoutPage()
        {
            InitializeComponent();
            _client = new HttpClient();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var images = await GetImageListAsync();
            if (images != null)
            {
                foreach (var photo in images.Photos)
                {
                    var image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(photo))
                    };
                    wrapLayout.Children.Add(image);
                }
            }
        }

        async Task<ImageList> GetImageListAsync()
        {
            try
            {
                string requestUri = "https://github.com/MatheuSanches/TesteAPP/blob/master/Image/stock.json";
                //https://raw.githubusercontent.com/MatheuSanches/TesteAPP/master/Image/ImageList.json#
                //"https://raw.githubusercontent.com/MatheuSanches/TesteAPP/master/Images/stock/"
                string result = await _client.GetStringAsync(requestUri);
                return JsonConvert.DeserializeObject<ImageList>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
            }

            return null;
        }
    }
}
