namespace LoginApp;
using LoginApp.Views;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new NavigationPage(new SignInPage());
	}
}