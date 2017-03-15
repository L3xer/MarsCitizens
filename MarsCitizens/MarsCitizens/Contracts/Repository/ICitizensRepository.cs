using System.Collections.Generic;
using System.Threading.Tasks;
using MarsCitizens.Models;
using MarsCitizens.Extensions;

namespace MarsCitizens.Contracts.Repository
{
    public interface ICitizensRepository
    {
        bool HasCitizensLocally { get; }

        void SaveCitizens(IEnumerable<Citizen> citizens);

        Task<Result<IEnumerable<Citizen>>> GetAllAsync();

        Task<Result<int>> GetCountAsync();
    }
}
