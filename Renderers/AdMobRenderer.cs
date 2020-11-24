using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;
using Xamarin.Forms;
using Zool.Controls;
using Zool.Renderers;
using Android.Content;
using Android.Widget;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdView))]
namespace Zool.Renderers
{
    class AdMobRenderer : ViewRenderer<AdMobView, AdView>
    {

        public AdMobRenderer(Context context) : base(context) { }

        string adUnitID = "ca-app-pub-3940256099942544/6300978111";

        //adUnitID Atachable propety
        /*public static readonly BindableProperty adUnitID =
            BindableProperty.CreateAttached("adUnitId", typeof(string), typeof(AdMobRenderer), false);*/

        AdSize adSize = AdSize.Banner;

        AdView adView;

        AdView CreatreAdView() {

            if(adView == null)
            {
                adView = new AdView(Context);

                adView.AdSize = adSize;
                adView.AdUnitId = adUnitID;
                var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

                adView.LayoutParameters = adParams;

                adView.LoadAd(new AdRequest.Builder().Build());
            }

            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);

            //if ((Element is AdMobView adMobElement) && (e.OldElement == null))
            //{
            //    var adId = "ca-app-pub-9328745187864745/4168805563";

            //    var ad = new AdView(Context)
            //    {
            //        AdSize = AdSize.Banner,
            //        AdUnitId = adId
            //    };

            //    var requestbuilder = new AdRequest.Builder();
            //    ad.LoadAd(requestbuilder.Build());
            //    SetNativeControl(ad);
            //}

            if (Control == null)
            {
                CreatreAdView();
                SetNativeControl(adView);
            }
        }
    }
}