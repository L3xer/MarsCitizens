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
        private IEnumerable<Citizien> cache;

        private bool IsCacheEmpty => cache == null || cache.Count() <= 0;

        public CitizensRepository(IDataService dataService)
        {
            if (dataService == null)
                throw new ArgumentException(nameof(dataService));

            _dataService = dataService;
        }

        public async Task<Result<IEnumerable<Citizien>>> GetAllAsync()
        {
            var result = await GetCitizensAsync();
            if (result.IsFailure)
                return Result.Fail<IEnumerable<Citizien>>(result.Error);

            return Result.Ok(result.Value);
        }

        public async Task<Result<int>> GetCountAsync()
        {
            var result = await GetCitizensAsync();
            if (result.IsFailure)
                return Result.Fail<int>(result.Error);

            return Result.Ok(result.Value.Count());
        }

        private async Task<Result<IEnumerable<Citizien>>> GetCitizensAsync()
        {
            if (IsCacheEmpty)
                cache = (await _dataService.GetAsync<List<Citizien>>(url));

            if (IsCacheEmpty)
                return Result.Fail<IEnumerable<Citizien>>("Network problems. Please try again later.");

            return Result.Ok(cache);
        }
    }
}
