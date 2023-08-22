namespace PilotLogbook;

public partial class NewMedicalEntry : ContentPage
{
	PilotID id1;
	public NewMedicalEntry(PilotID id)
	{
		InitializeComponent();
		id1 = id;
	}
    private async void btnMedEntry_Clicked(object sender, EventArgs e)
    {
        uint id = MainPage.MedicalID.Value;
        DateTime MedTime = MedEntryDate.Date;
        MedTime = MedTime.Add(MedEntryTime.Time);
        string mclass = ClassEntry.Text;
        DateTime FliTime = MedFlightEntryDate.Date;
        FliTime = FliTime.Add(MedFlightEntryTime.Time);
        DateTime InsTime = MedInsFlightEntryDate.Date;
        InsTime = InsTime.Add(MedInsFlightEntryTime.Time);

        if (MedTime.Date == DateTime.MinValue.Date || FliTime.Date == DateTime.MinValue.Date || InsTime.Date == DateTime.MinValue.Date || String.IsNullOrEmpty(mclass))
        {
            DisplayAlert("Error", "Make sure you put all dates and class correcly", "OK");
        }
        else
        {
            try
            {
                MainPage.MyDatabase.MedicalCerts.Add(new MedicalCertificates(id, id1, MedTime, mclass, FliTime, InsTime));
                MainPage.MyDatabase.SaveChanges();
                MainPage.MedicalID += 1;
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