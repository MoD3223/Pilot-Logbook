namespace PilotLogbook;

public partial class MainTabbedPage : TabbedPage
{
    int tappedRow;
    bool visible;
    bool reversed;
    Button AddNewLogbookEntry;
    Button AddNewRatingsEntry;
    Button AddNewCertsEntry;
    Button AddNewSynthEntry;
    Button AddNewMedicalEntry;
    Button delete;
    Button MobileView;
    PilotID id1;
    public MainTabbedPage(PilotID ID)
    {
        InitializeComponent();
        id1 = ID;
        CurrentPageChanged += OnCurrentPageChanged;
        LoadLogbooks();
        LoadRatings();
        LoadCerts();
        LoadSynth();
        LoadMed();
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

        AddNewLogbookEntry = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Add new entry" };
        AddNewLogbookEntry.Clicked += AddNewLogbookEntry_Clicked;
        MainGrid.SetRow(AddNewLogbookEntry, row+1);
        MainGrid.SetColumn(AddNewLogbookEntry, 0);
        MainGrid.Children.Add(AddNewLogbookEntry);

        delete = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Delete", IsVisible = false };
        delete.Clicked += (s, e) => Delete_Clicked(MainGrid);
        MainGrid.SetRow(delete, row+1);
        MainGrid.SetColumn(delete, 1);
        MainGrid.Children.Add(delete);

        MobileView = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Switch to mobile view", IsVisible = false };
        MobileView.Clicked += (s, e) => MobileView_Clicked(MainGrid);
        MainGrid.SetRow(MobileView, row+1);
        MainGrid.SetColumn(MobileView, 2);
        MainGrid.Children.Add(MobileView);

    }

