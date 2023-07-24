using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;     

namespace PilotLogbook;

public partial class MainPage : ContentPage
{
    public static MyDbContext MyDatabase;
    public static int LogbookID;
    public static int RatingID;
    public static bool IsLocal;
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
        MyDatabase = null;
        IsLocal = true;
        MyDatabase = new MyDbContext();
        if (Preferences.Default.Get("Saved",false))
        {
            Preferences.Default.Set("LocalDB", "Local");
        }
        MyDatabase.Database.EnsureCreated();
        MyDatabase.SaveChanges();

        Testing();




        await Navigation.PushAsync(new LocalLoginDB());
    }

    private void ExternalDBBtn_Clicked(object sender, EventArgs e)
    {
        MyDatabase = null;
        IsLocal = false;
        //This should be removed, add it in the database options page since we need to provide login/password for external database
        MyDatabase = new MyDbContext();
        if (Preferences.Default.Get("Saved", false))
        {
            Preferences.Default.Set("LocalDB", "External");
        }

        //Navigate to database options page so user can input ip, login, pass etc
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

    public static void Testing()
    {
        //Create
        try
        {
            MyDatabase.Pilots.Add(new PilotID() { Login = "Test", Password = "Test" });
        }
        catch (Exception ex)
        {
            //Can't add to database
        }

        //Read
        var Pilot = MyDatabase.Pilots.First(p => p.Login == "Test");
        if (Pilot != null)
        {
            try
            {
                //Update
                Pilot.Login = "Test2";
            }
            catch (Exception)
            {
                //Cant update
                throw;
            }
        }
        else
        {
            //Cant read
        }

        try
        {
            //Delete
            MyDatabase.Pilots.Remove(MyDatabase.Pilots.First(l => l.Login == "Test"));
        }
        catch (Exception e)
        {

            //Cant remove from database
        }
        MyDatabase.SaveChanges();
    }
}

