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

using Firebase.Database;
using Zool.Firebase_Interface;

namespace Zool.Firebase_Interface
{
    public class DatabaseEventListener : Java.Lang.Object, IValueEventListener
    {

        public event EventHandler<DataEventArgs> DataRetrived;

        public class DataEventArgs : EventArgs
        {
            public DataSnapshot Snapshot { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {

        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (snapshot.Value != null)
            {
                DataRetrived.Invoke(this, new DataEventArgs { Snapshot = snapshot });
            }
        }

        public void Create(string path)
        {
            DatabaseReference dataRef = Firebase_Database.database.GetReference(path);
            dataRef.AddValueEventListener(this);
        }
    }
}