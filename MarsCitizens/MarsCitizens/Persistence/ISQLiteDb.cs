using SQLite;

namespace MarsCitizens.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteConnection GetConnection(string dbName);
    }
}
