using System.Drawing;
using System.Windows.Forms;

namespace PolesieUsersApp.forms
{
    partial class FormUser
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel mainPanel;
        private Label userInfoLabel;
        private Label roleLabel;
        private Button exitButton;

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
            this.mainPanel = new FlowLayoutPanel();
            this.userInfoLabel = new Label();
            this.roleLabel = new Label();
            this.exitButton = new Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            this.mainPanel.Controls.Add(this.userInfoLabel);
            this.mainPanel.Controls.Add(this.roleLabel);
            this.mainPanel.Controls.Add(this.exitButton);
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.FlowDirection = FlowDirection.TopDown;
            this.mainPanel.Padding = new Padding(20);
            this.mainPanel.WrapContents = false;
            this.userInfoLabel.AutoSize = true;
            this.userInfoLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.userInfoLabel.Text = "Вы вошли как:";
            this.roleLabel.AutoSize = true;
            this.roleLabel.Text = "Роль:";
            this.exitButton.Size = new Size(220, 35);
            this.exitButton.Text = "Выйти";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(404, 181);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new Size(420, 220);
            this.Name = "FormUser";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Полесье - пользователь";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
