using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using MarsCitizens.ViewModels;

namespace MarsCitizens.Views
{
    public partial class MainPage : ContentPage
    {
        private TapGestureRecognizer _tapGestureRecognizer;
        private MainViewModel _viewModel;

        private bool _isDataLoaded;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = BindingContext as MainViewModel;
            _tapGestureRecognizer = new TapGestureRecognizer();
        }

        private async Task GetCitiziensDataAsync()
        {
            var result = await _viewModel.GetCitiziensCountAsync();

            if (result.IsFailure)
                await DisplayAlert("Mars Citizens", "Something went wrong. Please check your network connection and tap on screen to refresh.", "Close");

            _isDataLoaded = result.IsSuccess;
        }

        protected override async void OnAppearing()
        {
            await GetCitiziensDataAsync();

            _tapGestureRecognizer.Tapped += OnContentViewTapped;
            _contentView.GestureRecognizers.Add(_tapGestureRecognizer);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _tapGestureRecognizer.Tapped -= OnContentViewTapped;
            _contentView.GestureRecognizers.Remove(_tapGestureRecognizer);
        }

        private async void OnContentViewTapped(object sender, EventArgs e)
        {
            if (_isDataLoaded) {
                await Navigation.PushAsync(new CitiziensPage());
            } else {
                await GetCitiziensDataAsync();
            }
        }
    }
}
