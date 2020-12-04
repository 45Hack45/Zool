using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

using Firebase.Auth;

namespace Zool.Firebase_Interface
{
    static class Firebase_Auth
    {
        private static FirebaseAuth auth;
        public static FirebaseUser auth_user;

        public static Dictionary<string, FirebaseUser> userByAuth =
      new Dictionary<string, FirebaseUser>();

        public static string userName;

        public delegate void AuthStateChangeDelegate();

        public static event AuthStateChangeDelegate SignedInEvent;
        public static event AuthStateChangeDelegate SignedOutEvent;

        public static void Init()
        {
            auth = FirebaseAuth.Instance;
            auth.AuthState += AuthStateChanged;
        }

        //Log in with Email and Password
        //Returns true if it's successfull
        public static bool SignInWithEmailAndPassword(string email, string password)
        {
            Task task = auth.SignInWithEmailAndPasswordAsync(email, password);

            Util.TaskCompletion taskCompletion = Util.TaskManager.CheckTask("LogIn", task);

            if (taskCompletion == Util.TaskCompletion.Success)
            {
                Util.DebugLog.shortMSG("Loged in succesfully");
                return true;
            }
            else
                return false;
        }

        //Sign in in with Email and Password
        public static Task CreateUserWithEmailAndPassword(string email, string password)
        {
            return auth.CreateUserWithEmailAndPasswordAsync(email, password);
        }

        public static Task UpdateAccount(string username, string profileImage)
        {
            if(auth_user != null)
            {
                if (username == "" && profileImage == "")//Not doing anything
                    return null;

                var userProfileBuilder = new UserProfileChangeRequest.Builder();

                if (username != "") userProfileBuilder.SetDisplayName(username);
                if (profileImage != "")
                {
                    Android.Net.Uri uri = new Android.Net.Uri.Builder().Path(profileImage).Build();
                    userProfileBuilder.SetPhotoUri(uri);
                }

                UserProfileChangeRequest userProfile = userProfileBuilder.Build();

                return auth_user.UpdateProfileAsync(userProfile);
            }
            else return null;
        }

        public static void LogOut()
        {
            auth.SignOut();
        }

        private static void AuthStateChanged(object sender, EventArgs e)
        {
            FirebaseAuth senderAuth = sender as FirebaseAuth;
            FirebaseUser user = null;
            if (senderAuth != null) userByAuth.TryGetValue(senderAuth.App.Name, out user);
            if (senderAuth == auth && senderAuth.CurrentUser != user)
            {
                bool signedIn = user != senderAuth.CurrentUser && senderAuth.CurrentUser != null;
                if (!signedIn && user != null)
                {
                    Util.DebugLog.shortMSG("Signed out " + user.DisplayName);
                    SignedOutEvent?.Invoke();
                }
                user = senderAuth.CurrentUser;
                userByAuth[senderAuth.App.Name] = user;
                if (signedIn)
                {
                    Util.DebugLog.shortMSG("Signed in");
                    Util.DebugLog.longMSG("Welcome " + user.DisplayName);
                    userName = user.DisplayName ?? "";
                    SignedInEvent?.Invoke();
                }
            }
            else if (senderAuth.CurrentUser == user && user != null)
            {
                Util.DebugLog.shortMSG("Logged in");
                Util.DebugLog.longMSG("Welcome " + user.DisplayName);
                userName = user.DisplayName ?? "";
                SignedInEvent?.Invoke();
            }
            else if (user == null)
            {
                Util.DebugLog.shortMSG("Logged Out");
                SignedOutEvent?.Invoke();
            }

            auth_user = auth.CurrentUser;
        }
    }
}