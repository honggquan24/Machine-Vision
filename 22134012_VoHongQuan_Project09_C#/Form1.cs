using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22134012_VoHongQuan_Project09_C_
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

            List<Bitmap> XYZ = ConvertBGRToXYZ(original_image);

            pictureBox2.Image = XYZ[0];
            pictureBox3.Image = XYZ[1];
            pictureBox4.Image = XYZ[2];
            pictureBox5.Image = XYZ[3];

            Console.WriteLine("array 5x5");
        }

        public List<Bitmap> ConvertBGRToXYZ(Bitmap original_image)
        {
            List<Bitmap> XYZ = new List<Bitmap>();

            // Create a new bitmap for the grayscale image
            Bitmap X_layer = new Bitmap(original_image.Width, original_image.Height);
            Bitmap Y_layer = new Bitmap(original_image.Width, original_image.Height);
            Bitmap Z_layer = new Bitmap(original_image.Width, original_image.Height);


            // Create a new bitmap for the grayscale image
            Bitmap XYZ_Img = new Bitmap(original_image.Width, original_image.Height);

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

                    double X = (0.4124564 * R + 0.3575761 * G + 0.18043757 * B);

                    double Y = (0.2126729 * R + 0.7151522 * G + 0.0721750 * B);

                    double Z = (0.0193339 * R + 0.1191920 * G + 0.9503041 * B);

                    // Set values of grayscale image 
                    X_layer.SetPixel(x, y, Color.FromArgb((byte)X, (byte)X, (byte)X));

                    Y_layer.SetPixel(x, y, Color.FromArgb((byte)Y, (byte)Y, (byte)Y));

                    Z_layer.SetPixel(x, y, Color.FromArgb((byte)Z, (byte)Z, (byte)Z));

                    XYZ_Img.SetPixel(x, y, Color.FromArgb((byte)X, (byte)Y, (byte)Z));
                }
            }

            XYZ.Add(X_layer);
            XYZ.Add(Y_layer);
            XYZ.Add(Z_layer);
            XYZ.Add(XYZ_Img);


            return XYZ;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
