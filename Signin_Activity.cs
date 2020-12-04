using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Zool.Firebase_Interface;

using Newtonsoft.Json;

namespace Zool
{
    [Activity(Label = "@string/title_SignUp")]
    public class Signin_Activity : Activity
    {
        Button signupButton;
        EditText username_ifield, email_ifield, password_ifield, rPassword_ifield;
        TextView loginText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SignUp);

            FirebaseInterface.Initialize();

            Firebase_Auth.SignedInEvent += Firebase_Auth_signedInEvent;

            username_ifield     = FindViewById<EditText>(Resource.Id.username__inputfield);
            email_ifield        = FindViewById<EditText>(Resource.Id.email_inputfield);
            password_ifield     = FindViewById<EditText>(Resource.Id.password_inputfield);
            rPassword_ifield    = FindViewById<EditText>(Resource.Id.rPassword_inputfield);

            signupButton = FindViewById<Button>(Resource.Id.signup_button);
            signupButton.Click += SignupButton_Click;

            loginText = FindViewById<TextView>(Resource.Id.text_clickable_LogIn);
            loginText.Click += LoginText_Click;
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }

        private void Firebase_Auth_signedInEvent()
        {
            //Intent intent = new Intent(this, typeof(MainActivity));
            //StartActivity(intent);
        }

        private async void SignupButton_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                Data_Models.User_DataModel user = new Data_Models.User_DataModel();

                await Firebase_Auth.CreateUserWithEmailAndPassword(email_ifield.Text, password_ifield.Text);

                Android.Util.Log.Debug("Create User", "Signed In succesfully");

                user.UserID = Firebase_Auth.auth_user.Uid;
                user.DisplayName = username_ifield.Text;

                await Firebase_Auth.UpdateAccount(user.DisplayName, "");

                Android.Util.Log.Debug("Update Profile", "Updated Profile succesfully");

                string userJSON = JsonConvert.SerializeObject(user);

                Firebase_Database.UpdateValue("Users/" + user.UserID, userJSON);

                Util.DebugLog.shortMSG("Updated Database succesfully");
            }
        }

        private void LoginText_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login_Activity));
            StartActivity(intent);
        }

        public bool checkInput (){
            if(username_ifield.Text == "")
            {
                Util.DebugLog.shortMSG("Username can't be empty");
                return false;
            }
            return true;
        }
    }
}