using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22134012_VoHongQuan_Project_C__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap image = new Bitmap(@"C:\Data\Machine Vision\lena_color.png");

            Bitmap hue = new Bitmap(image.Width, image.Height);
            Bitmap saturation = new Bitmap(image.Width, image.Height);
            Bitmap intensity = new Bitmap(image.Width, image.Height);
            Bitmap hsi = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color color = image.GetPixel(i, j);

                    double R = (double)color.R;
                    double G = (double)color.G;
                    double B = (double)color.B;
                    byte A = color.A;

                    double numerator = ((R - G) + (R - B)) / 2;
                    double denominator = Math.Sqrt(Math.Pow(R - G, 2) + (R - B) * (G - B));

                    double theta = Math.Acos(numerator / denominator);
                    
                    byte H = (byte)(((B <= G) ? theta : 2 * Math.PI - theta) * 180 / Math.PI);

                    // Calculation of saturation 
                    double[] store = { R, G, B };
                    byte S = (byte)((1 - 3 / (R + G + B) * store.Min()) * 255);

                    // Calculation of intensity
                    byte I = (byte)((R + G + B) / 3);

                    hue.SetPixel(i, j, Color.FromArgb(A, H, H, H));
                    saturation.SetPixel(i, j, Color.FromArgb(A, S, S, S));
                    intensity.SetPixel(i, j, Color.FromArgb(A, I, I, I));
                    hsi.SetPixel(i, j, Color.FromArgb(A, H, S, I));
                }
            }

            originalBox.Image = new Image<Bgr, byte>(image);
            hueBox.Image = new Image<Bgr, byte>(hue);
            saturationBox.Image = new Image<Bgr, byte>(saturation);
            intensityBox.Image = new Image<Bgr, byte>(intensity);
            hsiBox.Image = new Image<Bgr, byte>(hsi);
        }
    }
}
