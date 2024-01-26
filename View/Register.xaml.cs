using PracticaPracticosa.DataBase.Migrations;
using PracticaPracticosa.Model;
using System.Diagnostics;

namespace PracticaPracticosa.View;

public partial class Register : ContentPage
{
    public Register()
    {

        InitializeComponent();

        System.Diagnostics.Debug.WriteLine("Registro");

    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var resultado = await DisplayActionSheet("Acciones", "Cancelar", null, "Cortar", "Copiar", "Pegar");
        var entry = userEntry.Text;
        Debug.WriteLine(entry);

        switch (resultado)
        {
            case "Cortar":
                Clipboard.SetTextAsync(userEntry.Text);
                userEntry.Text = "";
                break;
            case "Copiar":
                Clipboard.SetTextAsync(userEntry.Text);
                break;
            case "Pegar":
                userEntry.Text += await Clipboard.GetTextAsync();
                break;
        }
    }
}