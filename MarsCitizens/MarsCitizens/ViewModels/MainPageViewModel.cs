using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarsCitizens.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string citizienCount = "4";
        public string CitizienCount
        {
            get { return citizienCount; }
            set { citizienCount = value; OnPropertyChanged(); }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public MainPageViewModel()
        {
            IsBusy = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
