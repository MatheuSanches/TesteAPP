
using System.Windows.Input;
using Xamarin.Forms;
namespace XF_Labelink
{
    public class MainPageViewModel
    {
        [System.Obsolete]
        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
    }
}