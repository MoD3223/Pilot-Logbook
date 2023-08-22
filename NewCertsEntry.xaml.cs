namespace PilotLogbook;

public partial class NewCertsEntry : ContentPage
{
	PilotID id1;
	public Certifications.Grade SelectedGrade;
	public List<Certifications.Grade> Grades { get; } = Enum.GetValues(typeof(Certifications.Grade)).Cast<Certifications.Grade>().ToList();
	public NewCertsEntry(PilotID id)
	{
		InitializeComponent();
		id1 = id;
		BindingContext = this;
	}

    private void PickerCertsGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
		SelectedGrade = Grades[PickerCertsGrade.SelectedIndex];

		if (SelectedGrade == Certifications.Grade.Other)
		{
			EntryCertsOtherGrade.IsVisible = true;
		}
		else
		{
			EntryCertsOtherGrade.IsVisible = false;
		}
    }

    private async void btnCertsAddNew_Clicked(object sender, EventArgs e)
    {
		string Number = EntryCertsNumber.Text;
		DateTime Date = DatePickerCertsDate.Date;
		Date = Date.Add(TimePickerCertsTime.Time);
		Certifications.Grade Grade = SelectedGrade;
		string SGrade;
		if (SelectedGrade == Certifications.Grade.Other)
		{
			SGrade = EntryCertsOtherGrade.Text;
		}
		else
		{
			SGrade = SelectedGrade.ToString();
		}



		if (String.IsNullOrEmpty(Number) || Date.Date == DateTime.MinValue.Date || PickerCertsGrade.SelectedItem == null)
		{
            DisplayAlert("Error", "Make sure you put all data correctly", "OK");
        }
		else
		{
			try
			{
                MainPage.MyDatabase.Certifications.Add(new Certifications(id1, Grade, SGrade, Number, Date));
                MainPage.MyDatabase.SaveChanges();
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