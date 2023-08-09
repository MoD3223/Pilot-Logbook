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
        Button delete = new Button() { Text = "Delete existing account", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, BackgroundColor = Colors.CornflowerBlue };
        delete.Clicked += Delete_Clicked;
        LoginDBMainStack.Children.Add(delete);
    }

    

    private async void Button_Clicked(object sender, EventArgs e, PilotID pid)
    {
        if (sender is Button btn)
        {
            if (btn.BackgroundColor == Colors.Red)
            {
                bool result = await DisplayAlert("Are you sure?", "Do you want to delete this user?", "YES", "NO");
                if (result)
                {
                    MainPage.MyDatabase.Pilots.Remove(pid);
                    MainPage.MyDatabase.SaveChanges();
                    await Navigation.PushAsync(new LoginDB());
                    Navigation.RemovePage(this);
                }
            }
            else
            {
                MainPage.LogbookID = MainPage.MyDatabase.Logbooks.OrderBy(l => l.LogbookID).LastOrDefault()?.LogbookID;
                MainPage.RatingID = MainPage.MyDatabase.Ratings.OrderBy(r => r.RatingID).LastOrDefault()?.RatingID;
                MainPage.SynthID = MainPage.MyDatabase.SynthethicFlights.OrderBy(s => s.SynthID).LastOrDefault()?.SynthID;
                MainPage.MedicalID = MainPage.MyDatabase.MedicalCerts.OrderBy(m => m.MedicalID).LastOrDefault()?.MedicalID;

                MainPage.LogbookID = MainPage.LogbookID == null ? 1 : MainPage.LogbookID++;
                MainPage.RatingID = MainPage.RatingID == null ? 1 : MainPage.RatingID++;
                MainPage.SynthID = MainPage.SynthID == null ? 1 : MainPage.SynthID++;
                MainPage.MedicalID = MainPage.MedicalID == null ? 1 : MainPage.MedicalID;




                if (pid.Password == null)
                {
#if WINDOWS
                    await Navigation.PushAsync(new MainTabbedPage(pid));

#endif

#if ANDROID
            await Navigation.PushAsync(new LogbookAndroid(pid));
#endif
                }
                else
                {
                    await Navigation.PushAsync(new LocalDBPassword(pid));
                }
            }
        }
        
        
    }

    private async void Button_Create(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateNewUser());
    }
    private void Delete_Clicked(object sender, EventArgs e)
    {
        foreach (var item in LoginDBMainStack.Children)
        {
            if (item is Button btn)
            {
                if (btn.BackgroundColor == Colors.Red)
                {
                    btn.BackgroundColor = Colors.White;
                }
                else if (btn.BackgroundColor != Colors.CornflowerBlue)
                {
                    btn.BackgroundColor = Colors.Red;
                }
                
            }
        }
    }

}