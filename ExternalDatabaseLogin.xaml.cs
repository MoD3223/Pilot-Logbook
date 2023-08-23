namespace PilotLogbook;

public partial class ExternalDatabaseLogin : ContentPage
{
	public static string DomainName;
	public static uint PortNumber;
	public static string DatabaseName;
	public static string Login;
	public static string Password;
	public ExternalDatabaseLogin()
	{
		InitializeComponent();
	}

    private void btnTryExternalLogin_Clicked(object sender, EventArgs e)
    {
        MainPage.MyDatabase = null;
        MainPage.IsLocal = false;
        MainPage.MyDatabase = new MyDbContext();
        DomainName = ExternalEntryDomain.Text;
		PortNumber = uint.Parse(ExternalEntryPort.Text);
		DatabaseName = ExternalEntryDatabase.Text;
		Login = ExternalEntryLogin.Text;
		Password = ExternalEntryPass.Text;
		Navigation.PushAsync(new LoginDB());
    }
}