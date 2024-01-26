using PracticaPracticosa.Model;
using PracticaPracticosa.DataBase.Migrations;
using System.Diagnostics;
using Microsoft.Maui;
using CommunityToolkit.Maui.Views;

namespace PracticaPracticosa.View.Templates;

public partial class Card_image : ContentView
{
	public Card_image()

	{

        InitializeComponent();
        this.BindingContextChanged += OnBindingContextChanged;
    }

    // Evento que se dispara cuando el BindingContext cambia
    private void OnBindingContextChanged(object sender, EventArgs e)
    {
        // Llama al método para verificar la presencia del ID cuando el BindingContext cambia
        CheckIdPresence();
    }

    // Agrega este método para verificar la p
    // +resencia del ID
    private void CheckIdPresence()
    {
        var song = (Song)BindingContext;
        var user = Preferences.Default.Get<String>("user", "default");
        var exits = FavoriteMigration.getConnection().Query<Favorite>("select * from Favorite where id=? and user=?", song.Id, user);

        if (exits.Count<=0)
        {
            fileIMG.File = "heart_icon_normal.png";
        }
        else {
            fileIMG.File = "heart_icon_pressed.png";
            
        }
        exits.Clear();
        // Verifica si el ID está presente en la base de 
    }
    private void HeartButton_Clicked(object sender, EventArgs e)
    {

        if (sender is Button button)
        {

            var songLiked = ((Song)button.BindingContext);
            modifyFavorite(songLiked);
            //aqui va a cambiar la imagen rellena por la que no lo está y viceversa
            //
            fileIMG.File = (fileIMG.File == "heart_icon_normal.png") ? "heart_icon_pressed.png" : "heart_icon_normal.png";
        }
    }

    private void modifyFavorite(Song songLiked)
    {
        var user = Preferences.Default.Get<String>("user","default");
        var list = FavoriteMigration.getConnection().Query<Favorite>("select * from Favorite where id=? and user=?", songLiked.Id, user);
       // Favorite favorito = new Favorite(Id= songLiked.Id, songLiked.Title,songLiked.Preview,songLiked.Rank,songLiked.TotalLikes,songLiked.User,songLiked.Album.Cover_medium);

        if (list.Count <= 0)
        {
            
            FavoriteMigration.addSong(new Favorite { Id=songLiked.Id,Title=songLiked.Title,Preview=songLiked.Preview,Rank=songLiked.Rank,TotalLikes=songLiked.TotalLikes,User=songLiked.User,Cover_medium= songLiked.Album.Cover_medium, Name= songLiked.Artist.Name});
            Debug.WriteLine("Cancion añadida");
        }
        else
        {   
            var id= FavoriteMigration.getConnection().Query<Favorite>("select id from Favorite where id=? and user=?", songLiked.Id, user).FirstOrDefault();
            
            FavoriteMigration.removeSong(id.Id);
            Debug.WriteLine(id);
            Debug.WriteLine("Cancion eliminada");
        }
    }

    private async void playSong(object sender, EventArgs e)
    {
        if (buttonPlay.File=="play.png") {
            buttonPlay.File= "pause.png";
            mediaElement.Play();
        }
        else {
            buttonPlay.File = "play.png";
            mediaElement.Pause();
        }
    }
}