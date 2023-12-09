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
using System.Security.Cryptography;

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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn;", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            // Check if the user exists
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string storedPassword = row["password"].ToString();

                // Verify the entered password against the stored hashed password
                if (VerifyPassword(password, storedPassword))
                {
                    this.Hide();
                    MainForm mainform = new MainForm();
                    mainform.Show();
                    firstname = getFirstName(username);
                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD", "WRONG DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("ENTER YOUR USERNAME TO LOGIN", "EMPTY USERNAME", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD", "WRONG DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }

            db.CloseConnection();
        }

        // Función para encriptar la contraseña utilizando SHA-256
        static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calcula el hash de la contraseña ingresada
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));

                // Convierte los bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                // Compara el hash calculado con el hash almacenado
                return builder.ToString() == hashedPassword;
            }
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

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String user = textBoxUsername.Text;
            if (user.ToLower().Trim().Equals("username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String user = textBoxUsername.Text;
            if (user.ToLower().Trim().Equals("username") || user.Trim().Equals(""))
            {
                textBoxUsername.Text = "username";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }
    }
}
