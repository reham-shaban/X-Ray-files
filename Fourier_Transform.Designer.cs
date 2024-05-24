namespace Segment_Color_Mappin
{
    partial class Fourier_Transform
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
            this.image1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).BeginInit();
            this.SuspendLayout();
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(246, 26);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(512, 512);
            this.image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image1.TabIndex = 0;
            this.image1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Upload Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(876, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 63);
            this.button2.TabIndex = 2;
            this.button2.Text = "Enhance Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(897, 522);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Fourier_Transform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 582);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.image1);
            this.Name = "Fourier_Transform";
            this.Text = "Fourier_Transform";
            ((System.ComponentModel.ISupportInitialize)(this.image1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox image1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}