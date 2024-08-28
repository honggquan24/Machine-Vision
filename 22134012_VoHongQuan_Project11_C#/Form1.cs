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

namespace _22134012_VoHongQuan_Project11_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap origin_image = new Bitmap(@"C:\Data\Machine Vision\lena_color.png");
            pictureBox1.Image = origin_image;

            Bitmap smooth_image = ColorImageSmooth(origin_image, 9);
            pictureBox2.Image = smooth_image;
        }

        public Bitmap ColorImageSmooth(Bitmap origin_image, int kernerSize)
        {
            int padding = (kernerSize - 1) / 2;
            Bitmap SmoothImage = new Bitmap(origin_image.Width, origin_image.Height);

            for (int x = padding; x < origin_image.Height - padding; x++)
            {
                for (int y = padding; y < origin_image.Width - padding; y++)
                {
                    float Rs = 0, Gs = 0, Bs = 0;

                    for (int i = x - padding; i < x + padding + 1; i++)
                    {
                        for (int j = y - padding; j < y + padding + 1; j++)
                        {
                            Color color = origin_image.GetPixel(i, j);
                            float R = (float)color.R;
                            float G = (float)color.G;
                            float B = (float)color.B;

                            Rs += R;
                            Gs += G;
                            Bs += B;
                        }
                    }

                    float K = kernerSize * kernerSize;
                    byte Rbyte = (byte)(Rs / K);
                    byte Gbyte = (byte)(Gs / K);
                    byte Bbyte = (byte)(Bs / K);

                    SmoothImage.SetPixel(x, y, Color.FromArgb(Rbyte, Gbyte, Bbyte));
                }
            }

            return SmoothImage;
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
