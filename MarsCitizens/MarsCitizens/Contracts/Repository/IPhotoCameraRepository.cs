using System.Collections.Generic;
using System.Threading.Tasks;
using MarsCitizens.Extensions;
using MarsCitizens.Models;

namespace MarsCitizens.Contracts.Repository
{
    public interface IPhotoCameraRepository
    {
        Task<Result<int>> GetMaxSolAsync(string roverName);

        Task<Result<IEnumerable<Photo>>> GetPhotosAsync(string roverName, int sol);
    }
}
