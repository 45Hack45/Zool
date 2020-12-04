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

using Newtonsoft.Json;

using Firebase.Database;

namespace Zool.Firebase_Interface
{
    public static class Firebase_Database
    {
        public static FirebaseDatabase database;

        public static void Init()
        {
            database = FirebaseDatabase.Instance;
        }

        public static void UpdateValue(string referencePath, Java.Lang.Object value)
        {
            DatabaseReference reference = database.GetReference("/" + referencePath);
            reference.SetValue(value);
        }
        public static Task UpdateValue(string referencePath, Java.Lang.Object value, Java.Lang.Object priority)
        {
            DatabaseReference reference = database.GetReference("/" + referencePath);
            return reference.SetValueAsync(value, priority);
        }

        public static DatabaseEventListener GetValueListener(string referencePath)
        {
            DatabaseEventListener listener = new DatabaseEventListener();
            listener.Create("/"+referencePath);
            return listener;
        }
    }
}