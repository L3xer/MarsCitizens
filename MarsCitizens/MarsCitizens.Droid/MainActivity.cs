
using Android.App;
using Android.Content.PM;
using Android.OS;

using RoundedBoxView.Forms.Plugin.Droid;

namespace MarsCitizens.Droid
{
    [Activity(Label = "MarsCitizens", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            RoundedBoxViewRenderer.Init();
            LoadApplication(new App());
        }
    }
}

