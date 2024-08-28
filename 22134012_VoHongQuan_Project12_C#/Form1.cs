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

namespace _22134012_VoHongQuan_Project12_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap origin_image = new Bitmap(@"C:\Data\Machine Vision\lena_color.png");
            pictureBox1.Image = origin_image;

            Bitmap sharpening_image = conv2D(origin_image);
            pictureBox2.Image = sharpening_image;
        }



        public Bitmap conv2D(Bitmap image)
        {
            // Tạo một hình ảnh mới để lưu kết quả sau khi áp dụng bộ lọc
            Bitmap convoluted = new Bitmap(image.Width, image.Height);

            // Định nghĩa một kernel (bộ lọc) để áp dụng lên hình ảnh
            double[,] kernel = { { 0, 1, 0},
                         { 1, -4, 1},
                         { 0, 1, 0}};

            // Duyệt qua từng pixel của hình ảnh
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    double R = 0;
                    double G = 0;
                    double B = 0;

                    // Tính tọa độ trung tâm của kernel
                    int kernelCenterWidth = kernel.GetLength(1) / 2;
                    int kernelCenterHeight = kernel.GetLength(0) / 2;

                    // Duyệt qua từng phần tử của kernel
                    for (int k = 0; k < kernel.GetLength(1); k++)
                    {
                        for (int l = 0; l < kernel.GetLength(0); l++)
                        {
                            // Tính tọa độ của pixel trên hình ảnh tương ứng với phần tử kernel đang xét
                            int x_coor = i + k - kernelCenterWidth;
                            int y_coor = j + l - kernelCenterHeight;

                            // Kiểm tra nếu tọa độ nằm trong phạm vi của hình ảnh
                            if (x_coor >= 0 && y_coor >= 0 && x_coor < image.Width && y_coor < image.Height)
                            {
                                Color pixelVal1 = image.GetPixel(x_coor, y_coor);

                                // Áp dụng bộ lọc kernel lên giá trị màu sắc của pixel
                                R += (double)pixelVal1.R * kernel[l, k];
                                G += (double)pixelVal1.G * kernel[l, k];
                                B += (double)pixelVal1.B * kernel[l, k];
                            }
                        }
                    }

                    // Điều chỉnh giá trị màu sắc sau khi áp dụng bộ lọc để không vượt quá giới hạn [0, 255]
                    Color pixelVal2 = image.GetPixel(i, j);

                    // Tính toán giá trị màu mới sau khi áp dụng bộ lọc, bằng cách trừ giá trị tích chập đã tính từ giá trị màu gốc của pixel
                    double Rtemp = (double)pixelVal2.R - R;
                    double Gtemp = (double)pixelVal2.G - G;
                    double Btemp = (double)pixelVal2.B - B;

                    // Điều chỉnh các giá trị màu để chúng không vượt quá giới hạn [0, 255]
                    // Nếu giá trị màu lớn hơn 255, sẽ được đặt bằng 255 (màu sắc tối đa)
                    // Nếu giá trị màu nhỏ hơn 0, sẽ được đặt bằng 0 (không màu)
                    // Các giá trị hợp lệ sẽ được giữ nguyên
                    byte Rbyte = (byte)((Rtemp > 255) ? 255 : (Rtemp < 0) ? 0 : Rtemp);
                    byte Gbyte = (byte)((Gtemp > 255) ? 255 : (Gtemp < 0) ? 0 : Gtemp);
                    byte Bbyte = (byte)((Btemp > 255) ? 255 : (Btemp < 0) ? 0 : Btemp);


                    // Cập nhật giá trị pixel mới sau khi áp dụng bộ lọc
                    convoluted.SetPixel(i, j, Color.FromArgb(Rbyte, Gbyte, Bbyte));
                }
            }

            // Trả về hình ảnh sau khi đã áp dụng bộ lọc 2D
            return convoluted;
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
