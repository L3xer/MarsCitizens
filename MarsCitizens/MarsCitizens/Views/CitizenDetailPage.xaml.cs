using System;
using Xamarin.Forms;
using MarsCitizens.Models;
using MarsCitizens.ViewModels;


namespace MarsCitizens.Views
{
    public partial class CitizenDetailPage : ContentPage
    {
        private CitizenDetailViewModel _viewModel;

        public CitizenDetailPage(Citizen citizen)
        {
            InitializeComponent();
            Title = citizen.Name;

            _viewModel = BindingContext as CitizenDetailViewModel;
            _viewModel.Citizen = citizen;

            _moreInfo.Clicked += (sender, e) => {
                Device.OpenUri(new Uri(citizen.Wiki));
            };
        }        
    }
}
