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

        public static event AuthStateChangeDelegate signedInEvent;
        public static event AuthStateChangeDelegate signedOutEvent;

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
        //Returns true if it's successfull
        public static bool CreateUserWithEmailAndPassword(string email, string password)
        {
            Task task = auth.CreateUserWithEmailAndPasswordAsync(email, password);

            Util.TaskCompletion taskCompletion = Util.TaskManager.CheckTask("SignIn", task);

            if (taskCompletion == Util.TaskCompletion.Success)
            {
                Util.DebugLog.shortMSG("Signed In succesfully");
                return true;
            }
            else
                return false;
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
                    signedOutEvent?.Invoke();
                }
                user = senderAuth.CurrentUser;
                userByAuth[senderAuth.App.Name] = user;
                if (signedIn)
                {
                    Util.DebugLog.shortMSG("Signed in " + user.DisplayName);
                    userName = user.DisplayName ?? "";
                    signedInEvent?.Invoke();
                }
            }
            else if (senderAuth.CurrentUser == user && user != null)
            {
                Util.DebugLog.shortMSG("Logged in "+user.DisplayName);
                signedInEvent?.Invoke();
            }
            else if (user == null)
            {
                Util.DebugLog.shortMSG("Logged Out");
                signedOutEvent?.Invoke();
            }

            auth_user = auth.CurrentUser;
        }
    }
}