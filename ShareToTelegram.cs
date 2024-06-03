using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Segment_Color_Mappin
{
    public partial class ShareToTelegram : Form
    {
        private TelegramBotClient botClient;
        private long currentChatId = 825229286;
        private bool botInitialized = false;
        private string botToken = "7354111342:AAHQ0Dy2q4t-UTnXgfKVoKGCopsvKtbRLYg";

        public ShareToTelegram()
        {
            InitializeComponent();

            this.Paint += ShareToTelegram_Paint;
            Sharebtn.Click += Sharebtn_Click;
        }

        private async void ShareToTelegram_Paint(object sender, PaintEventArgs e)
        {
            await InitializeBotAsync();
        }

        private async Task InitializeBotAsync()
        {
            if (botInitialized)
                return;

            botClient = new TelegramBotClient(botToken);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Bot @{me.Username} initialized");
            botInitialized = true;
        }

        private async void Sharebtn_Click(object sender, EventArgs e)
        {
            Form sizeForm = new Form
            {
                Width = 800,
                Height = 600,
                Text = "Share files via Telegram"
            };

            Button sendToTelegram = new Button
            {
                Text = "Send",
                Left = 350,
                Width = 100,
                Top = 500
            };
            sizeForm.Controls.Add(sendToTelegram);

            Label label = new Label
            {
                Width = 600,
                Height = 40,
                Left = 100,
                Top = 200
            };
            sizeForm.Controls.Add(label);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Supported Audio Formats|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                label.Text = openFileDialog.FileName;
            }

            sendToTelegram.Click += async (s, ev) =>
            {
                if (!string.IsNullOrEmpty(label.Text))
                {
                    string filePath = label.Text;
                    await SendFileToTelegram(filePath);
                }
                else
                {
                    MessageBox.Show("Please select a file first.");
                }
            };

            sizeForm.ShowDialog();
        }

        private async Task SendFileToTelegram(string filePath)
        {
            try
            {
                if (!botInitialized)
                {
                    await InitializeBotAsync();
                }

                if (currentChatId != 0)
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        await botClient.SendDocumentAsync(
                            chatId: currentChatId,
                            document: InputFile.FromStream(fileStream, Path.GetFileName(filePath)),
                            caption: "Here is the file you requested"
                        );
                    }
                }
                else
                {
                    Console.WriteLine("No active chat to send the file to.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending file: {ex.Message}");
            }
        }
    }
}
