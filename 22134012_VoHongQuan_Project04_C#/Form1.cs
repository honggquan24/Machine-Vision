using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22134012_VoHongQuan_Project04_C_
{
    public partial class Form1 : Form
    {
        // Creat new bitmap variable to store the original image
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

        // Display the grayscale 
        pictureBox2.Image = ConvertToGrayscaleImage(original_image); 

        }

        public Bitmap ConvertToGrayscaleImage(Bitmap original_image)
        {
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

                    // Convert to grayscale using Luminance method
                    byte grayLuminance = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);

                    // Set values of grayscale image 
                    grayImage.SetPixel(x, y, Color.FromArgb(A, grayLuminance, grayLuminance, grayLuminance));
                }
            }
            return grayImage;
        }

        public Bitmap ConvertToBinaryImage(Bitmap original_image, byte threshold_1)
        {
            // Create a new bitmap for the grayscale image
            Bitmap binaryImage = new Bitmap(original_image.Width, original_image.Height);

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

                    // Convert to grayscale using Luminance method
                    byte luminaceValue = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);

                    // Create new byte variable to store value
                    byte binaryValue; 

                    // Compare luminance value with threshold to assign binary value 
                    if (luminaceValue > threshold_1)
                    {
                        binaryValue = 255;
                    }
                    else binaryValue = 0;

                    // Set values of grayscale image 
                    binaryImage.SetPixel(x, y, Color.FromArgb(A, binaryValue, binaryValue, binaryValue));
                }
            }
            return binaryImage;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Get the threshold value from the scroll bar's value
            byte threshold = (byte)vScrollBar1.Value;

            // Update the label to display the current threshold value
            lbl_thresh_value.Text = threshold.ToString();

            // Convert the original image to binary image using the new threshold value,
            // and update pictureBox3.Image to display the binary image
            pictureBox3.Image = ConvertToBinaryImage(original_image, threshold); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void vS_threshold_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
