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
		//TODO: Add fields with login/password etc then Navigate to LocalLoginDB
		InitializeComponent();
	}
}