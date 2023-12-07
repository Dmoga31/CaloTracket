using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace caloTracker
{ public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.textBoxPassword.AutoSize = false;
            this.textBoxPassword.Size = new Size(this.textBoxPassword.Width, 50);
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }


        public static String firstname;
        public static String username;
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.OpenConnection();
            username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password`= @pass;", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            //Check if the user exists
            if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mainform = new MainForm();
                mainform.Show();
                firstname = getFirstName(username);
            }
            else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER YOUR USERNAME TO LOGIN", "EMPTY USERNAME", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER YOUR PASSWORD TO LOGIN", "EMPTY PASSWORD", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD", "WRONG DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            db.CloseConnection();

        }

        // method to get the first name based on the username
        public static string getFirstName(string username)
        {
            string firstName = null;

            try
            {
                DB db = new DB();
                db.OpenConnection();

                string query = "SELECT firstname FROM users WHERE username = @usn";
                using (MySqlCommand command = new MySqlCommand(query, db.getConnection()))
                {
                    command.Parameters.AddWithValue("@usn", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            firstName = reader["firstname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return firstName;
        }

    private void labelGoToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerform = new RegisterForm();
            registerform.Show();
        }

        private void labelGoToSignUp_MouseEnter(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.Yellow;
        }

        private void labelGoToSignUp_MouseLeave(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.White;
        }
    }
}
