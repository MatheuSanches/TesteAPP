using System;
using System.Globalization;
using System.Windows.Input;
using testeMOB.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace testeMOB
{
    public class MainPageViewModel : BaseViewModel
    {
        [System.Obsolete]
        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
    }
}