using SkiaSharp;

namespace SkiaRate.Samples
{
    public static class Sample
    {
        public static Rating StarRating => new Rating() { Path = PathConstants.Star, OnColor = MaterialColors.Amber, Value = 2.5f };
        public static Rating FavRating => new Rating() { Path = PathConstants.Heart , OnColor = MaterialColors.Pink, Value = 3.5f};
        public static Rating CircleRating => new Rating() { Path = PathConstants.Circle, OnColor = MaterialColors.Purple, Value = 4.5f};
    }
}


