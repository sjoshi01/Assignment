using LoginApp.ViewModels; 
namespace LoginApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is SignUpViewModel viewModel)
            {
                viewModel.ResetForm();
            }
        }
    }
}