    void LoadRatings()
    {
        var RatingList = new List<Ratings>();
        foreach (var item in MainPage.MyDatabase.Ratings)
        {
            if (item.pilot == id1)
            {
                RatingList.Add(item);
            }
        }
        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnTapped(s, e, this.RatingsGrid);
        RatingsGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        RatingsGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        int row = 0;
        foreach (var item in RatingList)
        {
            row++;
            RatingsGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
            for (int i = 0; i < 3; i++)
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
                lbl.HorizontalOptions = LayoutOptions.FillAndExpand;
                lbl.HorizontalTextAlignment = TextAlignment.Center;
                lbl.GestureRecognizers.Add(tap);
                RatingsGrid.Children.Add(lbl);
            }

        }
        AddNewRatingsEntry = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Add new entry" };
        AddNewRatingsEntry.Clicked += AddNewRatingsEntry_Clicked;
        RatingsGrid.SetRow(AddNewRatingsEntry, row + 1);
        RatingsGrid.SetColumn(AddNewRatingsEntry, 0);
        RatingsGrid.Children.Add(AddNewRatingsEntry);


    }

    

    void LoadCerts()
    {
        var CertList = new List<Certifications>();
        foreach (var item in MainPage.MyDatabase.Certifications)
        {
            if (item.pilot == id1)
            {
                CertList.Add(item);
            }
        }
        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnTapped(s, e, this.CertGrid);
        CertGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        CertGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        int row = 0;
        foreach (var item in CertList)
        {
            row++;
            CertGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
            for (int i = 0; i < 3; i++)
            {
                Border br = new Border();
                br.StrokeThickness = 1;
                CertGrid.SetRow(br, row);
                CertGrid.SetColumn(br, i);
                CertGrid.Children.Add(br);
                Label lbl = new Label();
                switch (i)
                {
                    case 0:
                        lbl.Text = item.Number.ToString();
                        CertGrid.SetRow(lbl, row);
                        CertGrid.SetColumn(lbl, i);
                        break;
                    case 1:
                        if (item.RecievedGrade != Certifications.Grade.Other)
                        {
                            lbl.Text = item.RecievedGrade.ToString();
                        }
                        else
                        {
                            lbl.Text = item.CustomGrade;
                        }
                        CertGrid.SetRow(lbl, row);
                        CertGrid.SetColumn(lbl, i);
                        break;
                    case 2:
                        lbl.Text = item.DateOfIssue.ToString();
                        CertGrid.SetRow(lbl, row);
                        CertGrid.SetColumn(lbl, i);
                        break;
                    default:
                        break;
                }
                lbl.HorizontalTextAlignment = TextAlignment.Center;
                lbl.GestureRecognizers.Add(tap);
                CertGrid.Children.Add(lbl);
            }
        }
        AddNewCertsEntry = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Add new entry" };
        AddNewCertsEntry.Clicked += AddNewCertsEntry_Clicked;
        CertGrid.SetRow(AddNewCertsEntry, row + 1);
        CertGrid.SetColumn(AddNewCertsEntry, 0);
        CertGrid.Children.Add(AddNewCertsEntry);
    }

    void LoadSynth()
    {
        var SynthList = new List<SyntheticLogbook>();
        foreach (var item in MainPage.MyDatabase.SynthethicFlights)
        {
            if (item.pilot == id1)
            {
                SynthList.Add(item);
            }
        }
        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnTapped(s, e, this.SynthGrid);
        SynthGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        SynthGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        int row = 0;
        foreach (var item in SynthList)
        {
            row++;
            SynthGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
            for (int i = 0; i < 4; i++)
            {
                Border br = new Border();
                br.StrokeThickness = 1;
                SynthGrid.SetRow(br, row);
                SynthGrid.SetColumn(br, i);
                SynthGrid.Children.Add(br);
                Label lbl = new Label();
                switch (i)
                {
                    case 0:
                        lbl.Text = item.SynthID.ToString();
                        SynthGrid.SetRow(lbl, row);
                        SynthGrid.SetColumn(lbl, i);
                        break;
                    case 1:
                        lbl.Text = item.type.ToString();
                        SynthGrid.SetRow(lbl, row);
                        SynthGrid.SetColumn(lbl, i);
                        break;
                    case 2:
                        lbl.Text = item.TotalTime.ToString();
                        SynthGrid.SetRow(lbl, row);
                        SynthGrid.SetColumn(lbl, i);
                        break;
                    case 3:
                        lbl.Text = item.date.ToString();
                        SynthGrid.SetRow(lbl, row);
                        SynthGrid.SetColumn(lbl, i);
                        break;
                    default:
                        break;
                }
                lbl.HorizontalTextAlignment = TextAlignment.Center;
                lbl.GestureRecognizers.Add(tap);
                SynthGrid.Children.Add(lbl);
            }
        }

        AddNewSynthEntry = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Add new entry" };
        AddNewSynthEntry.Clicked += AddNewSynthEntry_Clicked;
        SynthGrid.SetRow(AddNewSynthEntry, row + 1);
        SynthGrid.SetColumn(AddNewSynthEntry, 0);
        SynthGrid.Children.Add(AddNewSynthEntry);
    }

    void LoadMed()
    {
        var MedList = new List<MedicalCertificates>();
        foreach (var item in MainPage.MyDatabase.MedicalCerts)
        {
            if (item.pilot == id1)
            {
                MedList.Add(item);
            }
        }

        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => OnTapped(s, e, this.MedGrid);
        MedGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        MedGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
        int row = 0;

        foreach (var item in MedList)
        {
            row++;
            MedGrid.AddRowDefinition(new RowDefinition(GridLength.Auto));
            for (int i = 0; i < 5; i++)
            {
                Border br = new Border();
                br.StrokeThickness = 1;
                MedGrid.SetRow(br, row);
                MedGrid.SetColumn(br, i);
                MedGrid.Children.Add(br);
                Label lbl = new Label();
                switch (i)
                {
                    case 0:
                        lbl.Text = item.MedicalID.ToString();
                        MedGrid.SetRow(lbl, row);
                        MedGrid.SetColumn(lbl, i);
                        break;
                    case 1:
                        lbl.Text = item.MedicalDate.ToString();
                        MedGrid.SetRow(lbl, row);
                        MedGrid.SetColumn(lbl, i);
                        break;
                    case 2:
                        lbl.Text = item.MedicalClass;
                        MedGrid.SetRow(lbl, row);
                        MedGrid.SetColumn(lbl, i);
                        break;
                    case 3:
                        lbl.Text = item.FlightDate.ToString();
                        MedGrid.SetRow(lbl, row);
                        MedGrid.SetColumn(lbl, i);
                        break;
                    case 4:
                        lbl.Text = item.InstrumentDate.ToString();
                        MedGrid.SetRow(lbl, row);
                        MedGrid.SetColumn(lbl, i);
                        break;
                    default:
                        break;
                }
                lbl.HorizontalTextAlignment = TextAlignment.Center;
                lbl.GestureRecognizers.Add(tap);
                MedGrid.Children.Add(lbl);
            }
        }
        AddNewMedicalEntry = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Text = "Add new entry" };
        AddNewMedicalEntry.Clicked += AddNewMedicalEntry_Clicked;
        MedGrid.SetRow(AddNewMedicalEntry, row + 1);
        MedGrid.SetColumn(AddNewMedicalEntry, 0);
        MedGrid.Children.Add(AddNewMedicalEntry);
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
        AddNewLogbookEntry.BackgroundColor = Colors.White;
        AddNewRatingsEntry.BackgroundColor = Colors.White;
        AddNewCertsEntry.BackgroundColor = Colors.White;
        AddNewMedicalEntry.BackgroundColor = Colors.White;
        AddNewSynthEntry.BackgroundColor = Colors.White;
        if (visible)
        {
            delete.IsVisible = true;
            delete.BackgroundColor = Colors.White;
            MobileView.IsVisible = true;
            MobileView.BackgroundColor = Colors.White;
        }
        else
        {
            delete.IsVisible = false;
            MobileView.IsVisible = false;
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
            Navigation.PushAsync(new ErrorPage());
        }
    }

    async void MobileView_Clicked(Grid views)
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
            if (views == MainGrid)
            {
                var entity = MainPage.MyDatabase.Logbooks.First(l => l.LogbookID == id);
                await Navigation.PushAsync(new LogPreviewAndroid(entity));
            }
            else if (views == RatingsGrid)
            {
                var entity = MainPage.MyDatabase.Ratings.First(r => r.RatingID == id);
                //TODO: Finish this
            }
        }
        else
        {
            Navigation.PushAsync(new ErrorPage());
        }
    }

    void OnCurrentPageChanged(object sender, EventArgs e)
    {
        visible = false;
        List<Button> toRemove = new List<Button>();
        foreach (ContentPage item in Children)
        {
            if (item.Content is ScrollView sc && sc.Content is Grid grid)
            {
                foreach (View itemtwo in grid.Children)
                {
                    itemtwo.BackgroundColor = Colors.Transparent;
                    if (itemtwo is Button btn && btn.Text == "Delete")
                    {
                        toRemove.Add(btn);
                    }
                }

                foreach (Button bb in toRemove)
                {
                    grid.Children.Remove(bb);
                }
            }
        }
        ShowButtons();

        var currentPage = CurrentPage;

        if (currentPage == LogbookTabbedPage)
        {
            MainGrid.SetRow(delete, Int32.MaxValue);
            MainGrid.SetColumn(delete, 1);
            MainGrid.Children.Add(delete);

        }
        else if (currentPage == RatingsTabbedPage)
        {
            RatingsGrid.SetRow(delete, Int32.MaxValue);
            RatingsGrid.SetColumn(delete, 1);
            RatingsGrid.Children.Add(delete);
        }
        else if (currentPage == CertsTabbedPage)
        {
            CertGrid.SetRow(delete, Int32.MaxValue);
            CertGrid.SetColumn(delete, 1);
            CertGrid.Children.Add(delete);
        }
        else if (currentPage == SynthTabbedPage)
        {
            SynthGrid.SetRow(delete, Int32.MaxValue);
            SynthGrid.SetColumn(delete, 1);
            SynthGrid.Children.Add(delete);
        }
        else if (currentPage == MedicalTabbedPage)
        {
            MedGrid.SetRow(delete, Int32.MaxValue);
            MedGrid.SetColumn(delete, 1);
            MedGrid.Children.Add(delete);
        }
    }

    private void AddNewLogbookEntry_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewLogbookEntry(id1));
    }

    private void AddNewRatingsEntry_Clicked(object sender, EventArgs e)
    {
        CurrentPage = Children[0]; //REQUIRED!!!!
        Navigation.PushAsync(new NewRatingsEntry(id1));
    }

    private void AddNewCertsEntry_Clicked(object sender, EventArgs e)
    {
        CurrentPage = Children[0];
        Navigation.PushAsync(new NewCertsEntry(id1));
    }

    private void AddNewSynthEntry_Clicked(object sender, EventArgs e)
    {
        CurrentPage = Children[0];
        Navigation.PushAsync(new NewSynthEntry(id1));
    }

    private void AddNewMedicalEntry_Clicked(object sender, EventArgs e)
    {
        CurrentPage = Children[0];
        Navigation.PushAsync(new NewMedicalEntry(id1));
    }


    protected override bool OnBackButtonPressed()
    {
        CurrentPage = Children[0];
        Navigation.PopToRootAsync();
        return true;
    }
}
