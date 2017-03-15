using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarsCitizens.Contracts.Services;
using MarsCitizens.Extensions;
using MarsCitizens.Models;



namespace MarsCitizens.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly string url = "https://dl.dropboxusercontent.com/s/vt4ra077675fve7/citiziens.json";

        private IDataService _dataService;

        public CitizenService(IDataService dataService)
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

        private async Task<Result<IEnumerable<Citizen>>> GetCitizensAsync()
        {
            IEnumerable<Citizen> citizens = (await _dataService.GetAsync<List<Citizen>>(url))?.OrderByDescending(x => x.LandingDate).ToArray();

            if (citizens == null || citizens.Count() <= 0)
                return Result.Fail<IEnumerable<Citizen>>("Network problems. Please try again later.");

            return Result.Ok(citizens);
        }
    }
}
