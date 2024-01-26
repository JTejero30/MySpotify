using PracticaPracticosa.Model;
using SQLite;

namespace PracticaPracticosa.DataBase.Migrations
{

    public class UserMigration
    {
        private string _ruta;
        private static SQLiteConnection _connection;

        public UserMigration(string ruta)
        {
            _ruta = ruta;
            _connection = new SQLiteConnection(ruta);

            System.Diagnostics.Debug.WriteLine($"La ruta de la base de datos local es: {_ruta}");

            if (!_connection.TableMappings.Any(e => e.MappedType.Name == "Users"))
            {
                _connection.CreateTable<User>();
                System.Diagnostics.Debug.WriteLine("Tabla Usuarios creada");
            }
        }
        public static SQLiteConnection getConnection()
        {
            return _connection;
        }
        public static void addUser(User user)
        {
            _connection.Insert(user);
        }
    }


}
