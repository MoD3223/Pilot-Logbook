namespace PilotLogbook;

public partial class LogbookAndroid : ContentPage
{
	PilotID id;
    public LogbookAndroid(PilotID pid)
	{
		InitializeComponent();
		id = pid;
		LoadButtons();
	}

	void LoadButtons()
	{
		foreach (var item in MainPage.MyDatabase.Logbooks)
		{
			if (item.pilot == id)
			{
				Button btn = new Button() { Text = $"{item.LogbookID}: {item.Date}", BindingContext= item };
				btn.Clicked += Button_Clicked;
				VertStack.Children.Add(btn);
			}
		}
		//Button DesktopView = new Button() { Text = "Switch to desktop view", BackgroundColor = Colors.CornflowerBlue, BindingContext = id };
  //      DesktopView.Clicked += DesktopView_Clicked;
  //      VertStack.Children.Add(DesktopView);
    }

    async void Button_Clicked(object sender, EventArgs e)
	{
		if (sender is Button btn && btn.BindingContext is Logbook log)
		{
			await Navigation.PushAsync(new LogPreviewAndroid(log));
		}
	}

	//async void DesktopView_Clicked(object sender, EventArgs e)
	//{
	//	if (sender is Button btn && btn.BindingContext is PilotID id)
	//	{
	//		//TODO: fix this later someday
	//		//forgot tabbed view doesn't work on android
	//		await Navigation.PushAsync(new NewRatingsEntry(id));
	//	}
	//}
}