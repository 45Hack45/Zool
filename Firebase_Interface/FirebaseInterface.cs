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

using Firebase;

namespace Zool.Firebase_Interface
{
    static class FirebaseInterface
    {
        private static FirebaseApp firebaseApp;

        public static void Initialize()
        {
            if(firebaseApp == null)
            {
                FirebaseOptions options = new FirebaseOptions.Builder()
                    .SetApplicationId("1:718476597236:android:558cf59fb8d47085584ba1")
                    .SetApiKey("AIzaSyBr0d1n4kXSaagg22Ca9xUrg0LMHCZ9pmI")
                    .SetDatabaseUrl("https://zool-bc1e6.firebaseio.com")
                    .SetStorageBucket("zool-bc1e6.appspot.com")
                    .Build();

                firebaseApp = FirebaseApp.InitializeApp(Application.Context, options,"Zool");
            }

            Firebase_Auth.Init();
            Firebase_Database.Init();
        }
    }
}