using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace caloTracker
{
    public partial class RegisterForm : Form
    {

        public RegisterForm()
        {
            InitializeComponent();
        }


        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void textBoxFirstname_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("first name"))
            {
                textBoxFirstname.Text = "";
                textBoxFirstname.ForeColor = Color.Black;
            }
        }

        private void textBoxFirstname_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                textBoxFirstname.Text = "first name";
                textBoxFirstname.ForeColor = Color.Gray;
            }
        }

        private void textBoxLastname_Enter(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                textBoxLastname.Text = "";
                textBoxLastname.ForeColor = Color.Black;
            }
        }

        private void textBoxLastname_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                textBoxLastname.Text = "last name";
                textBoxLastname.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email address"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email address") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "email address";
                textBoxEmail.ForeColor = Color.Gray;
            }
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

        private void textBoxPasswordConfirm_Enter(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                textBoxPasswordConfirm.Text = "";
                textBoxPasswordConfirm.UseSystemPasswordChar = true;
                textBoxPasswordConfirm.ForeColor = Color.Black;
            }
        }

        private void textBoxPasswordConfirm_Leave(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") || cpassword.Trim().Equals(""))
            {
                textBoxPasswordConfirm.Text = "confirm password";
                textBoxPasswordConfirm.UseSystemPasswordChar = false;
                textBoxPasswordConfirm.ForeColor = Color.Gray;
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void labelClose_Enter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_Leave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;

        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        public static Double activity;
        public static Double bmr;
        public static Double totalCalories;
        public static Double height;
        public static Double actWeight;
        public static Double goalWeight;
        public static string firstname;
        public static int age;

        private async void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            firstname = textBoxFirstname.Text;
            age = Convert.ToInt32(textBoxAge.Text);
            height = Convert.ToDouble(textBoxHeight.Text);
            actWeight = Convert.ToDouble(textBoxActualW.Text);
            goalWeight = Convert.ToDouble(textBoxGoalW.Text);


            // add a new user 
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `email`, `username`, `password`, `actualWeight`, `goalWeight`, `activityLevel`, `gender`, `age`, `height`, `calorieIntake`) VALUES (@fn, @ln, @email, @usn, @pass, @actW, @goalW, @act, @gn, @age, @height, @calIn)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            string hashedPassword = await HashPasswordAsync(textBoxPassword.Text);
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = hashedPassword; 
            command.Parameters.Add("@actW", MySqlDbType.VarChar).Value = textBoxActualW.Text;
            command.Parameters.Add("@goalW", MySqlDbType.VarChar).Value = textBoxGoalW.Text;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = textBoxAge.Text;
            command.Parameters.Add("@height", MySqlDbType.VarChar).Value = textBoxHeight.Text;



            if (lowActClicked)
            {
                command.Parameters.Add("@act", MySqlDbType.VarChar).Value = "low";
                activity = 1.22;

            } else if (medActClicked)
            {
                command.Parameters.Add("@act", MySqlDbType.VarChar).Value = "medium";
                activity = 1.55;

            } else if (highActClicked)
            {
                command.Parameters.Add("@act", MySqlDbType.VarChar).Value = "high";
                activity = 1.9;

            }

            if (masculine)
            {
                command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = "masculine";

                //Si quiere aumentar peso
                if (goalWeight > actWeight)
                {
                    totalCalories = await BMRAsync(actWeight, height, activity, age, "masculine") + 500;
                    command.Parameters.Add("@calIn", MySqlDbType.VarChar).Value = totalCalories.ToString();
                }
                //Si quiere bajar de pes
                else if (goalWeight < actWeight)
                {
                    totalCalories = await BMRAsync(actWeight, height, activity, age, "masculine") - 500;
                    command.Parameters.Add("@calIn", MySqlDbType.VarChar).Value = totalCalories.ToString();
                }
                //Si quiere mantener peso
                else if (goalWeight == actWeight)
                {
                    totalCalories = await BMRAsync(actWeight, height, activity, age, "masculine");
                    command.Parameters.Add("@calIn", MySqlDbType.VarChar).Value = totalCalories.ToString();
                }
            }
            else if (femenine)
            {
                command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = "femenine";

                //Si quiere aumentar peso
                if (goalWeight > actWeight)
                {
                    totalCalories = await BMRAsync(actWeight, height, activity, age, "femenine") + 500;
                    command.Parameters.Add("@calIn", MySqlDbType.VarChar).Value = totalCalories.ToString();
                }
                //Si quiere bajar de pes
                else if (goalWeight < actWeight)
                {
                    totalCalories = await BMRAsync(actWeight, height, activity, age, "femenine") - 500;
                    command.Parameters.Add("@calIn", MySqlDbType.VarChar).Value = totalCalories.ToString();
                }
                //Si quiere mantener peso
                else if (goalWeight == actWeight)
                {
                    totalCalories = await BMRAsync(actWeight, height, activity, age, "femenine");
                    command.Parameters.Add("@calIn", MySqlDbType.VarChar).Value = totalCalories.ToString();
                }
            }

            // open the connection 
             db.OpenConnection();


            // Checks if textboxes contains default value
            if (!checkTextBoxesValues())
            {

                // Check if the password equal the confirm password
                if (textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text))
                {
                    // Checks if username already exists
                    if (checkUsername())
                    {
                        MessageBox.Show("This username already exists!!", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    }
                    else
                    {

                        // execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("YOUR ACCOUNT HAS BEEN CREATED", "ACCOUNT CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("PASSWORD DOESN'T MATCH", "PASSWORD ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ENTER YOUR INFORMATION!!", "EMPTY DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        // Función para encriptar la contraseña utilizando SHA-256
        static async Task<string> HashPasswordAsync(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = await Task.Run(() => sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));

                // Convertir los bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // Harris-Benedict formula for men/women - Basal Metabolic Rate
        static async Task<double> BMRAsync(double actW, double height, double activity, int age, string gender)
        {
            return await Task.Run(() =>
            {
                if (gender.Equals("masculine"))
                {
                    double bmrMen = (66 + (13.7 * actW)) + ((5 * height) - (6.8 * age)) * activity;
                    return bmrMen;
                }
                else if (gender.Equals("femenine"))
                {
                    double bmrWomen = (655 + (9.6 * actW)) + ((1.8 * height) - (4.7 * age)) * activity;
                    return bmrWomen;
                }
                else
                {
                    return -1;
                }
            });
        }


        //check if the user already exists
        public Boolean checkUsername()
        {
            DB db = new DB();

            String username = textBoxUsername.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //Check if the username exists
            if (table.Rows.Count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        //Check if textbox contains default values
        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String username = textBoxUsername.Text;
            String email = textBoxEmail.Text;
            String password = textBoxPassword.Text;
            String actualW = textBoxActualW.Text;
            String goalW = textBoxGoalW.Text;
            String age = textBoxAge.Text;

            if (fname.Equals("first name") || lname.Equals("last name") || username.Equals("username") || email.Equals("email") || password.Equals("password") || actualW.Equals("actual weight (kg)") || goalW.Equals("goal weight (kg)") || age.Equals("age") || (lowActClicked == false && medActClicked == false && highActClicked == false) || (masculine == false && femenine == false))
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void labelGoToLogin_MouseEnter(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.Yellow;
        }

        private void labelGoToLogin_MouseLeave(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.White;
        }

        private void labelGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        //Actvity boolean flag
        public Boolean lowActClicked = false;
        public Boolean medActClicked = false;
        public Boolean highActClicked = false;
        private void buttonLowAct_Click(object sender, EventArgs e)
        {
            lowActClicked = !lowActClicked;

            if (lowActClicked)
            {
                buttonHighAct.Enabled = false;
                buttonMediumAct.Enabled = false;
            } else
            {
                buttonHighAct.Enabled = true;
                buttonMediumAct.Enabled = true;
            }

        }

        private void buttonMediumAct_Click(object sender, EventArgs e)
        {
            medActClicked = !medActClicked;

            if (medActClicked)
            {
                buttonHighAct.Enabled = false;
                buttonLowAct.Enabled = false;
            }
            else
            {
                buttonHighAct.Enabled = true;
                buttonLowAct.Enabled = true;
            }
        }


        private void buttonHighAct_Click(object sender, EventArgs e)
        {
            highActClicked = !highActClicked;

            if (highActClicked)
            {
                buttonMediumAct.Enabled = false;
                buttonLowAct.Enabled = false;
            }
            else
            {
                buttonMediumAct.Enabled = true;
                buttonLowAct.Enabled = true;
            }
        }

        private void textBoxActualW_Enter(object sender, EventArgs e)
        {
            String actualW = textBoxActualW.Text;
            if (actualW.ToLower().Trim().Equals("actual weight (kg)"))
            {
                textBoxActualW.Text = "";
                textBoxActualW.ForeColor = Color.Black;
            }
        }

        private void textBoxActualW_Leave(object sender, EventArgs e)
        {
            String actualW = textBoxActualW.Text;
            if (actualW.ToLower().Trim().Equals("actual weight (kg)") || actualW.Trim().Equals(""))
            {
                textBoxActualW.Text = "actual weight (kg)";
                textBoxActualW.ForeColor = Color.Gray;
            }
        }

        private void textBoxGoalW_Enter(object sender, EventArgs e)
        {
            String goalW = textBoxGoalW.Text;
            if (goalW.ToLower().Trim().Equals("goal weight (kg)"))
            {
                textBoxGoalW.Text = "";
                textBoxGoalW.ForeColor = Color.Black;
            }
        }

        private void textBoxGoalW_Leave(object sender, EventArgs e)
        {
            String goalW = textBoxGoalW.Text;
            if (goalW.ToLower().Trim().Equals("goal weight (kg)") || goalW.Trim().Equals(""))
            {
                textBoxGoalW.Text = "goal weight (kg)";
                textBoxGoalW.ForeColor = Color.Gray;
            }
        }

        //Gender boolean flag
        public Boolean masculine = false;
        public Boolean femenine = false;

        private void buttonFem_Click(object sender, EventArgs e)
        {
            femenine = !femenine;
            if(femenine)
            {
                buttonMasc.Enabled = false;
            } else
            {
                buttonMasc.Enabled = true;
            }
        }

        private void buttonMasc_Click(object sender, EventArgs e)
        {
            masculine = !masculine;
            if(masculine)
            {
                buttonFem.Enabled = false;
            } else
            {
                buttonFem.Enabled = true;
            }
        }

        private void textBoxAge_Enter(object sender, EventArgs e)
        {
            String age = textBoxAge.Text;
            if (age.ToLower().Trim().Equals("age"))
            {
                textBoxAge.Text = "";
                textBoxAge.ForeColor = Color.Black;
            }
        }

        private void textBoxAge_Leave(object sender, EventArgs e)
        {
            String age = textBoxAge.Text;
            if (age.ToLower().Trim().Equals("age") || age.Trim().Equals(""))
            {
                textBoxAge.Text = "age";
                textBoxAge.ForeColor = Color.Gray;
            } else if (!age.ToLower().Trim().Equals("age") || !age.Trim().Equals("")) {
                if (Convert.ToInt32(textBoxAge.Text) < 10)
                {
                    MessageBox.Show("You need to be older than 10 years to create an account");
                    textBoxAge.Text = "age";
                    textBoxAge.ForeColor = Color.Gray;
                }
            }
        }

        private void textBoxHeight_Enter(object sender, EventArgs e)
        {
            String height = textBoxHeight.Text;
            if (height.ToLower().Trim().Equals("height (cm)"))
            {
                textBoxHeight.Text = "";
                textBoxHeight.ForeColor = Color.Black;
            }
        }

        private void textBoxHeight_Leave(object sender, EventArgs e)
        {
            String height = textBoxHeight.Text;
            if (height.ToLower().Trim().Equals("height (cm)") || height.Trim().Equals(""))
            {
                textBoxHeight.Text = "height (cm)";
                textBoxHeight.ForeColor = Color.Gray;
            }
        }

        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxActualW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxGoalW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
