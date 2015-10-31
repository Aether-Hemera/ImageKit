using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ImageKit.AreasRemap;
using ImageKit.Cheshire;

namespace ImageKit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private readonly Eye _eye = new Eye();

        private void buttonShapeTests_Click(object sender, EventArgs e)
        {
            DrawEye();
        }

        private void DrawEye()
        {
            var b = new Bitmap(200, 200);
            using (var g = Graphics.FromImage(b))
            {
                g.Clear(Color.Black);
                _eye.Draw(g);
            }
            pictureBox1.Image = b;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // _fourPointOval.Tension = trackBar1.Value/10f;
            DrawEye();
        }

        private void cmdAnimate_Click(object sender, EventArgs e)
        {
            // _fourPointOval.Tension = 0;
            // _fourPointOval.Tension.Animate(2, 10000);
            Animator.Instance.Tick = 0;
            _eye.SwingPupil(100);
        }

        private void tbTick_Scroll(object sender, EventArgs e)
        {
            Animator.Instance.Tick = tbTick.Value;
            DrawEye();
        }
    }
}
