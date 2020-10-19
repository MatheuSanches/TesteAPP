using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace testeMOB.Models
{
    public class ChatPageViewModel : BaseViewModel
    {

        public ObservableRangeCollection<Message> ListMessages { get; }
        public ICommand SendCommand { get; set; }

        public ChatPageViewModel()
        {

            ListMessages = new ObservableRangeCollection<Message>();

            SendCommand = new Command(() =>
            {
                if (!String.IsNullOrWhiteSpace(OutText))
                {
                    var message = new Message
                    {
                        Text = OutText,
                        IsTextIn = false,
                        MessageDateTime = DateTime.Now
                    };


                    ListMessages.Add(message);
                    OutText = "";
                }

            });

        }


        public string OutText
        {
            get { return _outText; }
            set { SetProperty(ref _outText, value); }
        }
        string _outText = string.Empty;
    }
}