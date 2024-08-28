using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22134012_VoHongQuan_Project14_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap origin_image = new Bitmap(@"C:\Data\Machine Vision\lena_color.png");
            pictureBox1.Image = origin_image;

            Bitmap gray_image = ConvertToGrayscaleImage(origin_image);
            Bitmap sobel_image = EgdeGray(gray_image, 15);
            pictureBox2.Image = sobel_image;

            //Bitmap sobel_image_c = EdgeColor(origin_image, 100);
            //pictureBox2.Image = sobel_image_c;
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

        public Bitmap EgdeGray(Bitmap HinhGoc, int Nguong)
        {
            int[,] Sx = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            int[,] Sy = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

            Bitmap AnhDuongBien = new Bitmap(HinhGoc.Width, HinhGoc.Height);

            for (int x = 1; x < HinhGoc.Width - 1; x++)
            {
                for (int y = 1; y < HinhGoc.Height - 1; y++)
                {
                    int gx = 0;
                    int gy = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = HinhGoc.GetPixel(x + i, y + j);
                            int intensity = pixel.R;
                            gx += intensity * Sx[i + 1, j + 1];
                            gy += intensity * Sy[i + 1, j + 1];
                        }
                    }

                    int gradientMagnitude = Math.Abs(gx) + Math.Abs(gy);
                    if (gradientMagnitude > Nguong)
                        AnhDuongBien.SetPixel(x, y, Color.White);
                    else
                        AnhDuongBien.SetPixel(x, y, Color.Black);
                }
            }

            return AnhDuongBien;
        }

        public Bitmap EdgeColor(Bitmap HinhGoc, int Nguong)
        {
            int[,] Sx = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            int[,] Sy = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

            Bitmap AnhDuongBien = new Bitmap(HinhGoc.Width, HinhGoc.Height);

            for (int x = 1; x < HinhGoc.Width - 1; x++)
            {
                for (int y = 1; y < HinhGoc.Height - 1; y++)
                {
                    int gxx = 0, gyy = 0, gxy = 0, gxR = 0, gxG = 0, gxB = 0, gyR = 0, gyG = 0, gyB = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = HinhGoc.GetPixel(x + i, y + j);

                            gxR += pixel.R * Sx[i + 1, j + 1];
                            gyR += pixel.R * Sy[i + 1, j + 1];
                            gxG += pixel.G * Sx[i + 1, j + 1];
                            gyG += pixel.G * Sy[i + 1, j + 1];
                            gxB += pixel.B * Sx[i + 1, j + 1];
                            gyB += pixel.B * Sy[i + 1, j + 1];

                        }
                    }

                    gxx = Math.Abs(gxR) * Math.Abs(gxR) + Math.Abs(gxG) * Math.Abs(gxG) + Math.Abs(gxB) * Math.Abs(gxB);
                    gyy = Math.Abs(gyR) * Math.Abs(gyR) + Math.Abs(gyG) * Math.Abs(gyG) + Math.Abs(gyB) * Math.Abs(gyB);
                    gxy = Math.Abs(gxR) * Math.Abs(gyR) + Math.Abs(gxB) * Math.Abs(gyB) + Math.Abs(gxG) * Math.Abs(gyG);

                    double theta = 0.5 * Math.Atan2((2 * gxy), (gxx - gyy));

                    double F0 = Math.Sqrt(0.5 * ((gxx + gyy) + (gxx - gyy) * Math.Cos(2 * theta)));

                    if (F0 >= Nguong)
                        AnhDuongBien.SetPixel(x, y, Color.White);
                    else
                        AnhDuongBien.SetPixel(x, y, Color.Black);
                }
            }

            return AnhDuongBien;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: Add any initialization code here
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional: Add any event handling code here
        }
    }
}
