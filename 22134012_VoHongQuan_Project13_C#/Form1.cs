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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _22134012_VoHongQuan_Project13_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap image = new Bitmap(@"C:\Data\Machine Vision\lena_color.png");
            //pictureBox1.Image = origin_image;

            var result = chonvungquet(image, 80, 400, 150, 500);

            Bitmap roiImage = result.Item1 as Bitmap;
            double Ravg = result.Item2;
            double Gavg = result.Item3;
            double Bavg = result.Item4;
            Console.WriteLine(Gavg);

            Bitmap segmentedImage = applySegmentation(image, Ravg, Gavg, Bavg, 150);

            pictureBox1.Image = image;
            pictureBox2.Image = segmentedImage;

        }

        public (Bitmap, double, double, double) chonvungquet(Bitmap image, int x1, int y1, int x2, int y2)
        {
            // Xác định tọa độ lớn nhất và nhỏ nhất để tạo ra một khu vực chữ nhật
            int maxx = (x1 < x2) ? x2 : x1;
            int maxy = (y1 < y2) ? y2 : y1;
            int minx = (x2 < x1) ? x2 : x1;
            int miny = (y2 < y1) ? y2 : y1;

            // Khởi tạo giá trị trung bình của màu sắc ban đầu là 0
            double Ravg = 0;
            double Gavg = 0;
            double Bavg = 0;

            // Tạo một bản sao của hình ảnh ban đầu để vẽ lên đó
            Bitmap roiImage = new Bitmap(image);

            // In ra giá trị trung bình của màu sắc (lúc này vẫn là 0)
            Console.WriteLine(Ravg.ToString() + Gavg.ToString() + Bavg.ToString());

            double area = 0; // Biến để tính diện tích của khu vực chọn
            for (int i = minx; i < maxx; i++)
            {
                for (int j = miny; j < maxy; j++)
                {
                    Color pixelVal = image.GetPixel(i, j); // Lấy giá trị màu sắc của từng pixel

                    // Cộng dồn giá trị màu sắc
                    double R = pixelVal.R;
                    double G = pixelVal.G;
                    double B = pixelVal.B;

                    Ravg += R; Gavg += G; Bavg += B;

                    // Nếu pixel nằm ở cạnh của khu vực chọn, đặt màu của nó thành màu trắng 
                    if (i + 1 == maxx || i == minx || j + 1 == maxy || j == miny)
                    {
                        roiImage.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }

                    area++; // Tính tổng số pixel trong khu vực, tương đương với diện tích
                }
            }

            // Tính giá trị trung bình của màu sắc cho khu vực chọn
            Ravg /= area;
            Gavg /= area;
            Bavg /= area;

            // Trả về hình ảnh đã chỉnh sửa và giá trị trung bình của màu sắc R, G, B
            return (roiImage, Ravg, Gavg, Bavg);
        }


        public Bitmap applySegmentation(Bitmap image, double Ravg, double Gavg, double Bavg, int threshold)
        {
            // Tạo một hình ảnh mới với kích thước giống hình ảnh ban đầu
            Bitmap segmentImage = new Bitmap(image.Width, image.Height);

            // Duyệt qua từng pixel của hình ảnh
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    // Lấy giá trị màu sắc của pixel hiện tại
                    Color pixelVal = image.GetPixel(i, j);

                    // Tách lấy giá trị màu R, G, B của pixel
                    double R = pixelVal.R;
                    double G = pixelVal.G;
                    double B = pixelVal.B;

                    // Tính khoảng cách màu giữa pixel hiện tại và màu trung bình đã được tính toán trước đó
                    double D = Math.Sqrt(Math.Pow(R - Ravg, 2) + Math.Pow(G - Gavg, 2) + Math.Pow(B - Bavg, 2));

                    // In ra khoảng cách màu (chủ yếu để debug, có thể bỏ qua trong sản phẩm cuối cùng)
                    Console.Write(D + " ");

                    // Nếu khoảng cách màu nhỏ hơn ngưỡng cho trước, đặt pixel này thành màu trắng
                    if (D < threshold)
                    {
                        segmentImage.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        // Nếu không, giữ nguyên giá trị màu sắc của pixel
                        segmentImage.SetPixel(i, j, Color.FromArgb((byte)R, (byte)G, (byte)B));
                    }
                }
                // Xuống dòng sau khi xử lý xong một hàng, giúp việc debug dễ dàng hơn
                Console.WriteLine();
            }

            // Trả về hình ảnh sau khi áp dụng phân đoạn
            return segmentImage;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: Add any initialization code here
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional: Add any event handling code here
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
