using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PolesieUsersApp.classes;

namespace PolesieUsersApp.forms
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            SqlConnection conn = Helper.GetConnection();
            conn.Open();

            string sql = @"SELECT UserId, [Login], [Password], [Role], IsBlocked, FailedAttempts
                           FROM [Users]
                           ORDER BY UserId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            usersGrid.DataSource = table;

            reader.Close();
            conn.Close();
        }

        private void usersGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = usersGrid.SelectedRows[0];
            loginTextBox.Text = row.Cells["Login"].Value.ToString();
            passwordTextBox.Text = row.Cells["Password"].Value.ToString();
            roleComboBox.SelectedItem = row.Cells["Role"].Value.ToString();
            blockedCheckBox.Checked = Convert.ToBoolean(row.Cells["IsBlocked"].Value);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string role = roleComboBox.SelectedItem == null ? "" : roleComboBox.SelectedItem.ToString();

            if (!CheckFields(login, password, role))
            {
                return;
            }

            SqlConnection conn = Helper.GetConnection();
            conn.Open();

            string sql = @"INSERT INTO [Users] ([Login], [Password], [Role], IsBlocked, FailedAttempts)
                           VALUES (@login, @password, @role, @isBlocked, 0)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@isBlocked", blockedCheckBox.Checked);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Пользователь добавлен.");
                LoadUsers();
            }
            catch
            {
                MessageBox.Show("Пользователь с указанным логином уже существует.");
            }

            conn.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для изменения.");
                return;
            }

            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string role = roleComboBox.SelectedItem == null ? "" : roleComboBox.SelectedItem.ToString();

            if (!CheckFields(login, password, role))
            {
                return;
            }

            int userId = Convert.ToInt32(usersGrid.SelectedRows[0].Cells["UserId"].Value);

            SqlConnection conn = Helper.GetConnection();
            conn.Open();

            string sql = @"UPDATE [Users]
                           SET [Login] = @login,
                               [Password] = @password,
                               [Role] = @role,
                               IsBlocked = @isBlocked
                           WHERE UserId = @userId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@isBlocked", blockedCheckBox.Checked);
            cmd.Parameters.AddWithValue("@userId", userId);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные пользователя изменены.");
                LoadUsers();
            }
            catch
            {
                MessageBox.Show("Пользователь с указанным логином уже существует.");
            }

            conn.Close();
        }

        private void unblockButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для снятия блокировки.");
                return;
            }

            int userId = Convert.ToInt32(usersGrid.SelectedRows[0].Cells["UserId"].Value);

            SqlConnection conn = Helper.GetConnection();
            conn.Open();

            string sql = @"UPDATE [Users]
                           SET IsBlocked = 0,
                               FailedAttempts = 0
                           WHERE UserId = @userId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.ExecuteNonQuery();
            conn.Close();

            LoadUsers();
            MessageBox.Show("Блокировка снята.");
        }

        private bool CheckFields(string login, string password, string role)
        {
            if (login == "" || password == "")
            {
                MessageBox.Show("Поля Логин и Пароль обязательны для заполнения.");
                return false;
            }

            if (role == "")
            {
                MessageBox.Show("Выберите роль пользователя.");
                return false;
            }

            return true;
        }
    }
}
