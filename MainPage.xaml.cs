using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;     

namespace PilotLogbook;

public partial class MainPage : ContentPage
{
    public static MyDbContext MyDatabase;
    public static uint? LogbookID;
    public static uint? RatingID;
    public static uint? SynthID;
    public static uint? MedicalID;
    public static bool IsLocal;
    public MainPage()
	{
		InitializeComponent();


        if (Preferences.Default.Get("LocalDB", "") == "Local")
        {
            LocalDBBtn_Clicked(this, EventArgs.Empty);
        }
        else if (Preferences.Default.Get("LocalDB", "") == "External") 
        {
            ExternalDBBtn_Clicked(this, EventArgs.Empty);
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
        else
        {
            Preferences.Default.Set("LocalDB", "");
        }
        MyDatabase.Database.EnsureCreated();
        MyDatabase.SaveChanges();
        Testing();
        await Navigation.PushAsync(new LoginDB());
    }

    private async void ExternalDBBtn_Clicked(object sender, EventArgs e)
    {
        MyDatabase = null;
        IsLocal = false;
        //TODO: This should be removed, add it in the database options page since we need to provide login/password for external database
        //MyDatabase = new MyDbContext();
        if (Preferences.Default.Get("Saved", false))
        {
            Preferences.Default.Set("LocalDB", "External");
        }
        else
        {
            Preferences.Default.Set("LocalDB", "");
        }

        await Navigation.PushAsync(new ExternalDatabaseLogin());
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
            MyDatabase.SaveChanges();
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
                Pilot.Password = "Test2";
                MyDatabase.SaveChanges();
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
            MyDatabase.Pilots.Remove(Pilot);
        }
        catch (Exception e)
        {

            //Cant remove from database
        }
        MyDatabase.SaveChanges();
    }
}

