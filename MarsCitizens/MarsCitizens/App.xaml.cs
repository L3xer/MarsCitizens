using Xamarin.Forms;
using MarsCitizens.Views;

namespace MarsCitizens
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            var navigationPage = new NavigationPage(new MainPage());
            navigationPage.BarBackgroundColor = Color.FromHex("#d32f2f");

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
