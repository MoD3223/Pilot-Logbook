
namespace PilotLogbook;

public partial class MainTabbedPage : TabbedPage
{
    int tappedRow;
    bool visible;
    bool reversed;
    Button delete;
    PilotID id1;
    public MainTabbedPage(PilotID ID)
    {
        InitializeComponent();
        id1 = ID;
        LoadLogbooks();
        LoadRatings();

    }

    void LoadLogbooks()
    {

        var LogbooksList = new List<Logbook>();
        foreach (var item in MainPage.MyDatabase.Logbooks)
        {
            if (id1 == item.pilot)
            {
                LogbooksList.Add(item);
            }
        }
        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnTapped(s, e, this.MainGrid);
        MainGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        MainGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        int row = 0;
        foreach (var item in LogbooksList)
        {
            row++;
            MainGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
            for (int i = 0; i < 26; i++)
            {
                //Adding border
                Border br = new Border();
                br.StrokeThickness = 1;
                MainGrid.SetRow(br, row);
                MainGrid.SetColumn(br, i);
                MainGrid.Children.Add(br);
                //Adding label
                Label lbl = new Label();
                switch (i)
                {
                    case 0:
                        lbl.Text = item.LogbookID.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 1:
                        lbl.Text = item.Date.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 2:
                        lbl.Text = item.AircraftType;
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 3:
                        lbl.Text = item.AircraftIdent;
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 4:
                        lbl.Text = item.RouteFrom;
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 5:
                        lbl.Text = item.RouteTo;
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 8:
                        lbl.Text = item.FlightDuration.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 9:
                        lbl.Text = item.PilotInCommand;
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 10:
                        lbl.Text = item.SecondInCommand;
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;

                    case 6:
                        lbl.Text = item.DepartureTime.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 7:
                        lbl.Text = item.ArrivalTime.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 11:
                        lbl.Text = item.Day.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 12:
                        lbl.Text = item.Night.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 13:
                        lbl.Text = item.SingleEngineLand.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 14:
                        lbl.Text = item.MultiEngineLand.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 15:
                        if (item.EngineType == true)
                        {
                            lbl.Text = "Multi-Engine";
                        }
                        else if (item.EngineType == false)
                        {
                            lbl.Text = "Single-Engine";
                        }
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 16:
                        lbl.Text = item.StickTime.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 17:
                        lbl.Text = item.MultiPilotTime.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 18:
                        lbl.Text = item.NightFlyingTime.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 19:
                        lbl.Text = item.IFRFlyingTime.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 20:
                        lbl.Text = item.PIC.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 21:
                        lbl.Text = item.CoPilot.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 22:
                        lbl.Text = item.Dual.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 23:
                        lbl.Text = item.Instructor.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 24:
                        lbl.Text = item.CrossCountry.ToString();
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    case 25:
                        lbl.Text = item.NotesAndEndorsements;
                        MainGrid.SetRow(lbl, row);
                        MainGrid.SetColumn(lbl, i);
                        break;
                    default:
                        break;
                }
                lbl.HorizontalTextAlignment = TextAlignment.Center;
                lbl.GestureRecognizers.Add(tap);
                MainGrid.Children.Add(lbl);
            }

        }

        delete = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Delete", BackgroundColor = Colors.Red, IsVisible = false };
        delete.Clicked += (s, e) => Delete_Clicked(MainGrid);
        MainGrid.SetRow(delete, 25);
        MainGrid.SetColumn(delete, MainGrid.ColumnDefinitions.Count - 1);
        MainGrid.Children.Add(delete);
    }

