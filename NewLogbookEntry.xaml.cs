namespace PilotLogbook;

public partial class NewLogbookEntry : ContentPage
{
    public bool engine { get; set; }
    public bool cross { get; set; }
	PilotID id1;
	public NewLogbookEntry(PilotID id)
	{
		InitializeComponent();
		id1 = id;

        BindingContext = this;
	}

    private void btnLogbookEntry_Clicked(object sender, EventArgs e)
    {
        uint ID = MainPage.LogbookID.Value;
        DateTime DepartureDate = LogbookEntryDeptDate.Date;
        DepartureDate = DepartureDate.Add(LogbookEntryDeptTime.Time);
        DateTime ArrivalDate = LogbookEntryArrDate.Date;
        ArrivalDate = ArrivalDate.Add(LogbookEntryArrTime.Time);
        TimeSpan StickTime = new TimeSpan(Int32.Parse(HoursStickEntry.Text), Int32.Parse(MinutesStickEntry.Text), 0);
        TimeSpan MultiPilotTime = new TimeSpan(Int32.Parse(HoursMultiPilotEntry.Text), Int32.Parse(MinutesMultiPilotEntry.Text), 0);
        TimeSpan NightFlyingTime = new TimeSpan(Int32.Parse(HoursNightEntry.Text), Int32.Parse(MinutesNightEntry.Text), 0);
        TimeSpan IFRFlyingTime = new TimeSpan(Int32.Parse(HoursIFREntry.Text), Int32.Parse(MinutesIFREntry.Text), 0);
        TimeSpan PICFlyingTime = new TimeSpan(Int32.Parse(HoursPICEntry.Text), Int32.Parse(MinutesPICEntry.Text), 0);
        TimeSpan COPilotFlyingTime = new TimeSpan(Int32.Parse(HoursCOPEntry.Text), Int32.Parse(MinutesCOPEntry.Text), 0);
        TimeSpan DualFlyingTime = new TimeSpan(Int32.Parse(HoursDualEntry.Text), Int32.Parse(MinutesDualEntry.Text), 0);
        TimeSpan InsFlyingTime = new TimeSpan(Int32.Parse(HoursInsEntry.Text), Int32.Parse(MinutesInsEntry.Text), 0);
        TimeSpan TotalFlightDuration = ArrivalDate - DepartureDate;


        if (DepartureDate.Date == DateTime.MinValue.Date || ArrivalDate.Date == DateTime.MinValue.Date || StickTime > TotalFlightDuration || MultiPilotTime > TotalFlightDuration || NightFlyingTime > TotalFlightDuration || IFRFlyingTime > TotalFlightDuration || PICFlyingTime > TotalFlightDuration || COPilotFlyingTime > TotalFlightDuration || DualFlyingTime > TotalFlightDuration || InsFlyingTime > TotalFlightDuration)
        {
            DisplayAlert("Error", "Make sure you put both dates and times correctly", "OK");
        }
        else
        {
            try
            {
                MainPage.MyDatabase.Logbooks.Add(new Logbook(ID, id1, DepartureDate, ArrivalDate,TotalFlightDuration, uint.Parse(LogbookEntryDayLandings.Text), uint.Parse(LogbookEntryNightLandings.Text), uint.Parse(LogbookEntrySingleLandings.Text), uint.Parse(LogbookEntryMultiLandings.Text), default, $"{LogbookEntryMake.Text} {LogbookEntryModel.Text}", LogbookEntryIdent.Text, LogbookEntryRouteFrom.Text, LogbookEntryRouteTo.Text, StickTime, LogbookEntryPilotInCommand.Text, LogbookEntrySecondInCommand.Text, cross, engine, PICFlyingTime, COPilotFlyingTime, DualFlyingTime, InsFlyingTime, LogbookEntryNotes.Text, MultiPilotTime, NightFlyingTime, IFRFlyingTime));
                MainPage.MyDatabase.SaveChanges();
                MainPage.LogbookID += 1;
                Navigation.PopToRootAsync();
            }
            catch (Exception)
            {
                MainPage.MyDatabase.ChangeTracker.Clear();
                DisplayAlert("Error", "Make sure you put all data correctly", "OK");
                Navigation.PopToRootAsync();
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