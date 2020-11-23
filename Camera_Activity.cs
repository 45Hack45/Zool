using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Vision;
using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;

using Zool.Util;

using static Android.Gms.Vision.Detector;

namespace Zool
{
    [Activity(Label = "Camera_Activity")]
    public class Camera_Activity : Activity, ISurfaceHolderCallback, IProcessor
    {
        SurfaceView cameraPreview;
        TextView textResult;
        TextRecognizer textRecognizer;
        CameraSource cameraSource;

        const int RequestCameraPermisionID = 1001;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Camera);

            cameraPreview = FindViewById<SurfaceView>(Resource.Id.cameraPreview);
            textResult = FindViewById<TextView>(Resource.Id.txtResult);

            textRecognizer = new TextRecognizer.Builder(this).Build();
            if (!textRecognizer.IsOperational)
                DebugLog.longMSG("Detector dependencies are not yet available\n" +
                    "-----------------------------------------------------------------------------------------------------------------------------------");
            else
            {
                cameraSource = new CameraSource.Builder(this, textRecognizer).SetFacing(CameraFacing.Back)
                    .SetRequestedPreviewSize(1280, 1024)
                    .SetRequestedFps(2.0f)
                    .SetAutoFocusEnabled(true)
                    .Build();

                cameraPreview.Holder.AddCallback(this);

                textRecognizer.SetProcessor(this);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            switch (requestCode)
            {
                case RequestCameraPermisionID:
                    if (grantResults[0] == Permission.Granted)
                    {
                        if (ActivityCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
                        {
                            //Request permision
                            ActivityCompat.RequestPermissions(this, new string[]
                            {
                                Manifest.Permission.Camera
                            }, RequestCameraPermisionID);
                            return;
                        }

                        try
                        {
                            cameraSource.Start(cameraPreview.Holder);
                        }
                        catch (System.InvalidOperationException)
                        {

                            throw;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        //---------------------------------Interface ISurfaceHolderCallback implementation
        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {

        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            if (ActivityCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                //Request permision
                ActivityCompat.RequestPermissions(this, new string[]
                {
                    Manifest.Permission.Camera
                }, RequestCameraPermisionID);
                return;
            }

            try
            {
                cameraSource.Start(cameraPreview.Holder);
            }
            catch (System.InvalidOperationException)
            {

                throw;
            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            cameraSource.Stop();
        }

        //---------------------------------Interface IProcessor implementation

        public void ReceiveDetections(Detections detections)
        {
            SparseArray results = detections.DetectedItems;

            if (results.Size() > 0)
            {
                textResult.Post(() =>
                {
                    for (int i = 0; i < results.Size(); i++)
                    {
                        textResult.Text = ((TextBlock)results.ValueAt(i)).Value;
                    }
                });
            }
        }

        public void Release()
        {

        }
    }
}