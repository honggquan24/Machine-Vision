namespace _22134012_VoHongQuan_Project01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_HinhGoc = new System.Windows.Forms.PictureBox();
            this.pictureBox_Red = new System.Windows.Forms.PictureBox();
            this.pictureBox_Blue = new System.Windows.Forms.PictureBox();
            this.pictureBox_Green = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Green)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_HinhGoc
            // 
            this.pictureBox_HinhGoc.Location = new System.Drawing.Point(72, 13);
            this.pictureBox_HinhGoc.Name = "pictureBox_HinhGoc";
            this.pictureBox_HinhGoc.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_HinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_HinhGoc.TabIndex = 0;
            this.pictureBox_HinhGoc.TabStop = false;
            this.pictureBox_HinhGoc.Click += new System.EventHandler(this.pictureBox_HinhGoc_Click);
            // 
            // pictureBox_Red
            // 
            this.pictureBox_Red.Location = new System.Drawing.Point(640, 12);
            this.pictureBox_Red.Name = "pictureBox_Red";
            this.pictureBox_Red.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_Red.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Red.TabIndex = 1;
            this.pictureBox_Red.TabStop = false;
            // 
            // pictureBox_Blue
            // 
            this.pictureBox_Blue.Location = new System.Drawing.Point(640, 531);
            this.pictureBox_Blue.Name = "pictureBox_Blue";
            this.pictureBox_Blue.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_Blue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Blue.TabIndex = 2;
            this.pictureBox_Blue.TabStop = false;
            // 
            // pictureBox_Green
            // 
            this.pictureBox_Green.Location = new System.Drawing.Point(72, 531);
            this.pictureBox_Green.Name = "pictureBox_Green";
            this.pictureBox_Green.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_Green.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Green.TabIndex = 3;
            this.pictureBox_Green.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(598, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "RED";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "BLUE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hình gốc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "GREEN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 1055);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Green);
            this.Controls.Add(this.pictureBox_Blue);
            this.Controls.Add(this.pictureBox_Red);
            this.Controls.Add(this.pictureBox_HinhGoc);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Name = "Form1";
            this.Text = "Hình hiển thị: ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_HinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Green)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_HinhGoc;
        private System.Windows.Forms.PictureBox pictureBox_Red;
        private System.Windows.Forms.PictureBox pictureBox_Blue;
        private System.Windows.Forms.PictureBox pictureBox_Green;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

