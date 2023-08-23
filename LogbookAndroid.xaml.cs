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
		Button AddNewLogbookAndroid = new Button() { Text = "Add new logbook", BackgroundColor = Colors.CornflowerBlue, BindingContext = id };
        AddNewLogbookAndroid.Clicked += AddNewLogbookAndroid_Clicked;
		VertStack.Children.Add(AddNewLogbookAndroid);
    }

    private void AddNewLogbookAndroid_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new NewLogbookEntry(id));
    }

    async void Button_Clicked(object sender, EventArgs e)
	{
		if (sender is Button btn && btn.BindingContext is Logbook log)
		{
			await Navigation.PushAsync(new LogPreviewAndroid(log));
		}
	}
}