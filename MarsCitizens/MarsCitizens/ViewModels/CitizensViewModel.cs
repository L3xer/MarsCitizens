using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarsCitizens.ViewModels
{
    public class CitizensViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
