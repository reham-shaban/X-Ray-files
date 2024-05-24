using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segment_Color_Mappin
{
    public partial class SearchForm : Form
    {
        private string selectedFolderPath;

        public SearchForm()
        {
            InitializeComponent();
            // Set the default folder path
            selectedFolderPath = @"C:\Users\Reham\Desktop\X-Ray";
            textBoxFolderPath.Text = selectedFolderPath; // Display the default path in a textbox

            // Set default data to "all times"
            dateTimePickerStartDate.Value = DateTimePicker.MinimumDateTime;
            dateTimePickerEndDate.Value = DateTimePicker.MaximumDateTime;
        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderDialog.SelectedPath;
                    textBoxFolderPath.Text = selectedFolderPath; // Display the selected path in a textbox
                }
            }
        }

        // Search button click event handler
        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                MessageBox.Show("Please choose a folder first.", "Folder Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the search query from the text box
            string searchQuery = textBoxSearch.Text.Trim();

            // Get the size criteria from the text boxes
            bool isMinSizeValid = long.TryParse(textBoxMinSize.Text, out long minSize);
            bool isMaxSizeValid = long.TryParse(textBoxMaxSize.Text, out long maxSize);

            // Get the date range from the date pickers
            DateTime? startDate = dateTimePickerStartDate.Value == DateTimePicker.MinimumDateTime ? (DateTime?)null : dateTimePickerStartDate.Value;
            DateTime? endDate = dateTimePickerEndDate.Value == DateTimePicker.MaximumDateTime ? (DateTime?)null : dateTimePickerEndDate.Value;

            // Set default values if size criteria are not specified
            if (!isMinSizeValid) minSize = 0;
            if (!isMaxSizeValid) maxSize = long.MaxValue;
            else maxSize *= 1024; // Convert to bytes

            // Validate the criteria
            if (string.IsNullOrWhiteSpace(searchQuery) && !isMinSizeValid && !isMaxSizeValid && !startDate.HasValue && !endDate.HasValue)
            {
                MessageBox.Show("Please enter a search query or size/date criteria.", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable search button to prevent multiple clicks
            buttonSearch.Enabled = false;

            try
            {
                // Perform the search asynchronously
                await SearchImagesAsync(searchQuery, minSize * 1024, maxSize, startDate, endDate);
            }
            finally
            {
                // Re-enable the search button after the search is complete
                buttonSearch.Enabled = true;
            }
        }

        private async Task SearchImagesAsync(string searchQuery, long minSize, long maxSize, DateTime? startDate, DateTime? endDate)
        {
            // Clear the previous search results
            listBoxResults.Items.Clear();

            // Specify the file extensions to search
            string[] fileExtensions = { "*.jpg", "*.png", "*.bmp", "*.gif" };

            List<string> imageFiles = new List<string>();

            // Get a list of image files in the specified directory
            foreach (string fileExtension in fileExtensions)
            {
                imageFiles.AddRange(await Task.Run(() => Directory.GetFiles(selectedFolderPath, fileExtension)));
            }

            // Search for images that match the search query, size, and date criteria
            var matchingFiles = imageFiles.Where(filePath =>
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                long fileSize = new FileInfo(filePath).Length;
                DateTime lastWriteTime = File.GetLastWriteTime(filePath);

                bool nameMatches = string.IsNullOrWhiteSpace(searchQuery) || fileNameWithoutExtension.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0;
                bool sizeMatches = fileSize >= minSize && fileSize <= maxSize;
                bool dateMatches = (!startDate.HasValue || lastWriteTime >= startDate) && (!endDate.HasValue || lastWriteTime <= endDate);

                return nameMatches && sizeMatches && dateMatches;
            }).ToList();

            // Add the matching images to the results list box
            listBoxResults.Items.AddRange(matchingFiles.ToArray());

            // Display a message if no matching images were found
            if (listBoxResults.Items.Count == 0)
            {
                MessageBox.Show("No images found matching the search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
