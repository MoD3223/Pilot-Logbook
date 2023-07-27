namespace PilotLogbook;

public partial class MainTabbedPage : TabbedPage
{
	public MainTabbedPage(PilotID ID)
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        Navigation.PopAsync();
        return true;
    }
}