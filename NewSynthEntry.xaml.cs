namespace PilotLogbook;

public partial class NewSynthEntry : ContentPage
{
	PilotID id1;
	public List<SyntheticLogbook.SyntheticTrainingDevices> Devices { get; } = Enum.GetValues(typeof(SyntheticLogbook.SyntheticTrainingDevices)).Cast<SyntheticLogbook.SyntheticTrainingDevices>().ToList();
	public SyntheticLogbook.SyntheticTrainingDevices SelectedDevice;
    public NewSynthEntry(PilotID id)
	{
		InitializeComponent();
		id1 = id;
		BindingContext = this;
	}

    private void PickerSynthEntry_SelectedIndexChanged(object sender, EventArgs e)
    {
		SelectedDevice = Devices[PickerSynthEntry.SelectedIndex];
    }

    private async void btnSynthEntry_Clicked(object sender, EventArgs e)
    {
		uint ID = MainPage.SynthID.Value;
		DateTime date = SynthEntryDate.Date;
		date = date.Add(SynthEntryTime.Time);
		TimeSpan time = new TimeSpan(Int32.Parse(HoursEntry.Text), Int32.Parse(MinutesEntry.Text), Int32.Parse(SecondsEntry.Text));

		if (date.Date.Equals(DateTime.MinValue.Date) || PickerSynthEntry.SelectedItem == null || time == TimeSpan.Zero)
		{
            DisplayAlert("Error", "Make sure you put both date and flight information correctly", "OK");
        }
		else
		{

			try
			{
                MainPage.MyDatabase.SynthethicFlights.Add(new SyntheticLogbook(id1, ID, date, SelectedDevice, time));
				MainPage.MyDatabase.SaveChanges();
				MainPage.SynthID += 1;
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
}