using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22134012_VoHongQuan_Project06_C_
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

            List<Bitmap> CMYK = ConvertBGRToCYMK(original_image);

            pictureBox2.Image = CMYK[0];
            pictureBox3.Image = CMYK[1];
            pictureBox4.Image = CMYK[2];
            pictureBox5.Image = CMYK[3];

        }

        public List<Bitmap> ConvertBGRToCYMK(Bitmap original_image)
        {
            List<Bitmap> CMYK = new List<Bitmap>();

            // Create a new bitmap for the grayscale image
            Bitmap Cyan = new Bitmap(original_image.Width, original_image.Height);
            Bitmap Yellow = new Bitmap(original_image.Width, original_image.Height);
            Bitmap Magneta = new Bitmap(original_image.Width, original_image.Height);
            Bitmap Key = new Bitmap(original_image.Width, original_image.Height);

            // Create a new bitmap for the grayscale image
            Bitmap grayImage = new Bitmap(original_image.Width, original_image.Height);

            // Loop through each pixel in the original image
            for (int x = 0; x < original_image.Width; x++)
            {
                for (int y = 0; y < original_image.Height; y++)
                {
                    // Get the color of the current pixel
                    Color pixel = original_image.GetPixel(x, y);

                    // Color channels 
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte A = pixel.A;


                    // Set values of grayscale image 
                    Cyan.SetPixel(x, y, Color.FromArgb(0, G, B));

                    Yellow.SetPixel(x, y, Color.FromArgb(R, G, 0));

                    Magneta.SetPixel(x, y, Color.FromArgb(R, 0, B));

                    byte K = Math.Min(R, Math.Min(G, B));
                    Key.SetPixel(x, y, Color.FromArgb(K, K, K));
                }
            }

            CMYK.Add(Cyan);
            CMYK.Add(Magneta);
            CMYK.Add(Yellow);
            CMYK.Add(Key);


            return CMYK;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
