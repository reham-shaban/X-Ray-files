using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace Segment_Color_Mappin
{
    public partial class ReportForm : Form
    {
        // Auto-incremented report number
        private static int ReportNumber = 1;

        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save Patient Report";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                GeneratePdf(filePath);
            }
        }

        private void GeneratePdf(string filePath)
        {
            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);

            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                document.Open();

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;

                // Add rows to the table
                AddRow(table, "Report Number:", ReportNumber++.ToString());
                AddRow(table, "Date:", DateTime.Now.ToString("MM/dd/yyyy"));
                AddRow(table, "Name:", txtName.Text);
                AddRow(table, "Age:", txtAge.Text);
                AddRow(table, "Gender:", txtGender.Text);
                AddRow(table, "Address:", txtAddress.Text);
                AddRow(table, "Contact Number:", txtContactNumber.Text);
                AddRow(table, "Medical History:", txtMedicalHistory.Text);

                document.Add(table);

                MessageBox.Show("Patient report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show success message
                document.Close();

                // Compression option
                DialogResult result = MessageBox.Show("Do you want to compress the saved pdf?", "Compress PDF",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CompressPdf(filePath, System.IO.Path.GetDirectoryName(filePath), System.IO.Path.GetFileNameWithoutExtension(filePath) + "_compressed.pdf");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (document.IsOpen())
                    document.Close();
            }
        }

        private void CompressPdf(string inputFilePath, string outputDirectory, string outputFileName)
            {
                try
                {
                    // Open the existing PDF document
                    PdfReader reader = new PdfReader(inputFilePath);
                    reader.RemoveUnusedObjects(); // Remove unused objects

                    // Create an output stream for the compressed PDF
                    using (FileStream outputStream = new FileStream(System.IO.Path.Combine(outputDirectory, outputFileName), FileMode.Create))
                    {
                        // Create a new document and PdfSmartCopy instance
                        Document document = new Document(reader.GetPageSizeWithRotation(1));
                        PdfSmartCopy smartCopy = new PdfSmartCopy(document, outputStream);

                        document.Open();

                        // Copy each page from the original PDF to the new document
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            PdfImportedPage page = smartCopy.GetImportedPage(reader, i);
                            smartCopy.AddPage(page);
                        }

                        // Close the document and PdfSmartCopy
                        document.Close();
                    }

                    reader.Close();

                    // Notify user that the compression was successful
                    MessageBox.Show("PDF compressed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Notify user if an error occurs
                    MessageBox.Show($"Error compressing PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
  
        private void AddRow(PdfPTable table, string key, string value)
                    {
                        PdfPCell cellKey = new PdfPCell(new Phrase(key));
                        cellKey.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cellKey);

                        PdfPCell cellValue = new PdfPCell(new Phrase(value));
                        cellValue.Border = PdfPCell.NO_BORDER;
                        table.AddCell(cellValue);
                    }
    
    
    }
}
