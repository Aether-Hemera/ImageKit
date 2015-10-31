using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageKit.AreasRemap;

namespace ImageKit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void CreateBitmap()
        {
            var flag = new Bitmap(10, 10);
            for (var x = 0; x < flag.Height; ++x)
                for (var y = 0; y < flag.Width; ++y)
                    flag.SetPixel(x, y, Color.White);
            for (var x = 0; x < flag.Height; ++x)
                flag.SetPixel(x, x, Color.Red);
            pictureBox1.Image = flag;
        }

        readonly string _gifFile =
                (@"cropped.gif");

        readonly string _imgFolder =
                (@"..\..\..\..\Animazioni\");

        private string GifFile
        {
            get { return Path.Combine(_imgFolder, _gifFile); }
        }

        private void buttonExplodeGif(object sender, EventArgs e)
        {
            var gifImg = Image.FromFile(GifFile);
            var dimension = new FrameDimension(gifImg.FrameDimensionsList[0]);
            // Number of frames
            var count = gifImg.GetFrameCount(dimension);
            
            // Return an Image at a certain index
            for (var i = 0; i < count; i++)
            {
                gifImg.SelectActiveFrame(dimension, i);
                var b = new Bitmap(gifImg);
                var fName = FrameName(i);
                    
                b.Save(fName);
            }
        }

        private void buttonRemap_Click(object sender, EventArgs e)
        {
            var destBitmap = new Bitmap(128, 64);
            var c = new AreaMapCollection();
            c.Load();
            var gifImg = GetImage(@"SourceMap.png");
            using (var g = Graphics.FromImage(destBitmap))
            {
                c.Process(gifImg, g);    
            }           
            destBitmap.Save("out.png");
            pictureBox1.Image = destBitmap;
        }

        private Image GetFrame(int i)
        {
            var fName = FrameName(i);
            var gifImg = Image.FromFile(fName);
            return gifImg;
        }

        private Image GetImage(string fName)
        {
            var fullName = Path.Combine(_imgFolder, fName);
            var gifImg = Image.FromFile(fullName);
            return gifImg;
        }

        private string FrameName(int i)
        {
            return string.Format(@"{0}{1}.png", _imgFolder, i);
        }
    }
}
