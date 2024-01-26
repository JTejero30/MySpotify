using CommunityToolkit.Maui.Views;
using PracticaPracticosa.DataBase.Migrations;
using PracticaPracticosa.Model;
using PracticaPracticosa.Plantillas;
using System.Diagnostics;

namespace PracticaPracticosa.View;

public partial class Favorites : Simple
{
	public Favorites()
	{
		InitializeComponent();
        var user = Preferences.Get("user","default");
		favorites.ItemsSource = FavoriteMigration.getConnection().Query<Favorite>("select * from favorite where user like ?",user);
        userName.Text = "Los favoritos de  "+user;
	}
    private async void myPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
       

        switch (picker.SelectedIndex)
        {
            case 0:
                
                Preferences.Clear();
                await AppShell.Current.GoToAsync(nameof(View.Login));
                break; 
            case 1:
                
                await AppShell.Current.GoToAsync(nameof(View.APIView));
                break;
            case 2:
               
                await AppShell.Current.GoToAsync(nameof(View.Favorites));
                break;
        }
        
    }
}