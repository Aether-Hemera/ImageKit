using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageKit.AreasRemap
{
    internal class AreaMap
    {
        public Rectangle Origin;
        public Point Destination;

        static public Bitmap GetRegion(Image srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            var bmp = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                // Draw the specified section of the source bitmap to the new one
                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
            }
            // Return the bitmap
            return bmp;
        }

        public void Process(Image gifImg, Graphics destBitmap)
        {
            // get region
            var region = GetRegion(gifImg, Origin);
            
            // write to destination
           destBitmap.DrawImage(region, Destination);
        }

        public static AreaMap Init(int x, int y)
        {
            var m = new AreaMap()
            {
                Origin = new Rectangle(
                    x, y, 16, 32
                    )
            };
            return m;
        }

        public AreaMap MoveY(int i)
        {
            Destination = new Point(Origin.X, Origin.Y + i);
            return this;
        }

        public AreaMap SizeX(int i)
        {
            Origin.Size = new Size(i, Origin.Height);
            return this;
        }
    }
}
