using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace _22134012_VoHongQuan_Project03_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Load the original image from file
            string file_path = @"C:\Data\Machine Vision\lena_color.png";
            Bitmap origin_image = new Bitmap(file_path);

            // Display the original image in pictureBox1
            pictureBox1.Image = origin_image;

            // Create three new bitmaps for the grayscale images
            Bitmap Gray_Avg = new Bitmap(origin_image.Width, origin_image.Height);
            Bitmap Gray_Lightness = new Bitmap(origin_image.Width, origin_image.Height);
            Bitmap Gray_Lumi = new Bitmap(origin_image.Width, origin_image.Height);

            // Loop through each pixel in the original image
            for (int i = 0; i < origin_image.Width; i++)
            {
                for (int j = 0; j < origin_image.Height; j++)
                {
                    // Get the color of the current pixel
                    Color pixel = origin_image.GetPixel(i, j);

                    // Extract the color channels
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte A = pixel.A;

                    // Average method 
                    byte gray_avg = (byte)((R + G + B) / 3);
                    Gray_Avg.SetPixel(i, j, Color.FromArgb(A, gray_avg, gray_avg, gray_avg));

                    // Lightness method 
                    byte min = 0; byte max = 0;
                    for (int k = 0; k < 3; k++)     // Find min of R, G, B
                    {
                        min = R;
                        if (min >= G)
                        {
                            min = G;
                        }
                        if (min >= B)
                        {
                            min = B;
                        }
                    }
                    for (int k = 0; k < 3; k++)     // Find max of R, G, B
                    {
                        max = R;
                        if (max <= G)
                        {
                            max = G;
                        }
                        if (max <= B)
                        {
                            max = B;
                        }
                    }

                    byte gray_lgt = (byte)((max + min) / 2);
                    Gray_Lightness.SetPixel(i, j, Color.FromArgb(A, gray_lgt, gray_lgt, gray_lgt));

                    // Luminance method  
                    byte gray_lumi = (byte)((0.2126 * R + 0.7152 * G + 0.0722 * B));
                    Gray_Lumi.SetPixel(i, j, Color.FromArgb(A, gray_lumi, gray_lumi, gray_lumi));

                }
            }

            // Display the grayscale images in pictureBox2, pictureBox3, and pictureBox4
            pictureBox2.Image = Gray_Avg;
            pictureBox3.Image = Gray_Lightness;
            pictureBox4.Image = Gray_Lumi;
        }

        // Additional event handlers (not modified in this comment)
        private void imageBox3_Click(object sender, EventArgs e) { }
        private void imageBox1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox4_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
