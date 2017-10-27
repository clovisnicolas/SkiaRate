using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SkiaSharp;
using System.Threading.Tasks;
using SkiaSharp.Views.Forms;

namespace SkiaRate.Samples.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        { 
            InitializeComponent();
            this.ratingView2.Path = PathConstants.Heart; 
            this.ratingView2.RatingType = RatingType.Half;
            this.ratingView3.RatingType = RatingType.Full;
            this.ratingView4.Path = PathConstants.Like;
            this.ratingView5.Path = PathConstants.Dislike; 
            this.ratingView6.Path = PathConstants.Theaters; 
            this.ratingView7.Path = PathConstants.Bar;
            this.ratingView8.Path = PathConstants.Circle;
            this.ratingView8.StrokeWidth = 1;
            this.batteryView.Path = PathConstants.BatteryCharging;
            this.lowBatteryView.Path = PathConstants.BatteryAlert;
            this.lowBatteryView.Value = 1;
            this.UpdateLoader();
            this.UpdateBattery();
            this.UpdateLowBattery();
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
                this.batteryView.ColorOn = MaterialColors.Lime.WithAlpha((byte)(255 * totalTime)).ToFormsColor();
                totalTime += step;
                if(totalTime > 1 || totalTime < 0)
                {
                    totalTime = Math.Min(1,Math.Max(0,totalTime));
                    step = -step;
                }
            }
        }

        private async void UpdateLowBattery()
        {
            float totalTime = 0;
            var step = 0.02f;
            while (true)
            {
                await Task.Delay(33);
                this.lowBatteryView.ColorOn = MaterialColors.Red.WithAlpha((byte)(255 * totalTime)).ToFormsColor();
                totalTime += step;
                if (totalTime > 1 || totalTime < 0)
                {
                    totalTime = Math.Min(1, Math.Max(0, totalTime));
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
