using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using MarsCitizens.Models;
using MarsCitizens.Extensions;
using MarsCitizens.Contracts.Repository;

namespace MarsCitizens.ViewModels
{
    public class PhotosListViewModel : BaseViewModel
    {
        private Citizen _citizen;
        public Citizen Citizen
        {
            get { return _citizen; }
            set { _citizen = value; }
        }

        private IPhotoCameraRepository _photoCameraRepository;

        public ObservableRangeCollection<Photo> Photos { get; } = new ObservableRangeCollection<Photo>();

        public ICommand LoadPhotoCommand { get; set; }


        private int _currentSol;


        public PhotosListViewModel(IPhotoCameraRepository photoCameraRepository)
        {
            _photoCameraRepository = photoCameraRepository;

            LoadPhotoCommand = new Command(GetPhotosForCurrentSolAsync);
        }

        public async Task<Result> GetPhotosAsync()
        {
            Photos.Clear();


            IsBusy = true;

            var result = await _photoCameraRepository.GetMaxSolAsync(_citizen.NormalizedName);

            IsBusy = false;

            if (result.IsFailure)
                return Result.Fail(result.Error);

            _currentSol = result.Value;
            
                        

            GetPhotosForCurrentSolAsync();

            return Result.Ok();
        }

        private async void GetPhotosForCurrentSolAsync()
        {
            IsBusy = true;

            (await _photoCameraRepository.GetPhotosAsync(_citizen.NormalizedName, _currentSol--))
                .OnSuccess((photos) => {
                    Photos.AddRange(photos);
                });

            IsBusy = false;
        }
    }
}
