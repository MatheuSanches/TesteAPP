using testeMOB;
using testeMOB.Models;
using Xamarin.Forms;

namespace testeMOB.Views
{
    public partial class ChatPage : ContentPage
    {
        ChatPageViewModel vm;
        public ChatPage()
        {
            InitializeComponent();

            BindingContext = vm = new ChatPageViewModel();


            vm.ListMessages.CollectionChanged += (sender, e) =>
            {
                var target = vm.ListMessages[vm.ListMessages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            };
        }
    }
}