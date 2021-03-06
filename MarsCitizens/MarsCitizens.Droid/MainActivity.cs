﻿
using Android.App;
using Android.Content.PM;
using Android.OS;

using FFImageLoading.Forms.Droid;
using RoundedBoxView.Forms.Plugin.Droid;

namespace MarsCitizens.Droid
{
    [Activity(Label = "MarsCitizens", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            RoundedBoxViewRenderer.Init();
            CachedImageRenderer.Init();

            LoadApplication(new App());
        }
    }
}

