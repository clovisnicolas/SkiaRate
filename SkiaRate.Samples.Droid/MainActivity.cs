using Android.App;
using Android.Widget;
using Android.OS;
using SkiaRate.Droid;

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

            FindViewById<RatingView>(Resource.Id.ratingView1).Rating = Sample.StarRating;
            FindViewById<RatingView>(Resource.Id.ratingView2).Rating = Sample.FavRating;
            FindViewById<RatingView>(Resource.Id.ratingView3).Rating = Sample.CircleRating;
        }
    }
}

