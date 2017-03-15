using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using MarsCitizens.Contracts.Repository;
using MarsCitizens.Extensions;
using MarsCitizens.Models;
using MarsCitizens.Persistence;

namespace MarsCitizens.Repositories
{
    public class CitizensRepository : ICitizensRepository
    {
        private SQLiteConnection dbConnection;


        public CitizensRepository(ISQLiteDb sqliteDb)
        {
            dbConnection = dbConnection ?? sqliteDb.GetConnection("user.db");

            dbConnection.CreateTable<Citizen>();
        }

        public bool HasCitizensLocally => Task.Run(() => GetCountAsync()).Result.Value > 0;


        public async Task<Result<IEnumerable<Citizen>>> GetAllAsync()
        {
            var result = await GetCitizensAsync();
            if (result.IsFailure)
                return Result.Fail<IEnumerable<Citizen>>(result.Error);

            return Result.Ok(result.Value);
        }

        public async Task<Result<int>> GetCountAsync()
        {
            var result = await GetCitizensAsync();
            if (result.IsFailure)
                return Result.Fail<int>(result.Error);

            return Result.Ok(result.Value.Count());
        }

        public void SaveCitizens(IEnumerable<Citizen> citizens)
        {
            dbConnection.InsertAll(citizens);
        }

        private async Task<Result<IEnumerable<Citizen>>> GetCitizensAsync()
        {
            IEnumerable<Citizen> citizens = await Task.Run(() => dbConnection.Table<Citizen>().ToList());
            return Result.Ok(citizens);
        }
    }
}
