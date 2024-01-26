using PracticaPracticosa.Plantillas;

namespace PracticaPracticosa.View;

public partial class Users : Simple
{
	public Users()
	{
		InitializeComponent();
	}

    private async void logOut(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(View.Login));
        Preferences.Clear();
    }
    private async void musicView(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(View.APIView));
    }
    private async void favView(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(View.Favorites));
    }
}