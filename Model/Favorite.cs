using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPracticosa.Model
{
    [SQLite.Table("Favorite")]
    public class Favorite
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Preview { get; set; }
        public long Rank { get; set; }
        public int TotalLikes { get; set; }
        public string User
        {
            get => Preferences.Default.Get<String>("user", "default");
            set => Preferences.Default.Set("user", value);

        }
        public string Cover_medium { get; set; }
        public string Name { get; set; }
        //public JsonElement Artist { get; set; }
    }
}
