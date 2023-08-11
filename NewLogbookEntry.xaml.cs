namespace PilotLogbook;

public partial class NewLogbookEntry : ContentPage
{
	PilotID id1;
	public NewLogbookEntry(PilotID id)
	{
		InitializeComponent();
		id1 = id;
	}
}