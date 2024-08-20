using LoginApp.ViewModels;

namespace LoginApp.Views
{
    public partial class SuccessPage : ContentPage
    {
        public SuccessPage(string username)
        {
            InitializeComponent();
            BindingContext = new SuccessViewModel(username);
        }
    }
}