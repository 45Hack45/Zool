package crc64f2cba9b5d7a092c9;


public class Camera_Activity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		android.view.SurfaceHolder.Callback,
		com.google.android.gms.vision.Detector.Processor,
		com.google.android.gms.vision.CameraSource.PictureCallback,
		com.google.android.gms.vision.CameraSource.ShutterCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onRequestPermissionsResult:(I[Ljava/lang/String;[I)V:GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler\n" +
			"n_surfaceChanged:(Landroid/view/SurfaceHolder;III)V:GetSurfaceChanged_Landroid_view_SurfaceHolder_IIIHandler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_surfaceCreated:(Landroid/view/SurfaceHolder;)V:GetSurfaceCreated_Landroid_view_SurfaceHolder_Handler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_surfaceDestroyed:(Landroid/view/SurfaceHolder;)V:GetSurfaceDestroyed_Landroid_view_SurfaceHolder_Handler:Android.Views.ISurfaceHolderCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_receiveDetections:(Lcom/google/android/gms/vision/Detector$Detections;)V:GetReceiveDetections_Lcom_google_android_gms_vision_Detector_Detections_Handler:Android.Gms.Vision.Detector/IProcessorInvoker, Xamarin.GooglePlayServices.Vision.Common\n" +
			"n_release:()V:GetReleaseHandler:Android.Gms.Vision.Detector/IProcessorInvoker, Xamarin.GooglePlayServices.Vision.Common\n" +
			"n_onPictureTaken:([B)V:GetOnPictureTaken_arrayBHandler:Android.Gms.Vision.CameraSource/IPictureCallbackInvoker, Xamarin.GooglePlayServices.Vision.Common\n" +
			"n_onShutter:()V:GetOnShutterHandler:Android.Gms.Vision.CameraSource/IShutterCallbackInvoker, Xamarin.GooglePlayServices.Vision.Common\n" +
			"";
		mono.android.Runtime.register ("Zool.Camera_Activity, Zool", Camera_Activity.class, __md_methods);
	}


	public Camera_Activity ()
	{
		super ();
		if (getClass () == Camera_Activity.class)
			mono.android.TypeManager.Activate ("Zool.Camera_Activity, Zool", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2)
	{
		n_onRequestPermissionsResult (p0, p1, p2);
	}

	private native void n_onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2);


	public void surfaceChanged (android.view.SurfaceHolder p0, int p1, int p2, int p3)
	{
		n_surfaceChanged (p0, p1, p2, p3);
	}

	private native void n_surfaceChanged (android.view.SurfaceHolder p0, int p1, int p2, int p3);


	public void surfaceCreated (android.view.SurfaceHolder p0)
	{
		n_surfaceCreated (p0);
	}

	private native void n_surfaceCreated (android.view.SurfaceHolder p0);


	public void surfaceDestroyed (android.view.SurfaceHolder p0)
	{
		n_surfaceDestroyed (p0);
	}

	private native void n_surfaceDestroyed (android.view.SurfaceHolder p0);


	public void receiveDetections (com.google.android.gms.vision.Detector.Detections p0)
	{
		n_receiveDetections (p0);
	}

	private native void n_receiveDetections (com.google.android.gms.vision.Detector.Detections p0);


	public void release ()
	{
		n_release ();
	}

	private native void n_release ();


	public void onPictureTaken (byte[] p0)
	{
		n_onPictureTaken (p0);
	}

	private native void n_onPictureTaken (byte[] p0);


	public void onShutter ()
	{
		n_onShutter ();
	}

	private native void n_onShutter ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
