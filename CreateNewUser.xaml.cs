namespace PilotLogbook;

public partial class CreateNewUser : ContentPage
{
	public CreateNewUser()
	{
		InitializeComponent();
	}

    private async void btnInput_Clicked(object sender, EventArgs e)
    {
		string? pass = ePassword.Text == string.Empty ? null : ePassword.Text;
		string? address = eAddress.Text == string.Empty ? null : eAddress.Text;
		string? phone = ePhone.Text == string.Empty ? null : ePhone.Text;
		int phoneInt;
		Int32.TryParse(phone,out phoneInt);
		try
		{
            MainPage.MyDatabase.Pilots.Add(new PilotID() { Login = eLogin.Text, Password = pass, Address = address, PhoneNumber = phoneInt });
            MainPage.MyDatabase.SaveChanges();
			await Navigation.PushAsync(new LoginDB());
			Navigation.RemovePage(this);
        }
		catch (Exception)
		{

			throw;
		}
    }
}