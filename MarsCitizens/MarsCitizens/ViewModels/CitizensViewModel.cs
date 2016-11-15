using System.Threading.Tasks;
using MvvmHelpers;
using MarsCitizens.Contracts.Repository;
using MarsCitizens.Models;
using MarsCitizens.Extensions;


namespace MarsCitizens.ViewModels
{
    public class CitizensViewModel : BaseViewModel
    {
        private ICitizensRepository _citizensRepository;

        public ObservableRangeCollection<Citizen> Citizens { get; } = new ObservableRangeCollection<Citizen>();

        public CitizensViewModel(ICitizensRepository citizensRepository)
        {
            _citizensRepository = citizensRepository;
        }

        public async Task<Result> GetCitizensAsync()
        {
            IsBusy = true;

            var result = await _citizensRepository.GetAllAsync();

            IsBusy = false;

            if (result.IsFailure)
                return Result.Fail(result.Error);

            Citizens.ReplaceRange(result.Value);

            return Result.Ok();
        }
    }
}
