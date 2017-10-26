using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SkiaSharp;

namespace SkiaRate.Samples.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.ratingView2.Path = PathConstants.Heart;
            this.ratingView2.OnColor = MaterialColors.Pink;
            this.ratingView2.RatingType = RatingType.Half;
            this.ratingView3.RatingType = RatingType.Full;
            this.ratingView4.Path = PathConstants.Like;
            this.ratingView4.OnColor = MaterialColors.LightBlue;
            this.ratingView5.Path = PathConstants.Dislike;
            this.ratingView5.OnColor = MaterialColors.Red;
            this.ratingView6.Path = PathConstants.Theaters;
            this.ratingView6.OnColor = MaterialColors.Teal;
            this.ratingView7.Path = PathConstants.Problem;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
