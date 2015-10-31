using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ImageKit.Cheshire
{
    class Eye
    {
        public  AnimatedPoint Center = new AnimatedPoint(50,50);

        public Pen BorderPen;
        public Brush Brush = Brushes.Gold;
        public AnimatedFloat Tension = 1;

        public void Draw(Graphics g)
        {
            g.FillClosedCurve(Brush, ControlPoints.ToArray(), FillMode.Alternate, Tension);
        }

        public Eye()
        {
            PointLeft = new AnimatedPoint(-20, 5);
            PointTop = new AnimatedPoint(0, -20);
            PointRight = new AnimatedPoint(20, -5);
            PointBottom = new AnimatedPoint(0, 20);
        }

        private IEnumerable<PointF> ControlPoints
        {
            get
            {
                yield return Center + PointLeft;
                yield return Center + PointTop;
                yield return Center + PointRight;
                yield return Center + PointBottom;
            }
        }

        public AnimatedPoint PointLeft;
        public AnimatedPoint PointTop;
        public AnimatedPoint PointRight;
        public AnimatedPoint PointBottom;
    }
}
