namespace _22134012_VoHongQuan_Project04_C_
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.lbl_BinaryImage = new System.Windows.Forms.Label();
            this.vScroll_bar = new System.Windows.Forms.Label();
            this.lbl_threshold = new System.Windows.Forms.Label();
            this.lbl_thresh_value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(60, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(460, 78);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(848, 78);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(300, 300);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1195, 77);
            this.vScrollBar1.Maximum = 255;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(29, 300);
            this.vScrollBar1.TabIndex = 3;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // lbl_BinaryImage
            // 
            this.lbl_BinaryImage.AutoSize = true;
            this.lbl_BinaryImage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_BinaryImage.Location = new System.Drawing.Point(845, 45);
            this.lbl_BinaryImage.Name = "lbl_BinaryImage";
            this.lbl_BinaryImage.Size = new System.Drawing.Size(86, 16);
            this.lbl_BinaryImage.TabIndex = 4;
            this.lbl_BinaryImage.Text = "Binary Image";
            // 
            // vScroll_bar
            // 
            this.vScroll_bar.AutoSize = true;
            this.vScroll_bar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.vScroll_bar.Location = new System.Drawing.Point(1192, 45);
            this.vScroll_bar.Name = "vScroll_bar";
            this.vScroll_bar.Size = new System.Drawing.Size(75, 16);
            this.vScroll_bar.TabIndex = 5;
            this.vScroll_bar.Text = "vScroll_bar";
            // 
            // lbl_threshold
            // 
            this.lbl_threshold.AutoSize = true;
            this.lbl_threshold.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_threshold.Location = new System.Drawing.Point(1248, 78);
            this.lbl_threshold.Name = "lbl_threshold";
            this.lbl_threshold.Size = new System.Drawing.Size(68, 16);
            this.lbl_threshold.TabIndex = 6;
            this.lbl_threshold.Text = "threshold: ";
            this.lbl_threshold.Click += new System.EventHandler(this.vS_threshold_Click);
            // 
            // lbl_thresh_value
            // 
            this.lbl_thresh_value.AutoSize = true;
            this.lbl_thresh_value.Location = new System.Drawing.Point(1323, 77);
            this.lbl_thresh_value.Name = "lbl_thresh_value";
            this.lbl_thresh_value.Size = new System.Drawing.Size(0, 16);
            this.lbl_thresh_value.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 496);
            this.Controls.Add(this.lbl_thresh_value);
            this.Controls.Add(this.lbl_threshold);
            this.Controls.Add(this.vScroll_bar);
            this.Controls.Add(this.lbl_BinaryImage);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label lbl_BinaryImage;
        private System.Windows.Forms.Label vScroll_bar;
        private System.Windows.Forms.Label lbl_threshold;
        private System.Windows.Forms.Label lbl_thresh_value;
    }
}

