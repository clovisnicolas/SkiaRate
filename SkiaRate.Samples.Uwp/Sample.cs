using SkiaSharp;

namespace SkiaRate.Samples
{
    public static class Sample
    {
        public static Rating StarRating => new Rating() { Path = "M9 11.3l3.71 2.7-1.42-4.36L15 7h-4.55L9 2.5 7.55 7H3l3.71 2.64L5.29 14z", Value = 2.5f };
        public static Rating FavRating => new Rating() { Path = "M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z" , OnColor = SKColors.DeepPink, Value = 3.5f};
        public static Rating CircleRating => new Rating() { Path = "M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2z", OnColor = SKColors.Turquoise, Value = 4.5f};
    }
}


