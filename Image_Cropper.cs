using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Segment_Color_Mappin
{
    public partial class Image_Cropper : Form
    {
        private enum ShapeType { Rectangle, Circle, Ellipse, FreeSelect };

        private Rectangle selectedRectangle;
        private bool isSelecting = false;
        private Point startPoint;
        private ShapeType selectedShape;
        private List<Point> freeSelectPoints = new List<Point>();


        private Bitmap rgbImage;

        public Image_Cropper()
        {
            InitializeComponent();
            image1.MouseDown += image1_MouseDown;
            image1.MouseMove += image1_MouseMove;
            image1.MouseUp += image1_MouseUp;
            image1.Paint += image1_Paint;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = dialog.FileName;
                    rgbImage = new Bitmap(imagePath);
                    image1.SizeMode = PictureBoxSizeMode.StretchImage;
                    image1.Image = rgbImage;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading image.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (image1.Image != null)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName;
                        image2.Image.Save(savePath);
                        MessageBox.Show("Image saved successfully.");
                    }
                }
                else
                {
                    MessageBox.Show("No image to save.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
            }
        }

        private void image1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedShape == ShapeType.FreeSelect)
                {
                    freeSelectPoints.Clear();
                    freeSelectPoints.Add(e.Location);
                    isSelecting = true;
                }
                else
                {
                    startPoint = e.Location;
                    isSelecting = true;
                }
            }
        }

        private void image1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                if (selectedShape == ShapeType.FreeSelect)
                {
                    freeSelectPoints.Add(e.Location);
                    image1.Invalidate();
                }
                else
                {
                    int x = Math.Min(e.X, startPoint.X);
                    int y = Math.Min(e.Y, startPoint.Y);
                    int width = Math.Abs(e.X - startPoint.X);
                    int height = Math.Abs(e.Y - startPoint.Y);

                    if (selectedShape == ShapeType.Rectangle)
                        selectedRectangle = new Rectangle(x, y, width, height);
                    else if (selectedShape == ShapeType.Circle)
                        selectedRectangle = GetCircleRectangle(startPoint, e.Location);
                    else if (selectedShape == ShapeType.Ellipse)
                        selectedRectangle = new Rectangle(x, y, width, height); // For simplicity, treating ellipse like rectangle

                    image1.Invalidate();
                }
            }
        }

        private void image1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isSelecting = false;
            }
        }

        private void image1_Paint(object sender, PaintEventArgs e)
        {
            if (selectedShape == ShapeType.FreeSelect && freeSelectPoints.Count > 1)
            {
                using (Pen pen = new Pen(Color.Yellow))
                {
                    e.Graphics.DrawLines(pen, freeSelectPoints.ToArray());
                }
            }
            else if (selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                using (Pen pen = new Pen(Color.Yellow))
                {
                    if (selectedShape == ShapeType.Circle)
                        e.Graphics.DrawEllipse(pen, selectedRectangle);
                    else if (selectedShape == ShapeType.Ellipse)
                        e.Graphics.DrawEllipse(pen, selectedRectangle); // Draw ellipse using the selected rectangle
                    else
                        e.Graphics.DrawRectangle(pen, selectedRectangle);
                }
            }
        }

        private Rectangle GetCircleRectangle(Point startPoint, Point endPoint)
        {
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(endPoint.X - startPoint.X);
            int height = Math.Abs(endPoint.Y - startPoint.Y);
            int diameter = Math.Min(width, height);

            return new Rectangle(x, y, diameter, diameter);
        }

        private Rectangle GetEllipseRectangle(Point startPoint, Point endPoint)
        {
            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(endPoint.X - startPoint.X);
            int height = Math.Abs(endPoint.Y - startPoint.Y);

            return new Rectangle(x, y, width, height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rgbImage == null)
            {
                MessageBox.Show("Please load an image.");
                return;
            }

            if (selectedShape != ShapeType.FreeSelect && (selectedRectangle.Width == 0 || selectedRectangle.Height == 0))
            {
                MessageBox.Show("Please select a cropping area.");
                return;
            }

            // Calculate scale factor
            float scaleX = (float)rgbImage.Width / image1.ClientSize.Width;
            float scaleY = (float)rgbImage.Height / image1.ClientSize.Height;

            // Crop the selected area
            Bitmap croppedImage = null;

            if (selectedShape == ShapeType.FreeSelect)
            {
                if (freeSelectPoints.Count < 3)
                {
                    MessageBox.Show("Please select a valid free select area.");
                    return;
                }
                else
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddPolygon(freeSelectPoints.ToArray());
                    path.CloseFigure();
                    RectangleF rect = path.GetBounds();
                    rect.X *= scaleX;
                    rect.Y *= scaleY;
                    rect.Width *= scaleX;
                    rect.Height *= scaleY;
                    croppedImage = CropImage(rgbImage, Rectangle.Round(rect));
                }
            }
            else
            {
                Rectangle adjustedRect = new Rectangle(
                    (int)(selectedRectangle.X * scaleX),
                    (int)(selectedRectangle.Y * scaleY),
                    (int)(selectedRectangle.Width * scaleX),
                    (int)(selectedRectangle.Height * scaleY)
                );
                croppedImage = CropImage(rgbImage, adjustedRect);
            }

            // Display the cropped image on image2
            image2.Image = croppedImage;
        }


        private Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (selectedShape == ShapeType.Circle)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(0, 0, section.Width, section.Height);
                    g.SetClip(path);
                    g.DrawImage(source, new Rectangle(0, 0, section.Width, section.Height), section, GraphicsUnit.Pixel);
                }
                else if (selectedShape == ShapeType.Ellipse)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(0, 0, section.Width, section.Height);
                    g.SetClip(path);
                    g.DrawImage(source, new Rectangle(0, 0, section.Width, section.Height), section, GraphicsUnit.Pixel);
                }
                else if (selectedShape == ShapeType.FreeSelect)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddPolygon(freeSelectPoints.ToArray());
                    path.CloseFigure();
                    g.SetClip(path);
                    g.DrawImage(source, new Rectangle(0, 0, section.Width, section.Height), section, GraphicsUnit.Pixel);
                }
                else
                {
                    g.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), section, GraphicsUnit.Pixel);
                }
            }

            return bmp;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Read the selected item from the ListBox and set the selected shape
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Rectangle":
                        selectedShape = ShapeType.Rectangle;
                        break;
                    case "Circle":
                        selectedShape = ShapeType.Circle;
                        break;
                    case "Ellipse":
                        selectedShape = ShapeType.Ellipse;
                        break;
                    case "Free Select":
                        selectedShape = ShapeType.FreeSelect;
                        break;
                    default:
                        selectedShape = ShapeType.Rectangle; // Default to Rectangle
                        break;
                }
            }
        }
    }
}
