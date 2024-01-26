using PracticaPracticosa.Model;
using PracticaPracticosa.DataBase.Migrations;
using System.Diagnostics;
using Newtonsoft.Json;
namespace PracticaPracticosa.View;


public partial class APIView : ContentPage
{
    public APIView()
	{
		InitializeComponent();
        
    }

    public class Data  {
        public List<Song> data {get; set;}
    }
    public List<Song> Songs { get; set;}

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {

        var entry = seeker.Text;

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://deezerdevs-deezer.p.rapidapi.com/search?q={entry}"),
            Headers =
    {
        { "X-RapidAPI-Key", "951422f43dmsh4e967c45debf436p169e8bjsn6fe1a77c06c2" },
        { "X-RapidAPI-Host", "deezerdevs-deezer.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Data>(body);

            songsData.ItemsSource = data.data;
        }
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