using PracticaPracticosa.Model;
using SQLite;

namespace PracticaPracticosa.DataBase.Migrations
{
    public class FavoriteMigration
    {
        private string _ruta;
        private static SQLiteConnection _connection;

        public FavoriteMigration(string ruta)
        {
            _ruta = ruta;
            _connection = new SQLiteConnection(ruta);

            System.Diagnostics.Debug.WriteLine($"La ruta de la base de datos local es: {_ruta}");

            if (!_connection.TableMappings.Any(e => e.MappedType.Name == "Favorite"))
            {
                _connection.CreateTable<Favorite>();
                System.Diagnostics.Debug.WriteLine("Tabla Favoritos creada");
            }
           
        }
        public static SQLiteConnection getConnection()
        {
            return _connection;
        }
        public static void addSong(Favorite song)
        {
            _connection.Insert(song);
        }

        internal static void removeSong(long id)
        {
            Favorite songToRemove = _connection.Table<Favorite>().FirstOrDefault(favorite => favorite.Id == id);

            if (songToRemove != null)
            {
                _connection.Query<Favorite>("DELETE FROM favorite WHERE id=?",id);
            }
        }
    }
}
