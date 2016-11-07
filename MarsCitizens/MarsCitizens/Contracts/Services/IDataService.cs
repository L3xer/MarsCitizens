using System.Threading.Tasks;

namespace MarsCitizens.Contracts.Services
{
    public interface IDataService
    {
        Task<T> GetAsync<T>(string url) where T : new();
    }
}
