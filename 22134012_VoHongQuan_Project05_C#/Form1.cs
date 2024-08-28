using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph; 

namespace _22134012_VoHongQuan_Project05_C_
{
    public partial class Form1 : Form
    {
        Bitmap original_image;
        Bitmap gray_image;
        Bitmap red_image;
        Bitmap green_image;
        Bitmap blue_image;
        public Form1()
        {
            InitializeComponent();
            // Load the original image from file 
            string file_path = @"C:\Data\Machine Vision\22134012_VoHongQuan_Project05_C#\bird_small.jpg";

            // Load image 
            original_image = new Bitmap(file_path);
            gray_image = ConvertToGrayscaleImage(original_image);

            // Display the original image in pictureBox1
            pictureBox1.Image = original_image;
            pictureBox2.Image = gray_image;


            // Calculate Gray Histogram 
                double[] grayHistogram  = calculateGrayHistogram(original_image);

                // convert double to PointPairList
                PointPairList list1D = convertdtype1D(grayHistogram);

                zedGraphControl1.GraphPane = histogramGrayGraph(list1D);
                zedGraphControl1.Refresh();

            // Calculate BGR Histogram 
                double[,] rgbHistogram = calculateHistogramRGB(original_image);

                // convert double to PointPairList
                List<PointPairList> list3D = convertdtype3D(rgbHistogram);

                zedGraphControl2.GraphPane = histogramRGBGraph(list3D);
                zedGraphControl2.Refresh();


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

        public Bitmap ConvertToRedImage(Bitmap original_image)
        {
            // Create a new bitmap for the red image
            Bitmap redImage = new Bitmap(original_image.Width, original_image.Height);

            // Loop through each pixel in the original image
            for (int x = 0; x < original_image.Width; x++)
            {
                for (int y = 0; y < original_image.Height; y++)
                {
                    // Get the color of the current pixel
                    Color pixel = original_image.GetPixel(x, y);

                    // Color channels 
                    byte R = pixel.R;

                    // Set values of red image 
                    redImage.SetPixel(x, y, Color.FromArgb( R, 0, 0));
                }
            }
            return redImage;
        }

        public Bitmap ConvertToGreenImage(Bitmap original_image)
        {
            // Create a new bitmap for the green image
            Bitmap greenImage = new Bitmap(original_image.Width, original_image.Height);

            // Loop through each pixel in the original image
            for (int x = 0; x < original_image.Width; x++)
            {
                for (int y = 0; y < original_image.Height; y++)
                {
                    // Get the color of the current pixel
                    Color pixel = original_image.GetPixel(x, y);

                    // Color channels 
                    byte G = pixel.G;

                    // Set values of green image 
                    greenImage.SetPixel(x, y, Color.FromArgb( 0, G, 0));
                }
            }
            return greenImage;
        }

        public Bitmap ConvertToBlueImage(Bitmap original_image)
        {
            // Create a new bitmap for the blue image
            Bitmap blueImage = new Bitmap(original_image.Width, original_image.Height);

            // Loop through each pixel in the original image
            for (int x = 0; x < original_image.Width; x++)
            {
                for (int y = 0; y < original_image.Height; y++)
                {
                    // Get the color of the current pixel
                    Color pixel = original_image.GetPixel(x, y);

                    // Color channels 
                    byte B = pixel.B;
                    // Set values of red image 
                    blueImage.SetPixel(x, y, Color.FromArgb( 0, 0, B));
                }
            }
            return blueImage;
        }

        public double[] calculateGrayHistogram(Bitmap Image)
        {
            Bitmap grayImage = ConvertToGrayscaleImage(Image);
            double[] histogram = new double[256];
            for (int x = 0; x < grayImage.Width; x++)
            {
                for (int y = 0; y < grayImage.Height; y++)
                {
                    Color pixel = grayImage.GetPixel(x, y);
                    byte gray = pixel.R;

                    histogram[gray]++; 
                }
            }
            return histogram; 
        }

        public double[,] calculateHistogramRGB(Bitmap Image)
        {
            double[, ] histogram = new double[3, 256];
            for (int x = 0; x < Image.Width; x++)
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    Color pixel = Image.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    histogram[0, R]++;
                    histogram[1, G]++;
                    histogram[2, B]++;
                }
            }
            return histogram;
        }

        PointPairList convertdtype1D(double[] histogram)
        {
            PointPairList list = new PointPairList();
            for (int i = 0; i < histogram.Length; i++)
            {
                 list.Add(i , histogram[i]);
            }
            return list;
        }

        List<PointPairList> convertdtype3D(double[,] histogram)
        {
            List< PointPairList> list = new List<PointPairList>();
            PointPairList r = new PointPairList();
            PointPairList g = new PointPairList();
            PointPairList b = new PointPairList();

            for (int i = 0; i < histogram.Length / 3; i++)
            {
                r.Add(i, histogram[0, i]);
                g.Add(i, histogram[1, i]);
                b.Add(i, histogram[2, i]);
            }
            list.Add(r);
            list.Add(g);
            list.Add(b);

            return list;

        }

        public GraphPane histogramGrayGraph(PointPairList histogram) 
        {
            GraphPane graphPane = new GraphPane();

            graphPane.Title.Text = @"Histogram of Image";
            graphPane.Rect = new Rectangle(0, 0, 700, 400);

            graphPane.XAxis.Title.Text = @"Frequency";
            graphPane.XAxis.Scale.Min = 0;
            graphPane.XAxis.Scale.Max = 255;
            graphPane.XAxis.Scale.MajorStep = 5;
            graphPane.XAxis.Scale.MinorStep = 1;


            graphPane.YAxis.Title.Text = @"Value";
            graphPane.YAxis.Scale.Min = 0;
            graphPane.YAxis.Scale.Max = 15000;
            graphPane.YAxis.Scale.MajorStep = 5;
            graphPane.YAxis.Scale.MinorStep = 1;

            graphPane.AddBar(@"Histogram", histogram, Color.Gray); 

            return graphPane;
        }

        public GraphPane histogramRGBGraph(List<PointPairList> histogram)
        {
            GraphPane graphPane = new GraphPane();

            graphPane.Title.Text = @"Histogram of RGB Image";
            graphPane.Rect = new Rectangle(0, 0, 700, 400);

            graphPane.XAxis.Title.Text = @"Frequency";
            graphPane.XAxis.Scale.Min = 0;
            graphPane.XAxis.Scale.Max = 255;
            graphPane.XAxis.Scale.MajorStep = 5;
            graphPane.XAxis.Scale.MinorStep = 1;


            graphPane.YAxis.Title.Text = @"Value";
            graphPane.YAxis.Scale.Min = 0;
            graphPane.YAxis.Scale.Max = 15000;
            graphPane.YAxis.Scale.MajorStep = 5;
            graphPane.YAxis.Scale.MinorStep = 1;

            graphPane.AddBar(@"Histogram Red", histogram[0], Color.Red);
            graphPane.AddBar(@"Histogram Green", histogram[1], Color.Green);
            graphPane.AddBar(@"Histogram Blue", histogram[2], Color.Blue);

            return graphPane;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
