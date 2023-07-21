using Microsoft.EntityFrameworkCore;

namespace PilotLogbook;

public partial class LocalLoginDB : ContentPage
{


	public LocalLoginDB()
	{
		InitializeComponent();

        foreach (var item in MainPage.MyDatabase.Pilots)
        {
            var capturedItem = item;
            Button button = new Button() { Text = $"{capturedItem.Login}", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            button.Clicked += (sender, e) => Button_Clicked(sender, e, capturedItem);
            LocalDBMainStack.Children.Add(button);
        }
        Button create = new Button() { Text = "Create a new account", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, BackgroundColor = Colors.CornflowerBlue };
        LocalDBMainStack.Children.Add(create);
    }

    private async void Button_Clicked(object sender, EventArgs e, PilotID pid)
    {
        /*
        if (sender is int a && a.ToString() == "5")
        {
        //another exmaple instead of adding to clicked void
        }
        */
        if (pid.Password == null)
        {
            await Navigation.PushAsync(new TabbedLogbook(pid));
        }
        else
        {
            //TODO: Add navigation to password page;
        }
        
    }


}