using PracticaPracticosa.DataBase.Migrations;
using PracticaPracticosa.Model;
using System.Collections.ObjectModel;

namespace PracticaPracticosa
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        //creamos una lista para el buscador
        private static ObservableCollection<String> items = new ObservableCollection<String>();

        public MainPage()
        {
            InitializeComponent();
            items.Add(new String ("Antonio"));
            items.Add(new String("Ernesto"));
            items.Add(new String("Armando"));
            listaView.ItemsSource = items;
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            //mensaje informacion    
            //await DisplayAlert("Titulo", "Mensaje", "ok");

            //mensaje confirmacion
            /*bool variable= await DisplayAlert("confirmacion", "confirmas?", "Yes", "No");
            //recogemos la variable:
            if (variable)
            {
                await DisplayAlert("SI","Has pulsado si","OK");
            }*/

            //mensaje con entrada de teclado del usuario
            String numero= await DisplayPromptAsync("Mensaje de entrada", "Cuanto es 2+2",initialValue:"4",maxLength:2,keyboard: Keyboard.Numeric);
            if (numero == "4") {
                await DisplayAlert("Correcto","salir","ok");
            }
        }

        private void seeker_SearchButtonPressed(object sender, EventArgs e)
        {
            List<String> lista = items.Where(cadena=>
            cadena.Contains(seeker.Text)).ToList();

            listaView.ItemsSource = lista;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker= (Picker)sender;
            String seleccionado= picker.SelectedItem as String;
            System.Diagnostics.Debug.WriteLine(seleccionado);
        }
    }
}