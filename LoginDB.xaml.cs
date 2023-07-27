using Microsoft.EntityFrameworkCore;

namespace PilotLogbook;

public partial class LoginDB : ContentPage
{


	public LoginDB()
	{
		InitializeComponent();

        foreach (var item in MainPage.MyDatabase.Pilots)
        {
            var capturedItem = item;
            Button button = new Button() { Text = $"{capturedItem.Login}", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            button.Clicked += (sender, e) => Button_Clicked(sender, e, capturedItem);
            LoginDBMainStack.Children.Add(button);
        }
        Button create = new Button() { Text = "Create a new account", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, BackgroundColor = Colors.CornflowerBlue };
        create.Clicked += Button_Create;
        LoginDBMainStack.Children.Add(create);
    }

    private async void Button_Clicked(object sender, EventArgs e, PilotID pid)
    {
        if (pid.Password == null)
        {
            MainPage.LogbookID = MainPage.MyDatabase.Logbooks.LastOrDefault().LogbookID;
            MainPage.RatingID = MainPage.MyDatabase.Ratings.LastOrDefault().RatingID;
            MainPage.SynthID = MainPage.MyDatabase.SynthethicFlights.LastOrDefault().SynthID;
            MainPage.MedicalID = MainPage.MyDatabase.MedicalCerts.LastOrDefault().MedicalID;

            MainPage.LogbookID = MainPage.LogbookID == null ? 1 : MainPage.LogbookID++;
            MainPage.RatingID = MainPage.RatingID == null ? 1 : MainPage.RatingID++;
            MainPage.SynthID = MainPage.SynthID == null ? 1 : MainPage.SynthID++;
            MainPage.MedicalID = MainPage.MedicalID == null ? 1 : MainPage.MedicalID;


            await Navigation.PushAsync(new MainTabbedPage(pid));
        }
        else
        {
            await Navigation.PushAsync(new LocalDBPassword(pid));
        }
        
    }

    private async void Button_Create(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateNewUser());
    }
}