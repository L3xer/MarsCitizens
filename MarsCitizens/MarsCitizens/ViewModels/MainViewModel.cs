using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MvvmHelpers;
using MarsCitizens.Extensions;
using MarsCitizens.Contracts.Repository;


namespace MarsCitizens.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICitizensRepository _citizensRepository;

        private string _citizenCount;
        public string CitizenCount
        {
            get { return _citizenCount; }
            set { SetProperty(ref _citizenCount, value); }
        }      

        public MainViewModel(ICitizensRepository citizensRepository)
        {
            _citizensRepository = citizensRepository;
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
