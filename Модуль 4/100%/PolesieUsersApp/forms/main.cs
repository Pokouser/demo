using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using PolesieUsersApp.classes;

namespace PolesieUsersApp.forms
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            if (login == "" || password == "")
            {
                MessageBox.Show("Поля Логин и Пароль обязательны для заполнения.");
                return;
            }

            SqlConnection conn = Helper.GetConnection();
            conn.Open();

            string sql = @"SELECT UserId, [Password], [Role], IsBlocked, FailedAttempts
                           FROM [Users]
                           WHERE [Login] = @login";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", login);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                conn.Close();
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные.");
                return;
            }

            int userId = Convert.ToInt32(reader["UserId"]);
            string bdPassword = reader["Password"].ToString();
            string role = reader["Role"].ToString();
            bool isBlocked = Convert.ToBoolean(reader["IsBlocked"]);
            int failedAttempts = Convert.ToInt32(reader["FailedAttempts"]);

            if (isBlocked)
            {
                reader.Close();
                conn.Close();
                MessageBox.Show("Вы заблокированы. Обратитесь к администратору.");
                return;
            }

            if (bdPassword != password)
            {
                failedAttempts++;
                bool blockedUser = failedAttempts >= 3;
                reader.Close();

                string updateSql = @"UPDATE [Users]
                                     SET FailedAttempts = @failedAttempts,
                                         IsBlocked = @isBlocked
                                     WHERE UserId = @userId";
                SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@failedAttempts", failedAttempts);
                updateCmd.Parameters.AddWithValue("@isBlocked", blockedUser);
                updateCmd.Parameters.AddWithValue("@userId", userId);
                updateCmd.ExecuteNonQuery();

                conn.Close();

                if (blockedUser)
                {
                    MessageBox.Show("Вы заблокированы. Обратитесь к администратору.");
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные.");
                }

                return;
            }

            reader.Close();

            string resetSql = @"UPDATE [Users]
                                SET FailedAttempts = 0
                                WHERE UserId = @userId";
            SqlCommand resetCmd = new SqlCommand(resetSql, conn);
            resetCmd.Parameters.AddWithValue("@userId", userId);
            resetCmd.ExecuteNonQuery();
            conn.Close();

            Helper.userId = userId;
            Helper.userLogin = login;
            Helper.userRole = role;

            MessageBox.Show("Вы успешно авторизовались.");

            Hide();

            if (role == "Администратор")
            {
                FormAdmin adminForm = new FormAdmin();
                adminForm.ShowDialog(this);
            }
            else
            {
                FormUser userForm = new FormUser();
                userForm.ShowDialog(this);
            }

            Show();
            passwordTextBox.Clear();
        }
    }
}
