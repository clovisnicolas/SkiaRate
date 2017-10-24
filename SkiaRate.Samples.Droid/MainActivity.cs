using Android.App;
using Android.Widget;
using Android.OS;
using SkiaRate;

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
            FindViewById<RatingView>(Resource.Id.ratingView2).OnColor = MaterialColors.Red;
            FindViewById<RatingView>(Resource.Id.ratingView2).Count = 15;
            FindViewById<RatingView>(Resource.Id.ratingView3).Path = PathConstants.Theaters;
            FindViewById<RatingView>(Resource.Id.ratingView3).OnColor = MaterialColors.Teal;
        }
    }
}

