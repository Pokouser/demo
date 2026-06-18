using System;
using System.Windows.Forms;
using PolesieUsersApp.classes;

namespace PolesieUsersApp.forms
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
            userInfoLabel.Text = "Вы вошли как: " + Helper.userLogin;
            roleLabel.Text = "Роль: " + Helper.userRole;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
