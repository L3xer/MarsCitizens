using System.ComponentModel;
using System.Runtime.CompilerServices;
using MarsCitizens.Contracts.Repository;

namespace MarsCitizens.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICitizensRepository _citizienRepository;

        private string _citizienCount;
        public string CitizienCount
        {
            get { return _citizienCount; }
            set { _citizienCount = value; OnPropertyChanged(); }
        }

        bool _isBusy = false;
        
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public MainViewModel(ICitizensRepository citizenRepository)
        {
            _citizienRepository = citizenRepository;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
