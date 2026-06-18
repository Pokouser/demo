using System.Drawing;
using System.Windows.Forms;

namespace PolesieUsersApp.forms
{
    partial class main
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainPanel;
        private Label titleLabel;
        private Label loginLabel;
        private Label passwordLabel;
        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;

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
            this.mainPanel = new TableLayoutPanel();
            this.titleLabel = new Label();
            this.loginLabel = new Label();
            this.loginTextBox = new TextBox();
            this.passwordLabel = new Label();
            this.passwordTextBox = new TextBox();
            this.loginButton = new Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            this.mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.titleLabel, 0, 0);
            this.mainPanel.Controls.Add(this.loginLabel, 0, 1);
            this.mainPanel.Controls.Add(this.loginTextBox, 1, 1);
            this.mainPanel.Controls.Add(this.passwordLabel, 0, 2);
            this.mainPanel.Controls.Add(this.passwordTextBox, 1, 2);
            this.mainPanel.Controls.Add(this.loginButton, 1, 3);
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Padding = new Padding(20);
            this.mainPanel.RowCount = 5;
            this.mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            this.mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            this.mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.titleLabel.AutoSize = true;
            this.mainPanel.SetColumnSpan(this.titleLabel, 2);
            this.titleLabel.Dock = DockStyle.Fill;
            this.titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.titleLabel.Text = "Вход в систему";
            this.loginLabel.Anchor = AnchorStyles.Left;
            this.loginLabel.AutoSize = true;
            this.loginLabel.Text = "Логин:";
            this.loginTextBox.Dock = DockStyle.Fill;
            this.passwordLabel.Anchor = AnchorStyles.Left;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Text = "Пароль:";
            this.passwordTextBox.Dock = DockStyle.Fill;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.loginButton.Dock = DockStyle.Fill;
            this.loginButton.Text = "Войти";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(414, 221);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new Size(430, 260);
            this.Name = "main";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Полесье - авторизация";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
