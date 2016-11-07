using Xamarin.Forms;
using MarsCitizens.ViewModels;

namespace MarsCitizens.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel();

            InitializeComponent();
        }
    }
}
