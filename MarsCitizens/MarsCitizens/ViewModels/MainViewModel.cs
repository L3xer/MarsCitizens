using System.Threading.Tasks;
using MvvmHelpers;
using MarsCitizens.Extensions;
using MarsCitizens.Contracts.Repository;
using MarsCitizens.Contracts.Services;

namespace MarsCitizens.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICitizensRepository _citizensRepository;
        private ICitizenService _citizensService;

        private string _citizenCount;
        public string CitizenCount
        {
            get { return _citizenCount; }
            set { SetProperty(ref _citizenCount, value); }
        }      

        public MainViewModel(ICitizenService citizensService,  ICitizensRepository citizensRepository)
        {
            _citizensRepository = citizensRepository;
            _citizensService = citizensService;
        }

        public async Task<Result> LoadAllCitizensAsync()
        {
            if (!_citizensRepository.HasCitizensLocally) {
                IsBusy = true;

                var result = await _citizensService.GetAllAsync();

                if (result.IsFailure)
                    return Result.Fail(result.Error);

                _citizensRepository.SaveCitizens(result.Value);

                IsBusy = false;
            }

            return Result.Ok();
        }

        public async Task<Result> GetCitiziensCountAsync()
        {
            IsBusy = true;

            var result = await _citizensRepository.GetCountAsync();

            IsBusy = false;

            if (result.IsFailure)
                return Result.Fail(result.Error);

            CitizenCount = result.Value.ToString();

            return Result.Ok();
        }
    }
}
