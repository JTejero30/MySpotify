using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PracticaPracticosa.DataBase;
using PracticaPracticosa.DataBase.Migrations;
using PracticaPracticosa.Model;
namespace PracticaPracticosa
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                
                .UseMauiApp<App>().UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            string ruta = ObtenerRuta.returnRoute("Practica.db");
            builder.Services.AddSingleton(new UserMigration(ruta));
            builder.Services.AddSingleton(new FavoriteMigration(ruta));

            return builder.Build();
        }
    }
}