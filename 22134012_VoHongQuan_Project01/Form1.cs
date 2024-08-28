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
using Emgu.Util; 

namespace _22134012_VoHongQuan_Project01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Initialize the form components
            InitializeComponent();

            // Path to the input image
            string fileImagePath = @"C:\Môn học\Machine Learning\lena_color.png";

            // Load the original image
            Bitmap imageOriginal = new Bitmap(fileImagePath);

            // Display the original image in the PictureBox
            pictureBox_HinhGoc.Image = imageOriginal;

            // Create separate bitmaps for red, green, and blue channels
            Bitmap redChannel = new Bitmap(imageOriginal.Height, imageOriginal.Width);
            Bitmap greenChannel = new Bitmap(imageOriginal.Height, imageOriginal.Width);
            Bitmap blueChannel = new Bitmap(imageOriginal.Height, imageOriginal.Width);

            // Loop through each pixel in the original image
            for (int i = 0; i < imageOriginal.Height; i++)
            {
                for (int j = 0; j < imageOriginal.Width; j++)
                {
                    // Get the color of the current pixel
                    Color pixel = imageOriginal.GetPixel(j, i);

                    // Extract the individual color components
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte A = pixel.A;

                    // Create a new color with only the red component
                    redChannel.SetPixel(j, i, Color.FromArgb(A, R, 0, 0));

                    // Create a new color with only the green component
                    greenChannel.SetPixel(j, i, Color.FromArgb(A, 0, G, 0));

                    // Create a new color with only the blue component
                    blueChannel.SetPixel(j, i, Color.FromArgb(A, 0, 0, B));
                }
            }

            // Display the red channel in the PictureBox
            pictureBox_Red.Image = redChannel;

            // Display the green channel in the PictureBox
            pictureBox_Green.Image = greenChannel;

            // Display the blue channel in the PictureBox
            pictureBox_Blue.Image = blueChannel;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_HinhGoc_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
