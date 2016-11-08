using MarsCitizens.ViewModels;
using Xamarin.Forms;

namespace MarsCitizens.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();

            _viewModel = BindingContext as MainViewModel;
        }

        protected override async void OnAppearing()
        {
            var result = await _viewModel.GetCitiziensCountAsync();

            if (result.IsFailure)
                await DisplayAlert("Mars Citizens", result.Error, "Close");
        }
    }
}
