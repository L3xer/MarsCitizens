using System;
using Xamarin.Forms;
using MarsCitizens.ViewModels;

namespace MarsCitizens.Views
{
    public partial class MainPage : ContentPage
    {
        private TapGestureRecognizer _tapGestureRecognizer;
        private MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = BindingContext as MainViewModel;
            _tapGestureRecognizer = new TapGestureRecognizer();
        }

        protected override async void OnAppearing()
        {
            var result = await _viewModel.GetCitiziensCountAsync();

            if (result.IsFailure)
                await DisplayAlert("Mars Citizens", result.Error, "Close");

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
            await Navigation.PushAsync(new CitiziensPage());
        }
    }
}
