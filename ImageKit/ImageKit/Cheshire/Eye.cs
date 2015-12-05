using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace ImageKit.Cheshire
{
    class Eye
    {
        internal FourPointOval Cornea;
        internal FourPointOval Pupil;
        internal AnimatedPoint Center = new AnimatedPoint(50, 50);

        public void Draw(Graphics g)
        {
            Cornea.Draw(g);
            Pupil.Draw(g);
        }

        public Eye()
        {
            Cornea = new FourPointOval(Center) {
                PointLeft = new AnimatedPoint(-20, 5),
                PointTop = new AnimatedPoint(0, -20),
                PointRight = new AnimatedPoint(20, -5),
                PointBottom = new AnimatedPoint(0, 20)
                };

            Cornea.Tension.Animate(2, 10000);

            Pupil = new FourPointOval(Center)
            {
                PointLeft = new AnimatedPoint(-5, 0),
                PointTop = new AnimatedPoint(0, -5),
                PointRight = new AnimatedPoint(5, 0),
                PointBottom = new AnimatedPoint(0, 5),
                Brush = Brushes.Black
            };
        }

        public void SwingPupil(int iDuration)
        {
            Pupil.Center.Animate(-15, 0, 15, 0, iDuration);
        }
    }
}
