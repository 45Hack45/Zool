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

namespace Zool.Data_Models
{
    [Serializable]
    class User_DataModel
    {
        //                                          aprox bytes
        public string UserID;//Primary Key    (~32)
        public string DisplayName;//          (32)
        public string profilePictureURL = "__DEFAULT_PROFILE__";//    (~128)

        public string curs;//                 (16)
        public uint interestCategories;//   (4)
        public uint interestSubjects;//     (4)

        public double balance;//              (8)
        public double experience;//level      (8)

        //public ExerciceData[] exercises;//            (n*(~32+~128))
        public UInt32 exercicesCount;//       (4)

        public string[] followers;//ID list     (m*~32)
        public string[] following;//ID list     (k*~32)

        //                  Sum:                    460 Bytes
    }
}