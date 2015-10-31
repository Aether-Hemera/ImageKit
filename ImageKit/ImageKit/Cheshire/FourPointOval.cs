using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ImageKit.Cheshire
{
    class FourPointOval
    {
        public  AnimatedPoint Center = new AnimatedPoint(0,0);

        public Pen BorderPen;
        public Brush Brush = Brushes.Gold;
        public AnimatedFloat Tension = 0.8f;

        public void Draw(Graphics g)
        {
            g.FillClosedCurve(Brush, ControlPoints.ToArray(), FillMode.Alternate, Tension);
        }

        public FourPointOval(AnimatedPoint AnchorPoint)
        {
            Center.Anchor = AnchorPoint;
            PointLeft = new AnimatedPoint(-20, 5);
            PointTop = new AnimatedPoint(0, -20);
            PointRight = new AnimatedPoint(20, -5);
            PointBottom = new AnimatedPoint(0, 20);
        }

        private IEnumerable<PointF> ControlPoints
        {
            get
            {
                var BaseX = Center.PointF.X;
                var BaseY = Center.PointF.Y;

                yield return new PointF(
                    BaseX + PointLeft.PointF.X, 
                    BaseY + PointLeft.PointF.Y);
                yield return new PointF(
                    BaseX + PointTop.PointF.X,
                    BaseY + PointTop.PointF.Y);
                yield return new PointF(
                    BaseX + PointRight.PointF.X,
                    BaseY + PointRight.PointF.Y);
                yield return new PointF(
                    BaseX + PointBottom.PointF.X,
                    BaseY + PointBottom.PointF.Y);
            }
        }

        public AnimatedPoint PointLeft;
        public AnimatedPoint PointTop;
        public AnimatedPoint PointRight;
        public AnimatedPoint PointBottom;
    }
}
