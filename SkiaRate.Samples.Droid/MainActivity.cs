using Android.App;
using Android.Widget;
using Android.OS;
using SkiaRate;
using SkiaSharp.Views.Android;

namespace SkiaRate.Samples.Droid
{
    [Activity(Label = "SkiaRate.Samples.Droid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<RatingView>(Resource.Id.ratingView1).Value = 4;
            FindViewById<RatingView>(Resource.Id.ratingView2).Path = PathConstants.Heart;
            FindViewById<RatingView>(Resource.Id.ratingView2).ColorOn = MaterialColors.Red.ToColor();
            FindViewById<RatingView>(Resource.Id.ratingView2).Count = 15;
            FindViewById<RatingView>(Resource.Id.ratingView3).Path = PathConstants.Theaters;
            FindViewById<RatingView>(Resource.Id.ratingView3).ColorOn = MaterialColors.Teal.ToColor();
        }
    }
}

