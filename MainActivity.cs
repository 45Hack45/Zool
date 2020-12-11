using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Gms.Ads;

using Zool.Firebase_Interface;

namespace Zool
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //MobileAds.Initialize(ApplicationContext, "ca-app-pub-9328745187864745~5178457296");

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            //Init firebase
            FirebaseInterface.Initialize();

            Firebase_Database.UpdateValue("Test", "Pollo");

            Firebase_Auth.SignedOutEvent += Firebase_Auth_signedOutEvent;

            var adView = FindViewById<AdView>(Resource.Id.adMobBanner);
            var adRequest = new AdRequest.Builder()
                .Build();
            adView.LoadAd(adRequest);

        }

        private void Firebase_Auth_signedOutEvent()
        {
            Intent intent = new Intent(this, typeof(Login_Activity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    return true;
                case Resource.Id.navigation_camera:
                    //textMessage.SetText(Resource.String.title_autoSearch);
                    Intent intent = new Intent(this, typeof(Camera_Activity));
                    StartActivity(intent);
                    return true;
            }
            return false;
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //change main_compat_menu
            MenuInflater.Inflate(Resource.Menu.MainPage_ActionMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Intent intent;
            switch (item.ItemId)
            {
                case Resource.Id.action_logOut:
                    Firebase_Auth.LogOut();
                    break;
                case Resource.Id.action_Profile:
                    intent = new Intent(this, typeof(Profile_Activity));
                    StartActivity(intent);
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

