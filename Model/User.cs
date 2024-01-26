using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPracticosa.Model
{
    [SQLite.Table("Users")]
    public class User
    {
        [PrimaryKey, Unique, NotNull]
        public string UserName { get; set;}
        public string Name { get; set; }
        public string Age { get; set; }
        public string Password { get; set; }
    }
}
