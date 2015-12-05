using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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

            txtSourceFolder.Text = Properties.Settings.Default.SourceFolder;
            txtDestinationFolder.Text = Properties.Settings.Default.DestFolder;


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
            var destBitmap = new Bitmap(96, 64);
            var c = new AreaMapCollection();
            c.Load();
            var imgName = @"FirstCat.png";
            // var imgName = @"SourceMap.png";
            var gifImg = GetImage(imgName);
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
            Image img;
            using (var bmpTemp = new Bitmap(fullName))
            {
                img = new Bitmap(bmpTemp);
            }
            return img;
        }

        private string FrameName(int i)
        {
            return string.Format(@"{0}{1}.png", _imgFolder, i);
        }

        private Eye _eye = new Eye();

        private void buttonShapeTests_Click(object sender, EventArgs e)
        {
            DrawEye();
        }

        private void DrawEye()
        {
            var b = new Bitmap(128, 88);
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
            _eye = new Eye();
            Animator.Instance.Tick = 0;
            _eye.SwingPupil(100);
            _eye.Cornea.Tension.Animate(1.0f, 100);
        }

        private void tbTick_Scroll(object sender, EventArgs e)
        {
            Animator.Instance.Tick = tbTick.Value;
            DrawEye();
        }

        private void cmdRemap_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SourceFolder = txtSourceFolder.Text;
            Properties.Settings.Default.DestFolder = txtDestinationFolder.Text;
            Properties.Settings.Default.Save();

            var d = new DirectoryInfo(txtDestinationFolder.Text);
            if (!d.Exists)
                d.Create();

            var c = new AreaMapCollection();
            c.Load();

            var files = GetFiles("*.png");
            foreach (var file in files)
            {
                var destBitmap = new Bitmap(96, 64);
                var gifImg = GetImage(file.FullName);
                var outName = Path.Combine(
                    txtDestinationFolder.Text,
                    file.Name
                    );
                using (var g = Graphics.FromImage(destBitmap))
                {
                    c.Process(gifImg, g);
                }
                if (rbImage.Checked)
                    destBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else if (rbVideo.Checked)
                    destBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                
                destBitmap.Save(outName);
            }
            MessageBox.Show("Done");
        }

        private IEnumerable<FileInfo> GetFiles(string png)
        {
            var d = new DirectoryInfo(txtSourceFolder.Text);
            return !d.Exists 
                ? Enumerable.Empty<FileInfo>()
                : d.GetFiles(png);
        }

        private void txtSourceFolder_TextChanged(object sender, EventArgs e)
        {
            var d = new DirectoryInfo(txtSourceFolder.Text);
            if (d.Exists && d.Parent != null)
            {
                txtDestinationFolder.Text = Path.Combine(d.Parent.FullName, "Transformed");
            }
        }
    }
}
