namespace Segment_Color_Mappin
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnForm1;
        private System.Windows.Forms.Button btnSearchForm;
        private System.Windows.Forms.Button btnImageCompare;
        private System.Windows.Forms.Button btnReportForm;
        private System.Windows.Forms.Button btnImageAnalysis;
        private System.Windows.Forms.Button btnImageCropper;
        private System.Windows.Forms.Button btnFourierTransform;
        private System.Windows.Forms.Button btnShareToTelegram;

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
            this.btnForm1 = new System.Windows.Forms.Button();
            this.btnSearchForm = new System.Windows.Forms.Button();
            this.btnImageCompare = new System.Windows.Forms.Button();
            this.btnReportForm = new System.Windows.Forms.Button();
            this.btnImageAnalysis = new System.Windows.Forms.Button();
            this.btnImageCropper = new System.Windows.Forms.Button();
            this.btnFourierTransform = new System.Windows.Forms.Button();
            this.btnShareToTelegram = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // 
            // btnForm1
            // 
            this.btnForm1.Location = new System.Drawing.Point(30, 30);
            this.btnForm1.Name = "btnForm1";
            this.btnForm1.Size = new System.Drawing.Size(200, 30);
            this.btnForm1.Text = "Open Form1";
            this.btnForm1.Click += new System.EventHandler(this.BtnForm1_Click);

            // 
            // btnSearchForm
            // 
            this.btnSearchForm.Location = new System.Drawing.Point(30, 70);
            this.btnSearchForm.Name = "btnSearchForm";
            this.btnSearchForm.Size = new System.Drawing.Size(200, 30);
            this.btnSearchForm.Text = "Open Search Form";
            this.btnSearchForm.Click += new System.EventHandler(this.BtnSearchForm_Click);

            // 
            // btnImageCompare
            // 
            this.btnImageCompare.Location = new System.Drawing.Point(30, 110);
            this.btnImageCompare.Name = "btnImageCompare";
            this.btnImageCompare.Size = new System.Drawing.Size(200, 30);
            this.btnImageCompare.Text = "Open Image Compare";
            this.btnImageCompare.Click += new System.EventHandler(this.BtnImageCompare_Click);

            // 
            // btnReportForm
            // 
            this.btnReportForm.Location = new System.Drawing.Point(30, 150);
            this.btnReportForm.Name = "btnReportForm";
            this.btnReportForm.Size = new System.Drawing.Size(200, 30);
            this.btnReportForm.Text = "Open Report Form";
            this.btnReportForm.Click += new System.EventHandler(this.BtnReportForm_Click);

            // 
            // btnImageAnalysis
            // 
            this.btnImageAnalysis.Location = new System.Drawing.Point(30, 190);
            this.btnImageAnalysis.Name = "btnImageAnalysis";
            this.btnImageAnalysis.Size = new System.Drawing.Size(200, 30);
            this.btnImageAnalysis.Text = "Open Image Analysis";
            this.btnImageAnalysis.Click += new System.EventHandler(this.BtnImageAnalysis_Click);

            // 
            // btnImageCropper
            // 
            this.btnImageCropper.Location = new System.Drawing.Point(30, 230);
            this.btnImageCropper.Name = "btnImageCropper";
            this.btnImageCropper.Size = new System.Drawing.Size(200, 30);
            this.btnImageCropper.Text = "Open Image Cropper";
            this.btnImageCropper.Click += new System.EventHandler(this.BtnImageCropper_Click);

            // 
            // btnFourierTransform
            // 
            this.btnFourierTransform.Location = new System.Drawing.Point(30, 270);
            this.btnFourierTransform.Name = "btnFourierTransform";
            this.btnFourierTransform.Size = new System.Drawing.Size(200, 30);
            this.btnFourierTransform.Text = "Open Fourier Transform";
            this.btnFourierTransform.Click += new System.EventHandler(this.BtnFourierTransform_Click);

            // 
            // btnShareToTelegram
            // 
            this.btnShareToTelegram.Location = new System.Drawing.Point(30, 310);
            this.btnShareToTelegram.Name = "btnShareToTelegram";
            this.btnShareToTelegram.Size = new System.Drawing.Size(200, 30);
            this.btnShareToTelegram.Text = "Open Share to Telegram";
            this.btnShareToTelegram.Click += new System.EventHandler(this.BtnShareToTelegram_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(280, 360);
            this.Controls.Add(this.btnForm1);
            this.Controls.Add(this.btnSearchForm);
            this.Controls.Add(this.btnImageCompare);
            this.Controls.Add(this.btnReportForm);
            this.Controls.Add(this.btnImageAnalysis);
            this.Controls.Add(this.btnImageCropper);
            this.Controls.Add(this.btnFourierTransform);
            this.Controls.Add(this.btnShareToTelegram);
            this.Text = "Main Form";
            this.ResumeLayout(false);
        }
    }
}
