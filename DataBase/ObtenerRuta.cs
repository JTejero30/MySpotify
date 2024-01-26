using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPracticosa.DataBase
{
    public class ObtenerRuta
    {
        public static string returnRoute(String nombreDB) {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombreDB);
        }
    }
}
