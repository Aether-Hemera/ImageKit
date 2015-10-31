using System.Drawing;

namespace ImageKit.Cheshire
{
    class AnimatedPoint
    {
        public float X;
        public float Y;

        public static AnimatedPoint operator +(AnimatedPoint c1, AnimatedPoint c2)
        {
            return new AnimatedPoint(c1.X + c2.X, c1.Y+ c2.Y);
        }

        public AnimatedPoint()
        { }

        public AnimatedPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator PointF(AnimatedPoint d)  // implicit digit to byte conversion operator
        {
            return new PointF(d.X, d.Y);
        }
    }
}