    void LoadRatings()
    {
        var RatingList = new List<Ratings>();
        foreach (var item in MainPage.MyDatabase.Ratings)
        {
            RatingList.Add(item);
        }
        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnTapped(s, e, this.RatingsGrid);
        int row = 0;
        foreach (var item in RatingList)
        {
            row++;
            RatingsGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
            for (int i = 0; i < 4; i++)
            {
                //Adding border
                Border br = new Border();
                br.StrokeThickness = 1;
                RatingsGrid.SetRow(br, row);
                RatingsGrid.SetColumn(br, i);
                RatingsGrid.Children.Add(br);
                //Adding label
                Label lbl = new Label();
                switch (i)
                {
                    case 0:
                        lbl.Text = item.RatingID.ToString();
                        RatingsGrid.SetRow(lbl, row);
                        RatingsGrid.SetColumn(lbl, i);
                        break;
                    case 1:
                        lbl.Text = item.DateOfIssue.ToString();
                        RatingsGrid.SetRow(lbl, row);
                        RatingsGrid.SetColumn(lbl, i);
                        break;
                    case 2:
                        lbl.Text = item.CustomRating.ToString();
                        RatingsGrid.SetRow(lbl, row);
                        RatingsGrid.SetColumn(lbl, i);
                        break;
                    default:
                        break;
                }
                lbl.HorizontalTextAlignment = TextAlignment.Center;
                lbl.GestureRecognizers.Add(tap);
                RatingsGrid.Children.Add(lbl);
            }

        }
        delete = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Delete", BackgroundColor = Colors.Red, IsVisible = false };
        delete.Clicked += (s, e) => Delete_Clicked(RatingsGrid);
        RatingsGrid.SetRow(delete, 25);
        RatingsGrid.SetColumn(delete, RatingsGrid.ColumnDefinitions.Count - 1);
        RatingsGrid.Children.Add(delete);
    }

    void OnTapped(object s, TappedEventArgs e, Grid grid)
    {
        if (s is Label l)
        {
            if (tappedRow == grid.GetRow(l))
            {
                reversed = !reversed;
            }
            visible = false;
            tappedRow = grid.GetRow(l);
            foreach (View item in grid.Children)
            {
                if (!reversed)
                {
                    if (grid.GetRow(item) == tappedRow)
                    {
                        if (item.BackgroundColor == Colors.Blue)
                        {
                            item.BackgroundColor = Colors.Transparent;
                        }
                        else
                        {
                            item.BackgroundColor = Colors.Blue;
                            visible = true;
                        }
                    }
                    else
                    {
                        item.BackgroundColor = Colors.Transparent;
                    }
                }
                else
                {
                    if (grid.GetRow(item) == tappedRow)
                    {
                        if (item.BackgroundColor == Colors.Transparent)
                        {
                            item.BackgroundColor = Colors.Blue;
                            visible = true;
                        }
                        else
                        {
                            item.BackgroundColor = Colors.Transparent;
                        }
                    }
                    else
                    {
                        item.BackgroundColor = Colors.Transparent;
                    }
                }
            }
            ShowButtons();
        }
    }

    void ShowButtons()
    {

        if (visible)
        {
            delete.IsVisible = true;
        }
        else
        {
            delete.IsVisible = false;
        }
    }

    async void Delete_Clicked(Grid views)
    {
        int id = -1;
        foreach (View item in views)
        {
            if (Grid.GetRow(item) == tappedRow && Grid.GetColumn(item) == 0)
            {
                if (item is Label l)
                {
                    id = Int32.Parse(l.Text);
                    break;
                }
            }
        }
        if (id != -1)
        {
            bool result = await DisplayAlert("Confirmation", "Do you really want to delete this?", "Yes", "No");
            if (views == MainGrid)
            {
                if (result)
                {
                    var entity = MainPage.MyDatabase.Logbooks.First(l => l.LogbookID == id);
                    MainPage.MyDatabase.Logbooks.Remove(entity);
                    MainPage.MyDatabase.SaveChanges();
                    Navigation.PopAsync(false);
                    Navigation.PushAsync(new MainTabbedPage(id1));
                }
            }
            else if (views == RatingsGrid)
            {
                if (result)
                {
                    var entity = MainPage.MyDatabase.Ratings.First(r => r.RatingID == id);
                    MainPage.MyDatabase.Ratings.Remove(entity);
                    MainPage.MyDatabase.SaveChanges();
                    Navigation.PopAsync(false);
                    Navigation.PushAsync(new MainTabbedPage(id1));
                }
            }
        }
        else
        {
            //Display error
        }
    }
    protected override bool OnBackButtonPressed()
    {
        Navigation.PopAsync();
        Navigation.PopAsync();
        Navigation.RemovePage(this);
        return true;
    }
}