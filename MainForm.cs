using System;
using System.Windows.Forms;

namespace Segment_Color_Mappin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnForm1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void BtnSearchForm_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void BtnImageCompare_Click(object sender, EventArgs e)
        {
            ImageCompare imageCompare = new ImageCompare();
            imageCompare.Show();
        }

        private void BtnReportForm_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        private void BtnImageAnalysis_Click(object sender, EventArgs e)
        {
            ImageAnalysis imageAnalysis = new ImageAnalysis();
            imageAnalysis.Show();
        }

        private void BtnImageCropper_Click(object sender, EventArgs e)
        {
            Image_Cropper imageCropper = new Image_Cropper();
            imageCropper.Show();
        }

        private void BtnFourierTransform_Click(object sender, EventArgs e)
        {
            Fourier_Transform fourierTransform = new Fourier_Transform();
            fourierTransform.Show();
        }

        private void BtnShareToTelegram_Click(object sender, EventArgs e)
        {
            ShareToTelegram shareToTelegram = new ShareToTelegram();
            shareToTelegram.Show();
        }
    }
}
