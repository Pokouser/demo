using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

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
            XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

            using (ZipArchive zip = ZipFile.Open(file, ZipArchiveMode.Update))
            {
                ZipArchiveEntry entry = zip.GetEntry("word/document.xml");
                XDocument doc;

                using (Stream stream = entry.Open())
                {
                    doc = XDocument.Load(stream);
                }

                XElement table = doc.Descendants(w + "tbl").First();
                XElement row1 = table.Elements(w + "tr").ElementAt(1);
                XElement row2 = table.Elements(w + "tr").ElementAt(2);

                SetText(row1.Elements(w + "tc").ElementAt(2), result1, "ResultData", 1, w);
                SetText(row2.Elements(w + "tc").ElementAt(2), result2, "ResultFormat", 2, w);

                entry.Delete();
                entry = zip.CreateEntry("word/document.xml");

                using (Stream stream = entry.Open())
                {
                    doc.Save(stream);
                }
            }
        }

        private void SetText(XElement cell, string text, string bookmark, int id, XNamespace w)
        {
            cell.Elements(w + "p").Remove();

            cell.Add(
                new XElement(w + "p",
                    new XElement(w + "bookmarkStart",
                        new XAttribute(w + "id", id),
                        new XAttribute(w + "name", bookmark)),
                    new XElement(w + "r",
                        new XElement(w + "t", text)),
                    new XElement(w + "bookmarkEnd",
                        new XAttribute(w + "id", id))));
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
