using System.Drawing;
using System.Windows.Forms;

namespace SnilsCheckApp
{
    partial class SnilsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button getButton;
        private Button checkButton;
        private Label snilsLabel;
        private Label resultLabel;
        private Label formatResultLabel;
        private Label controlResultLabel;

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
            this.getButton = new Button();
            this.checkButton = new Button();
            this.snilsLabel = new Label();
            this.resultLabel = new Label();
            this.formatResultLabel = new Label();
            this.controlResultLabel = new Label();
            this.SuspendLayout();
            // 
            // getButton
            // 
            this.getButton.Location = new Point(24, 24);
            this.getButton.Name = "getButton";
            this.getButton.Size = new Size(220, 34);
            this.getButton.TabIndex = 0;
            this.getButton.Text = "Получить данные";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new Point(24, 74);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new Size(220, 34);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "Отправить результат теста";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // snilsLabel
            // 
            this.snilsLabel.AutoSize = true;
            this.snilsLabel.Location = new Point(265, 33);
            this.snilsLabel.Name = "snilsLabel";
            this.snilsLabel.Size = new Size(0, 13);
            this.snilsLabel.TabIndex = 2;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new Point(265, 83);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new Size(62, 13);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.Text = "Результат:";
            // 
            // formatResultLabel
            // 
            this.formatResultLabel.AutoSize = true;
            this.formatResultLabel.Location = new Point(24, 124);
            this.formatResultLabel.Name = "formatResultLabel";
            this.formatResultLabel.Size = new Size(44, 13);
            this.formatResultLabel.TabIndex = 4;
            this.formatResultLabel.Text = "Тест 1:";
            // 
            // controlResultLabel
            // 
            this.controlResultLabel.AutoSize = true;
            this.controlResultLabel.Location = new Point(24, 149);
            this.controlResultLabel.Name = "controlResultLabel";
            this.controlResultLabel.Size = new Size(44, 13);
            this.controlResultLabel.TabIndex = 5;
            this.controlResultLabel.Text = "Тест 2:";
            // 
            // SnilsForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(494, 186);
            this.Controls.Add(this.controlResultLabel);
            this.Controls.Add(this.formatResultLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.snilsLabel);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.getButton);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SnilsForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Валидация данных";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
