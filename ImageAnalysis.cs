using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segment_Color_Mappin
{
    public partial class ImageAnalysis : Form
    {
        private Point _startPoint;
        private Rectangle _selectionRectangle;

        public ImageAnalysis()
        {
            InitializeComponent();
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.Paint += PictureBox_Paint;
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = new Bitmap(openFileDialog.FileName);
                _selectionRectangle = Rectangle.Empty; // Reset selection rectangle upon image upload
                pictureBox.Invalidate();
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
            _selectionRectangle = new Rectangle(e.X, e.Y, 0, 0);
            pictureBox.Invalidate();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _selectionRectangle = new Rectangle(
                Math.Min(_startPoint.X, e.X),
                Math.Min(_startPoint.Y, e.Y),
                Math.Abs(_startPoint.X - e.X),
                Math.Abs(_startPoint.Y - e.Y));

            pictureBox.Invalidate();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // Perform analysis here if needed
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_selectionRectangle.Width > 0 && _selectionRectangle.Height > 0)
            {
                e.Graphics.DrawRectangle(Pens.Red, _selectionRectangle);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // Analyze the selected area and determine the severity
            if (_selectionRectangle.Width > 0 && _selectionRectangle.Height > 0 && pictureBox.Image != null)
            {
                Bitmap selectedPart = new Bitmap(_selectionRectangle.Width, _selectionRectangle.Height);
                using (Graphics g = Graphics.FromImage(selectedPart))
                {
                    g.DrawImage(pictureBox.Image, new Rectangle(0, 0, selectedPart.Width, selectedPart.Height), _selectionRectangle, GraphicsUnit.Pixel);
                }

                // Analyze the selected area to determine the severity
                string severity = DetermineSeverity(selectedPart);
                MessageBox.Show($"Condition Severity: {severity}", "Analysis Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an area to analyze.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string DetermineSeverity(Bitmap selectedPart)
        {
            int mildCount = 0;
            int moderateCount = 0;
            int severeCount = 0;

            int width = selectedPart.Width;
            int height = selectedPart.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = selectedPart.GetPixel(x, y);
                    double brightness = pixelColor.GetBrightness();

                    if (brightness < 0.3)
                    {
                        mildCount++;
                    }
                    else if (brightness < 0.6)
                    {
                        moderateCount++;
                    }
                    else
                    {
                        severeCount++;
                    }
                }
            }

            if (severeCount > moderateCount && severeCount > mildCount)
            {
                return "High-grade inflammation";
            }
            else if (moderateCount > mildCount && moderateCount > severeCount)
            {
                return "Moderate inflammation";
            }
            else
            {
                return "Low-grade inflammation";
            }
        }
    }


}
