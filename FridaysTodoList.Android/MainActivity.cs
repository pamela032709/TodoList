﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FridaysTodoList.Droid
{
    [Activity(Label = "2Do", Icon = "@mipmap/mainicon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental");
            Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                return; //// Do something if there are some pages in the `PopupStack`
            }
            else
            {
                return;
                // Do something if there are not any pages in the `PopupStack`
            }
        }
    }
    
}