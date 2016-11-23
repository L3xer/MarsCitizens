using System;
using Xamarin.Forms;
using MarsCitizens.ViewModels;
using MarsCitizens.Models;

namespace MarsCitizens.Views
{
    public partial class PhotosListPage : ContentPage
    {
        private PhotosListViewModel _viewModel;

        private bool _isFirstLoad = true;

        public PhotosListPage(Citizen citizen)
        {
            InitializeComponent();
            Title = citizen.Name;

            _viewModel = BindingContext as PhotosListViewModel;
            _viewModel.Citizen = citizen;

            _photosListView.ItemTapped += (sender, e) => {
                Device.OpenUri(new Uri((e.Item as Photo).Url));
            };
        }

        protected override async void OnAppearing()
        {
            if (_isFirstLoad) {
                var result = await _viewModel.GetPhotosAsync();

                if (result.IsFailure)
                    await DisplayAlert("Mars Citizens", result.Error, "Close");

                _isFirstLoad = false;
            }
        }
    }
}
