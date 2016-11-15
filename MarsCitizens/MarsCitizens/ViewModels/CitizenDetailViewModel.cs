using MarsCitizens.Models;
using MvvmHelpers;

namespace MarsCitizens.ViewModels
{
    public class CitizenDetailViewModel : BaseViewModel
    {
        private Citizen _citizen;
        public Citizen Citizen
        {
            get { return _citizen; }
            set { _citizen = value; }
        }
    }
}
