using Xamarin.Forms;

namespace MarsCitizens.Extensions
{
    public class AspectRatioContainer : ContentView
    {
        public double AspectRatio { get; set; }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest(new Size(widthConstraint, widthConstraint * AspectRatio));
        }
    }
}
