using System.Collections.Generic;
using System.Threading.Tasks;
using MarsCitizens.Models;
using MarsCitizens.Extensions;

namespace MarsCitizens.Contracts.Repository
{
    public interface ICitizensRepository
    {
        Task<Result<IEnumerable<Citizien>>> GetAllAsync();

        Task<Result<int>> GetCountAsync();
    }
}
