namespace PilotLogbook;

public partial class NewRatingsEntry : ContentPage
{
	PilotID id1;
	public NewRatingsEntry(PilotID id)
	{
		InitializeComponent();
		id1 = id;
	}

    private async void btnAddRating_Clicked(object sender, EventArgs e)
    {
		uint ID = MainPage.RatingID.Value;
		DateTime Date = RatingsEntryDate.Date;
		Date = Date.Add(RatingsEntryTime.Time);
		string Rating = RatingsEntryRating.Text;

		if (Date.Date.Equals(DateTime.MinValue.Date) || Rating == null)
		{
			DisplayAlert("Error", "Make sure you put both date and rating correctly", "OK");
		}
		else
		{
			try
			{
                MainPage.MyDatabase.Ratings.Add(new Ratings(ID, id1, Date, Rating));
                MainPage.MyDatabase.SaveChanges();
                MainPage.RatingID += 1;
                Navigation.PopToRootAsync();
            }
			catch (Exception)
			{
                MainPage.MyDatabase.ChangeTracker.Clear();
                DisplayAlert("Error", "Make sure you put all data correctly", "OK");
                await Navigation.PopToRootAsync();
			}
        }
    }

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        Navigation.PopAsync();
        return true;
    }
}