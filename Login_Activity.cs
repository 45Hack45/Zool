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
    [Activity(Label = "@string/title_SignUp")]
    public class Login_Activity : Activity
    {
        Button loginButton;
        EditText email_ifield, password_ifield;
        TextView signupText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LogIn);

            Firebase_Auth.signedInEvent += Firebase_Auth_signedInEvent;

            email_ifield        = FindViewById<EditText>(Resource.Id.email_inputfield);
            password_ifield     = FindViewById<EditText>(Resource.Id.password_inputfield);

            loginButton = FindViewById<Button>(Resource.Id.signup_button);
            loginButton.Click += LoginButton_Click;

            signupText = FindViewById<TextView>(Resource.Id.text_clickable_LogIn);
            signupText.Click += LoginText_Click;
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

        private void LoginButton_Click(object sender, EventArgs e)
        {

            if (checkInput())
            {
                Firebase_Auth.SignInWithEmailAndPassword(email_ifield.Text, password_ifield.Text);
            }
        }

        private void LoginText_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Signin_Activity));
            StartActivity(intent);
        }

        public bool checkInput (){
            return true;
        }
    }
}