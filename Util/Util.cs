﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Zool.Util
{
    class Util
    {
        public float DpToPx(float dp, DisplayMetrics displayMetrics)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, displayMetrics);
        }
    }
}