using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaPracticosa.DataBase.Migrations;
using PracticaPracticosa.Model;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PracticaPracticosa.ViewModel
{
    public partial class RegisterViewModel: ObservableValidator
    {
        public ObservableCollection<String> ErroresUName { get; set; } = new ObservableCollection<String>();
        public ObservableCollection<String> ErroresName { get; set; } = new ObservableCollection<String>();
        public ObservableCollection<String> ErroresAge { get; set; } = new ObservableCollection<String>();
        public ObservableCollection<String> ErroresPass { get; set; } = new ObservableCollection<String>();
        public ObservableCollection<String> ErroresPassR { get; set; } = new ObservableCollection<String>();

        private string userName;
        [Required (ErrorMessage ="Tienes que completar el usuario")]

        public string UserName {
            get => userName;
            set => SetProperty(ref userName, value);
        }
        private string name;
        [Required(ErrorMessage = "Tienes que completar el nombre")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="El nombre solo puede contener letras")]
        public string Name { 
            get => name;
            set => SetProperty(ref name, value);
        }

        private string age;
        [Required(ErrorMessage = "Tienes que completar la edad")]
        [RegularExpression(@"^100|[1-9][0-9]|[0-9]$", ErrorMessage = "Solo puede contener numeros enteros entre 0 y 100")]
        public string Age {
            get => age;
            set => SetProperty(ref age, value);
        }
        
        private string password;
        [Required(ErrorMessage = "Tienes que completar la contraseña")]
        [MinLength(5, ErrorMessage = "Minimo 5 caracteres")]
        public string Password { 
            get => password; 
            set => SetProperty(ref password, value);
        }
        
        private string passwordR;
        [Compare("Password",ErrorMessage ="Las contraseñas no coinciden")]
        public string PasswordR
        {
            get => passwordR;
            set => SetProperty(ref passwordR, value);
        }

        [RelayCommand]
        public async void goLogin()
        {
            await AppShell.Current.GoToAsync(nameof(View.Login));
        }

            [RelayCommand]
        public async void check() {
            //esto es horrible pero no vemos otra forma porque en el xml no se pueden hacer comprobaciones de clave, valor
            ErroresUName.Clear();
            ErroresName.Clear();
            ErroresAge.Clear();
            ErroresPass.Clear();
            ErroresPassR.Clear();
            ValidateAllProperties();

            GetErrors(nameof(UserName)).ToList().ForEach(e=> ErroresUName.Add(e.ErrorMessage));
            GetErrors(nameof(Name)).ToList().ForEach(e => ErroresName.Add(e.ErrorMessage));
            GetErrors(nameof(Age)).ToList().ForEach(e => ErroresAge.Add(e.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(e => ErroresPass.Add(e.ErrorMessage));
            GetErrors(nameof(PasswordR)).ToList().ForEach(e => ErroresPassR.Add(e.ErrorMessage));


            if (ErroresUName.Count == 0 && ErroresName.Count == 0 && ErroresAge.Count == 0 && ErroresPass.Count == 0)
            {

                var list = UserMigration.getConnection().Query<User>("select * from Users where userName=? ", UserName);
                if (list.Count <= 0)
                {
                    await Shell.Current.DisplayAlert("Bienvenido", "Registro de usuario completado", "OK");
                    UserMigration.addUser(new User { UserName = UserName, Name = Name, Age = Age, Password = Password });
                    await AppShell.Current.GoToAsync(nameof(View.Login));
                }
                else
                {
                    ErroresUName.Clear();
                    ValidateAllProperties();
                    ErroresUName.Add("Usuario ya registrado, pruebe con otro nombre");

                }
            }
        }
    }
}
