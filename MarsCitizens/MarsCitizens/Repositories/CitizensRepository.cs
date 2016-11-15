using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarsCitizens.Contracts.Repository;
using MarsCitizens.Contracts.Services;
using MarsCitizens.Extensions;
using MarsCitizens.Models;

namespace MarsCitizens.Repositories
{
    public class CitizensRepository : ICitizensRepository
    {
        private readonly string url = "https://dl.dropboxusercontent.com/s/vt4ra077675fve7/citiziens.json";

        private IDataService _dataService;
        private IEnumerable<Citizen> cache;

        private bool IsCacheEmpty => cache == null || cache.Count() <= 0;

        public CitizensRepository(IDataService dataService)
        {
            if (dataService == null)
                throw new ArgumentException(nameof(dataService));

            _dataService = dataService;
        }

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

        private async Task<Result<IEnumerable<Citizen>>> GetCitizensAsync()
        {
            if (IsCacheEmpty)
                cache = (await _dataService.GetAsync<List<Citizen>>(url))?.OrderByDescending(x => x.LandingDate);

            if (IsCacheEmpty)
                return Result.Fail<IEnumerable<Citizen>>("Network problems. Please try again later.");           

            return Result.Ok(cache);
        }
    }
}
