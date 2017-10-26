using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SkiaSharp;
using System.Threading.Tasks;

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
            this.ratingView6.OnColor = MaterialColors.Purple;
            this.ratingView7.Path = PathConstants.Bar;
            this.ratingView7.OnColor = MaterialColors.Indigo;
            this.ratingView8.Path = PathConstants.Circle;
            this.ratingView8.OnColor = MaterialColors.Blue;
            this.ratingView8.StrokeWidth = 1;
            this.ratingView8.OffOutlineColor = MaterialColors.Blue;
            this.ratingView9.Path = PathConstants.BatteryCharging;
            this.ratingView9.OnOutlineColor = MaterialColors.Black;
            this.ratingView9.StrokeWidth = 0.3F;
            this.ratingView9.Value = 1;
            this.UpdateLoader();
            this.UpdateBattery();

        }

        private async void UpdateLoader()
        {
            while(true)
            {
                await Task.Delay(300);
                this.ratingView8.Value = (ratingView8.Value + 1) % (ratingView8.Count + 1);
            }
        }

        private async void UpdateBattery()
        {
            float totalTime = 0;
            var step = 0.05f;
            while (true)
            {
                await Task.Delay(33);
                this.ratingView9.OnColor = MaterialColors.Lime.WithAlpha((byte)(255 * totalTime));
                totalTime += step;
                if(totalTime > 1 || totalTime < 0)
                {
                    totalTime = Math.Min(1,Math.Max(0,totalTime));
                    step = -step;
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
