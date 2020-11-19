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

using Zool.Firebase_Interface;

namespace Zool
{
    [Activity(Label = "@string/title_logSign")]
    public class LogSign_Activity : Activity
    {
        Button signupButton;
        EditText username_ifield, email_ifield, password_ifield, rPassword_ifield;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LogSign);

            Firebase_Auth.signedInEvent += Firebase_Auth_signedInEvent;

            username_ifield     = FindViewById<EditText>(Resource.Id.username__inputfield);
            email_ifield        = FindViewById<EditText>(Resource.Id.email_inputfield);
            password_ifield     = FindViewById<EditText>(Resource.Id.password_inputfield);
            rPassword_ifield    = FindViewById<EditText>(Resource.Id.rPassword_inputfield);

            signupButton = FindViewById<Button>(Resource.Id.signup_button);
            signupButton.Click += SignupButton_Click;
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
        }

        private void Firebase_Auth_signedInEvent()
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {

            if (checkInput())
            {
                Firebase_Auth.CreateUserWithEmailAndPassword(email_ifield.Text, password_ifield.Text);
            }
        }

        public bool checkInput (){
            return true;
        }
    }
}