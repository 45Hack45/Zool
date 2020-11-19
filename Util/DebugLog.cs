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

namespace Zool.Util
{
    class DebugLog
    {
        //Short duration msg
        public static void shortMSG(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Short).Show();
        }
        //Long duration msg
        public static void longMSG(string msg)
        {
            Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();
        }
    }
}