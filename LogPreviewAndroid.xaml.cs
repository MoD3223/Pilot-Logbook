namespace PilotLogbook;

public partial class LogPreviewAndroid : ContentPage
{
	internal LogPreviewAndroid(Logbook log)
	{
		InitializeComponent();
		lblID.Text = log.LogbookID.ToString();
		lblDate.Text = log.Date.ToString();
		lblMake.Text = log.AircraftType.ToString();
		lblIdent.Text = log.AircraftIdent.ToString();
		lblFrom.Text = log.RouteFrom.ToString();
		lblTo.Text = log.RouteTo.ToString();
		lblDepartureTime.Text = log.DepartureTime.ToString();
		lblArrivalTime.Text = log.ArrivalTime.ToString();
		lblFlightDuration.Text = log.FlightDuration.ToString();
		lblPilot.Text = log.PilotInCommand.ToString();
		lblSecondPilot.Text = log.SecondInCommand;
		lblDayLand.Text = log.Day.ToString();
		lblNightLand.Text = log.Night.ToString();
		lblSingleEngine.Text = log.SingleEngineLand.ToString();
		lblMultiEngine.Text = log.MultiEngineLand.ToString();
		if (log.EngineType == true)
		{
			lblEngine.Text = "Multi-Engine";
		}
		else if (log.EngineType == false)
		{
			lblEngine.Text = "Single-Engine";
		}
		lblStick.Text = log.StickTime.ToString();
		lblMultiPilot.Text = log.MultiPilotTime.ToString();
		lblNightFly.Text = log.NightFlyingTime.ToString();
		lblIFRFly.Text = log.IFRFlyingTime.ToString();
		lblPICFly.Text = log.PIC.ToString();
		lblCOPFly.Text = log.CoPilot.ToString();
		lblDualTime.Text = log.Dual.ToString();
		lblInsTime.Text = log.Instructor.ToString();
		lblCross.Text = log.CrossCountry.ToString();
		lblNotes.Text = log.NotesAndEndorsements.ToString();
	}
}