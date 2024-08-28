using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22134012_VoHongQuan_Project10_C_
{
    public partial class Form1 : Form
    {
        Bitmap original_image;
        public Form1()
        {
            InitializeComponent();
            // Load the original image from file 
            string file_path = @"C:\Data\Machine Vision\lena_color.png";

            // Load image 
            original_image = new Bitmap(file_path);

            // Display the original image in pictureBox1
            pictureBox1.Image = original_image;

            List<Bitmap> YCbCr = ConvertBGRToYCbCr(original_image);

            pictureBox2.Image = YCbCr[0];
            pictureBox3.Image = YCbCr[1];
            pictureBox4.Image = YCbCr[2];
            pictureBox5.Image = YCbCr[3];

            Console.WriteLine("array 5x5");
        }

        public List<Bitmap> ConvertBGRToYCbCr(Bitmap original_image)
        {
            List<Bitmap> YCbCr = new List<Bitmap>();

            // Create a new bitmap for the grayscale image
            Bitmap Y_img = new Bitmap(original_image.Width, original_image.Height);
            Bitmap Cb_img = new Bitmap(original_image.Width, original_image.Height);
            Bitmap Cr_img = new Bitmap(original_image.Width, original_image.Height);


            // Create a new bitmap for the grayscale image
            Bitmap YCbCr_Img = new Bitmap(original_image.Width, original_image.Height);

            // Loop through each pixel in the original image
            for (int x = 0; x < original_image.Width; x++)
            {
                for (int y = 0; y < original_image.Height; y++)
                {
                    // Get the color of the current pixel
                    Color pixel = original_image.GetPixel(x, y);

                    // Color channels 
                    double R = pixel.R;
                    double G = pixel.G;
                    double B = pixel.B;

                    double Y = 16 +  (65.738 / 256 * R + 129.057 / 256 * G + 25.064 / 256 * B);

                    double Cb = 128 + (-37.945 / 256 * R -74.494 / 256 * G + 112.439 / 256 * B);

                    double Cr = 128 + (112.439 / 256 * R -94.154 / 256 * G - 18.285 / 256 * B);

                    // Set values of grayscale image 
                    Y_img.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Y, (byte)Y));

                    Cb_img.SetPixel(x, y, Color.FromArgb((byte)Cb, (byte)Cb, (byte)Cb));

                    Cr_img.SetPixel(x, y, Color.FromArgb((byte)Cr, (byte)Cr, (byte)Cr));

                    YCbCr_Img.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Cb, (byte)Cr));
                }
            }

            YCbCr.Add(Y_img);
            YCbCr.Add(Cb_img);
            YCbCr.Add(Cr_img);
            YCbCr.Add(YCbCr_Img);


            return YCbCr;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
