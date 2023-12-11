using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caloTracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            labelUsername.Text = LoginForm.username;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT `age`,`height`,`actualWeight`,`goalWeight`, `calorieIntake` FROM `users` WHERE username = @username", db.getConnection());
            command.Parameters.AddWithValue("username", LoginForm.username.Trim());
            MySqlDataReader myReader = command.ExecuteReader();
            if(myReader.Read())
            {
                labelAge.Text = myReader["age"].ToString();
                labelHeight.Text = myReader["height"].ToString();
                labelActW.Text = myReader["actualWeight"].ToString() + "kg";
                labelGoalW.Text = myReader["goalWeight"].ToString() + "kg";
                labelKcal.Text = myReader["calorieIntake"].ToString() + "kcal per day";

            }
            else
            {
                labelAge.Text = "";
                labelHeight.Text = "";
                labelActW.Text = "";
                labelGoalW.Text = "";
                labelKcal.Text = "";
            }
            db.CloseConnection();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            FoodForm food = new FoodForm();
            food.Show();
            
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;

        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }
    }
}
