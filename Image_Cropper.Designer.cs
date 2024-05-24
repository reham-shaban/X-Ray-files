namespace Segment_Color_Mappin
{
    partial class Image_Cropper
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
            this.button1 = new System.Windows.Forms.Button();
            this.image1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.image2 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Upload an Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // image1
            // 
            this.image1.Location = new System.Drawing.Point(23, 44);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(315, 295);
            this.image1.TabIndex = 1;
            this.image1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(809, 518);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(283, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "Crop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // image2
            // 
            this.image2.Location = new System.Drawing.Point(410, 44);
            this.image2.Name = "image2";
            this.image2.Size = new System.Drawing.Size(315, 295);
            this.image2.TabIndex = 4;
            this.image2.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Rectangle",
            "Circle",
            "Ellipse",
            "Free Select"});
            this.listBox1.Location = new System.Drawing.Point(765, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 68);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Image_Cropper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 582);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.image2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.image1);
            this.Controls.Add(this.button1);
            this.Name = "Image_Cropper";
            this.Text = "Image_Cropper";
            ((System.ComponentModel.ISupportInitialize)(this.image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox image1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox image2;
        private System.Windows.Forms.ListBox listBox1;
    }

}