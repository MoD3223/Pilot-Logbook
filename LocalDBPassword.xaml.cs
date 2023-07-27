namespace PilotLogbook;

public partial class LocalDBPassword : ContentPage
{
	public static int Tries;
	public LocalDBPassword(PilotID pid)
	{
		InitializeComponent();
		Button button = new Button() { Text = "Login", BindingContext = pid };
		button.Clicked += btnEnterPassword_Clicked;
		StackLayout.Children.Add(button);
	}

    private void btnEnterPassword_Clicked(object sender, EventArgs e)
    {
		if (sender is Button b && b.BindingContext is PilotID pilot && pilot.Password == PasswordEntry.Text)
		{
            Tries = 0;
            PasswordEntry.Text = "";
            Navigation.PushAsync(new MainTabbedPage(pilot));
			//TODO: Fix unhandled exception
		}
		else
		{
			Tries++;
			lblName.Text = $"Wrong Password! Remaining tries: {3 - Tries}";
			if (Tries == 3)
			{
				Environment.Exit(0);
			}
		}
    }
}