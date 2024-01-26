
using PracticaPracticosa.DataBase.Migrations;
using PracticaPracticosa.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.UserActivities;

namespace PracticaPracticosa.ViewModel
{
    public partial class UserViewModel
    {

        
        public ObservableCollection<User> ListaUsers { get; set; } = new();
        public String UserName { get; set; }

        public UserViewModel()
        {
            UserName = Preferences.Default.Get("user", "usuario");

            var list = UserMigration.getConnection().Query<User>("select * from Users");

            ListaUsers = new ObservableCollection<User>(list);
        }

    }
}
