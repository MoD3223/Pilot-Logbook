using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;     

namespace PilotLogbook;

public partial class MainPage : ContentPage
{
    //TODO: Move this down
    public static MyDbContext MyDatabase = new MyDbContext();
    public static int LogbookID;
    public static int RatingID;
    public MainPage()
	{
		InitializeComponent();
        LogbookID = Preferences.Default.Get("LogbookID", -1);
        RatingID = Preferences.Default.Get("RatingID", -1);



        if (Preferences.Default.Get("LocalDB", "") == "Local")
        {
            LocalDBBtn_Clicked(this, new EventArgs());
        }
        else if (Preferences.Default.Get("LocalDB", "") == "External") 
        {
            ExternalDBBtn_Clicked(this, new EventArgs());
        }
    }

    private async void LocalDBBtn_Clicked(object sender, EventArgs e)
    {
        if (Preferences.Default.Get("Saved",false))
        {
            Preferences.Default.Set("LocalDB", "Local");
        }
        MyDatabase.Database.EnsureCreated();
        MyDatabase.SaveChanges();

        //For testing purposes, remove before final product
        var Test = MyDatabase.Pilots.FirstOrDefault();
        if (Test == null)
        {
            MyDatabase.Pilots.Add(new PilotID() { Login = "Admin", Password = "Admin" });
        }
        MyDatabase.SaveChanges();
        //if (LogbookID == -1)
        //{
        //    //TODO: Finish
        //    //var Logbook = new Logbook { }
        //    var Check = MyDatabase.Logbooks.Where(l => l.LogbookID == 0).ToList();
        //    if (Check.Count == 0)
        //    {
        //        //List is empty
        //        throw new Exception("ERROR: Can't add items to database");
        //    }
        //    else
        //    {
        //        Preferences.Default.Set("LogbookID", MyDatabase.Logbooks.Count());
        //    }
        //}
        //if (RatingID == -1)
        //{
        //    //TODO: Finish
        //    //var Rating = new Ratings { }
        //    var Check = MyDatabase.Rates.Where(r => r.RatingID == 0).ToList();
        //    if (Check.Count == 0)
        //    {
        //        //List is empty, throw error
        //        throw new Exception("ERROR: Can't add items to database");
        //    }
        //    else
        //    {
        //        Preferences.Default.Set("RatingID", MyDatabase.Rates.Count());
        //    }
        //}







        await Navigation.PushAsync(new LocalLoginDB());
    }

    private void ExternalDBBtn_Clicked(object sender, EventArgs e)
    {
        if (Preferences.Default.Get("Saved", false))
        {
            Preferences.Default.Set("LocalDB", "External");
        }
    }

    private void SaveDBChoiceChkB_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (SaveDBChoiceChkB.IsChecked)
        {
            Preferences.Default.Set("Saved", true);
        }
        else
        {
            Preferences.Default.Set("Saved", false);
        }
    }
}

