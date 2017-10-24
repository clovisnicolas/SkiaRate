using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SkiaRate.Samples.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           /* this.ratingView2.Rating = Sample.FavRating;
            this.ratingView3.Rating = Sample.CircleRating;
            this.ratingView4.Rating = Sample.LikeRating;
            this.ratingView5.Rating = Sample.DislikeRating;
            this.ratingView6.Rating = Sample.MoviesRating;
            this.ratingView7.Rating = Sample.ProblemRating;*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
