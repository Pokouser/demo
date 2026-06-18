using System.Drawing;
using System.Windows.Forms;

namespace PolesieUsersApp.forms
{
    partial class FormAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainPanel;
        private DataGridView usersGrid;
        private TableLayoutPanel editPanel;
        private Label loginLabel;
        private Label passwordLabel;
        private Label roleLabel;
        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private ComboBox roleComboBox;
        private CheckBox blockedCheckBox;
        private Button addButton;
        private Button saveButton;
        private Button unblockButton;

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
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.usersGrid = new System.Windows.Forms.DataGridView();
            this.editPanel = new System.Windows.Forms.TableLayoutPanel();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.blockedCheckBox = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.unblockButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).BeginInit();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.mainPanel.Controls.Add(this.usersGrid, 0, 0);
            this.mainPanel.Controls.Add(this.editPanel, 1, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(12);
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Size = new System.Drawing.Size(764, 421);
            this.mainPanel.TabIndex = 0;
            // 
            // usersGrid
            // 
            this.usersGrid.AllowUserToAddRows = false;
            this.usersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersGrid.Location = new System.Drawing.Point(15, 15);
            this.usersGrid.MultiSelect = false;
            this.usersGrid.Name = "usersGrid";
            this.usersGrid.ReadOnly = true;
            this.usersGrid.RowTemplate.Height = 25;
            this.usersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersGrid.Size = new System.Drawing.Size(452, 391);
            this.usersGrid.TabIndex = 0;
            this.usersGrid.SelectionChanged += new System.EventHandler(this.usersGrid_SelectionChanged);
            // 
            // editPanel
            // 
            this.editPanel.ColumnCount = 2;
            this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editPanel.Controls.Add(this.loginLabel, 0, 0);
            this.editPanel.Controls.Add(this.loginTextBox, 1, 0);
            this.editPanel.Controls.Add(this.passwordLabel, 0, 1);
            this.editPanel.Controls.Add(this.passwordTextBox, 1, 1);
            this.editPanel.Controls.Add(this.roleLabel, 0, 2);
            this.editPanel.Controls.Add(this.roleComboBox, 1, 2);
            this.editPanel.Controls.Add(this.blockedCheckBox, 1, 3);
            this.editPanel.Controls.Add(this.addButton, 0, 4);
            this.editPanel.Controls.Add(this.saveButton, 1, 4);
            this.editPanel.Controls.Add(this.unblockButton, 0, 5);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPanel.Location = new System.Drawing.Point(473, 15);
            this.editPanel.Name = "editPanel";
            this.editPanel.RowCount = 8;
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.editPanel.Size = new System.Drawing.Size(276, 391);
            this.editPanel.TabIndex = 1;
            // 
            // loginLabel
            // 
            this.loginLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(3, 11);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(41, 13);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Логин:";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginTextBox.Location = new System.Drawing.Point(93, 3);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(180, 20);
            this.loginTextBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(3, 47);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(48, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Пароль:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordTextBox.Location = new System.Drawing.Point(93, 39);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(180, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // roleLabel
            // 
            this.roleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.roleLabel.AutoSize = true;
            this.roleLabel.Location = new System.Drawing.Point(3, 83);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(35, 13);
            this.roleLabel.TabIndex = 4;
            this.roleLabel.Text = "Роль:";
            // 
            // roleComboBox
            // 
            this.roleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.Items.AddRange(new object[] {
            "Администратор",
            "Пользователь"});
            this.roleComboBox.Location = new System.Drawing.Point(93, 75);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(180, 21);
            this.roleComboBox.TabIndex = 5;
            // 
            // blockedCheckBox
            // 
            this.blockedCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.blockedCheckBox.AutoSize = true;
            this.blockedCheckBox.Location = new System.Drawing.Point(93, 117);
            this.blockedCheckBox.Name = "blockedCheckBox";
            this.blockedCheckBox.Size = new System.Drawing.Size(99, 17);
            this.blockedCheckBox.TabIndex = 6;
            this.blockedCheckBox.Text = "Заблокирован";
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(3, 147);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(84, 36);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Добавить";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButton.Location = new System.Drawing.Point(93, 147);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(180, 36);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Сохранить";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // unblockButton
            // 
            this.editPanel.SetColumnSpan(this.unblockButton, 2);
            this.unblockButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unblockButton.Location = new System.Drawing.Point(3, 189);
            this.unblockButton.Name = "unblockButton";
            this.unblockButton.Size = new System.Drawing.Size(270, 36);
            this.unblockButton.TabIndex = 9;
            this.unblockButton.Text = "Снять блокировку";
            this.unblockButton.Click += new System.EventHandler(this.unblockButton_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 421);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(780, 460);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Полесье - администратор";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).EndInit();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
