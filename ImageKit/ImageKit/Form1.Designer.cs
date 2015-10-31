
using System.ComponentModel;
using System.Windows.Forms;

namespace ImageKit
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRemap = new System.Windows.Forms.Button();
            this.buttonShapeTests = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.cmdAnimate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Explode GIF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonExplodeGif);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(221, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(723, 481);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRemap
            // 
            this.buttonRemap.Location = new System.Drawing.Point(16, 82);
            this.buttonRemap.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemap.Name = "buttonRemap";
            this.buttonRemap.Size = new System.Drawing.Size(198, 59);
            this.buttonRemap.TabIndex = 2;
            this.buttonRemap.Text = "Remap Areas";
            this.buttonRemap.UseVisualStyleBackColor = true;
            this.buttonRemap.Click += new System.EventHandler(this.buttonRemap_Click);
            // 
            // buttonShapeTests
            // 
            this.buttonShapeTests.Location = new System.Drawing.Point(13, 149);
            this.buttonShapeTests.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShapeTests.Name = "buttonShapeTests";
            this.buttonShapeTests.Size = new System.Drawing.Size(198, 59);
            this.buttonShapeTests.TabIndex = 3;
            this.buttonShapeTests.Text = "OvalShapeTest";
            this.buttonShapeTests.UseVisualStyleBackColor = true;
            this.buttonShapeTests.Click += new System.EventHandler(this.buttonShapeTests_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(16, 215);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(195, 56);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // cmdAnimate
            // 
            this.cmdAnimate.Location = new System.Drawing.Point(16, 264);
            this.cmdAnimate.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAnimate.Name = "cmdAnimate";
            this.cmdAnimate.Size = new System.Drawing.Size(198, 59);
            this.cmdAnimate.TabIndex = 5;
            this.cmdAnimate.Text = "Animate";
            this.cmdAnimate.UseVisualStyleBackColor = true;
            this.cmdAnimate.Click += new System.EventHandler(this.cmdAnimate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 531);
            this.Controls.Add(this.cmdAnimate);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonShapeTests);
            this.Controls.Add(this.buttonRemap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button buttonRemap;
        private Button buttonShapeTests;
        private TrackBar trackBar1;
        private Button cmdAnimate;
    }
}

