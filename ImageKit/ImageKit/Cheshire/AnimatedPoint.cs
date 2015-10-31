using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

namespace ImageKit.Cheshire
{
    class AnimatedPoint
    {
        private AnimatedFloat X;

        private AnimatedFloat Y;

        //public static AnimatedPoint operator +(AnimatedPoint c1, AnimatedPoint c2)
        //{
        //    return new AnimatedPoint(c1.X + c2.X, c1.Y + c2.Y);
        //}

        public AnimatedPoint()
        { }

        public AnimatedPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        //public static implicit operator PointF(AnimatedPoint d)  // implicit digit to byte conversion operator
        //{
        //    return new PointF(d.X, d.Y);
        //}

        public AnimatedPoint Anchor { get; set; }

        public PointF PointF
        {
            get
            {
                return Anchor != null 
                    ? new PointF(X.Value + Anchor.X.Value, Y.Value + Anchor.Y.Value )
                    : new PointF(X.Value, Y.Value);
            }
        }

        public void Animate(float fromX, float fromY, float toX, float toY, int iDuration)
        {
            X.Value = fromX;
            Y.Value = fromY;

            X.Animate(toX, iDuration);
            Y.Animate(toY, iDuration);
        }
    }
}
