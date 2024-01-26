using PracticaPracticosa.View;

namespace PracticaPracticosa
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(Register), typeof(Register));
            Routing.RegisterRoute(nameof(Users), typeof(Users));
            Routing.RegisterRoute(nameof(APIView), typeof(APIView));
            Routing.RegisterRoute(nameof(Favorites), typeof(Favorites));
        }
    }
}