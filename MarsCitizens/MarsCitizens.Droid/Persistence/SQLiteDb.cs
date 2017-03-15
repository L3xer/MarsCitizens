using System.IO;
using SQLite;
using MarsCitizens.Persistence;
using MarsCitizens.Droid.Persistence;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLiteDb))]

namespace MarsCitizens.Droid.Persistence
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