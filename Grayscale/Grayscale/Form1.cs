﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grayscale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = "Image File (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            if (DialogResult.OK == bukaFile.ShowDialog())
            {
                this.pictureBox1.Image = new Bitmap(bukaFile.FileName);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pictureBox1.Image);
              
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int grayAvg = (c1.R + c1.G + c1.B) / 3;
                        b.SetPixel(i, j, Color.FromArgb(grayAvg, grayAvg, grayAvg));
                    }
                  
                }
           
                this.pictureBox2.Image = b;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Tidak Ada citra yang akan diolah");
            }
            else
            {
                Bitmap b = new Bitmap((Bitmap)this.pictureBox1.Image);
           
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = b.GetPixel(i, j);
                        int nilaiMax = Math.Max(c1.R, Math.Max(c1.G, c1.B));
                        int nilaiMin = Math.Min(c1.R, Math.Min(c1.G, c1.B));
                        int gLight = (nilaiMax + nilaiMin) / 2;
                        b.SetPixel(i, j, Color.FromArgb(gLight, gLight, gLight));
                    }
                 
                }
              
                this.pictureBox2.Image = b;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap((Bitmap)this.pictureBox1.Image);
         
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);
                    double gLum = (0.21 * c1.R) + (0.72 * c1.G) + (0.07 * c1.B);
                    b.SetPixel(i, j, Color.FromArgb(Convert.ToInt16(gLum), Convert.ToInt16(gLum), Convert.ToInt16(gLum)));
                }
            
            }
        
            this.pictureBox2.Image = b;
        }
    }
}
