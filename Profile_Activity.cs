using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Zool
{
    [Activity(Label = "Profile_Activity", Theme = "@style/AppTheme", ParentActivity = typeof(MainActivity))]
    public class Profile_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Profile);

            /*ActionBar actionBar = this.ActionBar;
            actionBar.Title = "Profile";
            actionBar.Subtitle = "UserName";
            actionBar.SetDisplayHomeAsUpEnabled(true);*/
        }

        
    }
}