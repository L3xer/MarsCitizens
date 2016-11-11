using System;
using Xamarin.Forms;
using MarsCitizens.ViewModels;
using MarsCitizens.Models;


namespace MarsCitizens.Views
{
    public partial class CitiziensPage : ContentPage
    {
        private CitizensViewModel _viewModel;

        public CitiziensPage()
        {
            InitializeComponent();
            Title = "Citizens";

            _viewModel = BindingContext as CitizensViewModel;

            _citizensListView.ItemTapped += (sender, e) => {
                Device.OpenUri(new Uri((e.Item as Citizien).Wiki)); 
            };
        }

        protected override async void OnAppearing()
        {
            var result = await _viewModel.GetCitizensAsync();

            if (result.IsFailure)
                await DisplayAlert("Mars Citizens", result.Error, "Close");
        }
    }
}
