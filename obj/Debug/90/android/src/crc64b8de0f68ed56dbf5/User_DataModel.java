package crc64b8de0f68ed56dbf5;


public class User_DataModel
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Zool.Data_Models.User_DataModel, Zool", User_DataModel.class, __md_methods);
	}


	public User_DataModel ()
	{
		super ();
		if (getClass () == User_DataModel.class)
			mono.android.TypeManager.Activate ("Zool.Data_Models.User_DataModel, Zool", "", this, new java.lang.Object[] {  });
	}

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
