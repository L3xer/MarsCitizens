using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MarsCitizens.Extensions;
using MarsCitizens.Contracts.Repository;


namespace MarsCitizens.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICitizensRepository _citizensRepository;

        private string _citizenCount;
        public string CitizenCount
        {
            get { return _citizenCount; }
            set { _citizenCount = value; OnPropertyChanged(); }
        }


        bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
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


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
