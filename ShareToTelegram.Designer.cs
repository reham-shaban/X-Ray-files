namespace Segment_Color_Mappin
{
    partial class ShareToTelegram
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button Sharebtn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Sharebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sharebtn
            // 
            this.Sharebtn.Location = new System.Drawing.Point(350, 400);
            this.Sharebtn.Name = "Sharebtn";
            this.Sharebtn.Size = new System.Drawing.Size(100, 50);
            this.Sharebtn.TabIndex = 0;
            this.Sharebtn.Text = "Share to Telegram";
            this.Sharebtn.UseVisualStyleBackColor = true;
            // 
            // ShareToTelegram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Sharebtn);
            this.Name = "ShareToTelegram";
            this.Text = "Share to Telegram";
            this.ResumeLayout(false);
        }
    }
}
