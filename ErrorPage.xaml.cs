namespace PilotLogbook;

public partial class ErrorPage : ContentPage
{
	public ErrorPage()
	{
		InitializeComponent();
		DisplayAlert("Error", "Something went wrong, please try again", "OK");
		Navigation.PushAsync(new MainPage());
        Navigation.PopToRootAsync();
    }

	public ErrorPage(string errorMessage)
	{
		InitializeComponent();
		DisplayAlert("Error", errorMessage, "OK");
		Navigation.PushAsync(new MainPage());
		Navigation.PopToRootAsync();
	}
}