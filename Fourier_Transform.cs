using System;
using System.Drawing;
using System.Windows.Forms;
using MathNet.Numerics.IntegralTransforms;
using System.Drawing.Imaging;
using System.Numerics;
using AForge.Imaging;
using AForge.Math;


namespace Segment_Color_Mappin
{
    public partial class Fourier_Transform : Form
    {
        private Bitmap rgbImage;
        private Bitmap enhancedImage;

        public Fourier_Transform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All Files (*.*)|*.*";

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
                MessageBox.Show("Error loading image");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rgbImage == null)
                {
                    MessageBox.Show("Please load an image first.");
                    return;
                }

                // Convert RGB image to grayscale
                Bitmap grayImage = ConvertToGrayscale(rgbImage);

                // Create complex image from grayscale bitmap
                ComplexImage complexImage = ComplexImage.FromBitmap(grayImage);

                // Apply forward Fourier transformation
                complexImage.ForwardFourierTransform();

                // Apply Unsharp Masking
                ApplyUnsharpMasking(complexImage, 1.5);

                // Apply backward Fourier transformation
                complexImage.BackwardFourierTransform();

                // Convert complex image back to bitmap
                Bitmap enhancedImage = complexImage.ToBitmap();

                // Display the enhanced image
                image1.SizeMode = PictureBoxSizeMode.StretchImage;
                image1.Image = enhancedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing image: " + ex.Message);
            }
        }

        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            // Create a blank grayscale image
            Bitmap grayscale = new Bitmap(original.Width, original.Height, PixelFormat.Format8bppIndexed);

            // Set the palette to grayscale
            ColorPalette palette = grayscale.Palette;
            for (int i = 0; i < 256; i++)
            {
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }
            grayscale.Palette = palette;

            // Lock the bits for efficient access
            BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData grayscaleData = grayscale.LockBits(new Rectangle(0, 0, grayscale.Width, grayscale.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            // Convert each pixel
            unsafe
            {
                byte* originalPtr = (byte*)originalData.Scan0;
                byte* grayscalePtr = (byte*)grayscaleData.Scan0;
                int originalOffset = originalData.Stride - original.Width * 3;
                int grayscaleOffset = grayscaleData.Stride - grayscale.Width;

                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        // Get RGB values
                        byte blue = originalPtr[0];
                        byte green = originalPtr[1];
                        byte red = originalPtr[2];

                        // Convert to grayscale using the luminance formula
                        byte gray = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);

                        // Set the grayscale value
                        grayscalePtr[0] = gray;

                        // Move to the next pixel
                        originalPtr += 3;
                        grayscalePtr++;
                    }
                    originalPtr += originalOffset;
                    grayscalePtr += grayscaleOffset;
                }
            }

            // Unlock the bits
            original.UnlockBits(originalData);
            grayscale.UnlockBits(grayscaleData);

            return grayscale;
        }

        private void ApplyUnsharpMasking(ComplexImage complexImage, double factor)
        {
            int width = complexImage.Width;
            int height = complexImage.Height;
            AForge.Math.Complex[,] data = complexImage.Data;

            int centerX = width / 2;
            int centerY = height / 2;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int dx = x - centerX;
                    int dy = y - centerY;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    // Amplify high frequencies
                    data[y, x].Re *= (1 + factor * (distance / Math.Sqrt(centerX * centerX + centerY * centerY)));
                    data[y, x].Im *= (1 + factor * (distance / Math.Sqrt(centerX * centerX + centerY * centerY)));
                }
            }
        }
    }
}