using LoginApp.Views;

namespace LoginApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private  async void OnGoToSignInClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SignInPage");
        }
}

