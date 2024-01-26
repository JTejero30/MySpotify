using PracticaPracticosa.DataBase.Migrations;

namespace PracticaPracticosa
{
    public partial class App : Application
    {
        public UserMigration Migracion {get; set;}
        public FavoriteMigration FavoriteMigration { get; set;} 
        public App()
        {

            InitializeComponent();
            
            MainPage = new AppShell();
            
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var windows = base.CreateWindow(activationState);
            //double screenHeight = DeviceDisplay.MainDisplayInfo.Height;

            windows.Width = 800;
            windows.Height = 800;

            return windows;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Launcher.OpenAsync("https://www.linkedin.com/in/javier-tejero-developer/");
        }
    }
}