using MarsCitizens.iOS.Persistence;
using MarsCitizens.Persistence;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace MarsCitizens.iOS.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteConnection GetConnection(string dbName)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

            return new SQLiteConnection(dbPath);
        }
    }

}