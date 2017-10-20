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
            this.ratingView1.Rating = Sample.StarRating;
            this.ratingView2.Rating = Sample.FavRating;
            this.ratingView3.Rating = Sample.CircleRating;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }
    }
}
