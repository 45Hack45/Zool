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

using Newtonsoft.Json;

using Zool.Firebase_Interface;
using Zool.Data_Models;

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

            var actionBar = FindViewById<Toolbar>(Resource.Id.toolbar);

            actionBar.Title = "Profile";

            FirebaseInterface.Initialize();

            var usernameText = FindViewById<TextView>(Resource.Id.NomUsuari_text);

            var listener = Firebase_Database.GetValueListener("Users/"+Firebase_Auth.auth_user.Uid);

            listener.DataRetrived += Listener_DataRetrived;
        }

        private void Listener_DataRetrived(object sender, DatabaseEventListener.DataEventArgs e)
        {
            var usernameText = FindViewById<TextView>(Resource.Id.NomUsuari_text);

            User_DataModel user_Data = JsonConvert.DeserializeObject<User_DataModel>((string)e.Snapshot.Value);

            usernameText.Text = user_Data.DisplayName;
        }
    }
}