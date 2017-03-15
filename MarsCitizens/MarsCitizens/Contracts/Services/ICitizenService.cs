using MarsCitizens.Extensions;
using MarsCitizens.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarsCitizens.Contracts.Services
{
    public interface ICitizenService
    {
        Task<Result<IEnumerable<Citizen>>> GetAllAsync();
    }
}
