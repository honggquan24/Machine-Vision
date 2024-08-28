namespace _22134012_VoHongQuan_Project08_C_
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
            this.components = new System.ComponentModel.Container();
            this.originalBox = new Emgu.CV.UI.ImageBox();
            this.hueBox = new Emgu.CV.UI.ImageBox();
            this.saturationBox = new Emgu.CV.UI.ImageBox();
            this.valueBox = new Emgu.CV.UI.ImageBox();
            this.hsiBox = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.originalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hsiBox)).BeginInit();
            this.SuspendLayout();
            // 
            // originalBox
            // 
            this.originalBox.Location = new System.Drawing.Point(12, 12);
            this.originalBox.Name = "originalBox";
            this.originalBox.Size = new System.Drawing.Size(384, 384);
            this.originalBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalBox.TabIndex = 2;
            this.originalBox.TabStop = false;
            // 
            // hueBox
            // 
            this.hueBox.Location = new System.Drawing.Point(12, 439);
            this.hueBox.Name = "hueBox";
            this.hueBox.Size = new System.Drawing.Size(384, 384);
            this.hueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hueBox.TabIndex = 3;
            this.hueBox.TabStop = false;
            // 
            // saturationBox
            // 
            this.saturationBox.Location = new System.Drawing.Point(440, 439);
            this.saturationBox.Name = "saturationBox";
            this.saturationBox.Size = new System.Drawing.Size(384, 384);
            this.saturationBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saturationBox.TabIndex = 4;
            this.saturationBox.TabStop = false;
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(864, 439);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(384, 384);
            this.valueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.valueBox.TabIndex = 5;
            this.valueBox.TabStop = false;
            // 
            // hsiBox
            // 
            this.hsiBox.Location = new System.Drawing.Point(1286, 439);
            this.hsiBox.Name = "hsiBox";
            this.hsiBox.Size = new System.Drawing.Size(384, 384);
            this.hsiBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hsiBox.TabIndex = 6;
            this.hsiBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(435, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(7, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(435, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Saturation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(859, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(1281, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "HSV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 853);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hsiBox);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.saturationBox);
            this.Controls.Add(this.hueBox);
            this.Controls.Add(this.originalBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hsiBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox originalBox;
        private Emgu.CV.UI.ImageBox hueBox;
        private Emgu.CV.UI.ImageBox saturationBox;
        private Emgu.CV.UI.ImageBox valueBox;
        private Emgu.CV.UI.ImageBox hsiBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

