using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace PracticaPracticosa.Model
{
    public class Song
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Preview { get; set; }
        public long Rank {  get; set; }
        public int TotalLikes { get; set; }
        public string User {
            get => Preferences.Default.Get<String>("user", "default");
            set => Preferences.Default.Set("user", value);
        
        }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        //public JsonElement Artist { get; set; }
    }

    public class Artist
    {
        public string Name { get; set; }
    }
    public class Album { 
        public string Cover_medium { get; set; } 
    }
}