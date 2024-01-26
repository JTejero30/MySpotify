using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaPracticosa.DataBase.Migrations;
using PracticaPracticosa.Model;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PracticaPracticosa.ViewModel
{
    public partial class LoginViewModel : ObservableValidator
    {
        public ObservableCollection<String> ErroresUName { get; set; } = new ObservableCollection<String>();
        public ObservableCollection<String> ErroresPass { get; set; } = new ObservableCollection<String>();

        private string userName;
        [Required(ErrorMessage = "Tienes que completar el usuario")]

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string password;
        [Required(ErrorMessage = "Tienes que completar la contraseña")]
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        [RelayCommand]
        public async void changeRegister()
        {
            System.Diagnostics.Debug.WriteLine("RegiButton");

            await AppShell.Current.GoToAsync(nameof(View.Register));

        }

        [RelayCommand]
        public async void checkLogin()
        {
        System.Diagnostics.Debug.WriteLine("LoginButtin");

            ErroresUName.Clear();
            ErroresPass.Clear();
            ValidateAllProperties();

            GetErrors(nameof(UserName)).ToList().ForEach(e => ErroresUName.Add(e.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(e => ErroresPass.Add(e.ErrorMessage));

            if (ErroresUName.Count == 0 && ErroresPass.Count == 0)
            {
                var list = UserMigration.getConnection().Query<User>("select * from Users where userName=? and Password=?", UserName, Password);


                if (list.Count > 0)
                {
                    Preferences.Default.Set("user",UserName);
                    var userValue = Preferences.Get("user","default");
                    Debug.WriteLine(userValue);
                    await AppShell.Current.GoToAsync(nameof(View.Favorites));
                    

                }
                else
                {
                    ErroresPass.Add("Credenciales no validas");
                    
                }
            }
        }
    }
}
