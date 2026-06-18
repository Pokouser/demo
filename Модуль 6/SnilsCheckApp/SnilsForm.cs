using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace SnilsCheckApp
{
    public partial class SnilsForm : Form
    {
        string snils = "";

        public SnilsForm()
        {
            InitializeComponent();
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string json = client.DownloadString("http://localhost:4444/TransferSimulator/snils");

                Match match = Regex.Match(json, "\"value\"\\s*:\\s*\"([^\"]+)\"");
                snils = match.Groups[1].Value;

                snilsLabel.Text = snils;
                resultLabel.Text = "Результат:";
                formatResultLabel.Text = "Тест 1:";
                controlResultLabel.Text = "Тест 2:";
            }
            catch
            {
                MessageBox.Show("Не удалось получить данные");
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (snils == "")
            {
                MessageBox.Show("Сначала получите данные");
                return;
            }

            bool test1 = snils != "";
            bool test2 = CheckFormat(snils);

            string result1 = test1 ? "Успешно" : "Не успешно";
            string result2 = test2 ? "Успешно" : "Не успешно";

            formatResultLabel.Text = "Тест 1. Проверка наличия данных: " + result1;
            controlResultLabel.Text = "Тест 2. Проверка формата: " + result2;

            if (test1 && test2)
            {
                resultLabel.Text = "Корректный СНИЛС";
            }
            else
            {
                resultLabel.Text = "Не корректный СНИЛС";
            }

            try
            {
                SaveResult(result1, result2);
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить результат в Word");
            }
        }

        private bool CheckFormat(string value)
        {
            string numbers = Regex.Replace(value, @"\D", "");
            return Regex.IsMatch(value, @"^\d{3}-\d{3}-\d{3} \d{2}$") && numbers.Length == 11;
        }

        private void SaveResult(string result1, string result2)
        {
            string file = FindTestFile();

            Word.Application app = new Word.Application();
            Word.Document doc = null;

            try
            {
                doc = app.Documents.Open(file);
                Word.Table table = doc.Tables[1];

                table.Cell(2, 3).Range.Text = result1;
                table.Cell(3, 3).Range.Text = result2;

                doc.Save();
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                    Marshal.ReleaseComObject(doc);
                }

                app.Quit();
                Marshal.ReleaseComObject(app);
            }
        }

        private string FindTestFile()
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (dir != null)
            {
                string[] files = Directory.GetFiles(dir.FullName, "ТестКейс.docx", SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    return files[0];
                }

                dir = dir.Parent;
            }

            return "";
        }
    }
}
