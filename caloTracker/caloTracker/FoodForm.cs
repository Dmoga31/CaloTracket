using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace caloTracker
{
    public partial class FoodForm : Form
    {
        public FoodForm()
        {
            InitializeComponent();
        }
        private void FoodForm_Load(object sender, EventArgs e)
        {
            // Configuración inicial del DataGridView
            dataGridView1.AutoGenerateColumns = true;
        }


        // Definición de las clases para deserializar los datos
        public class TuClaseDeDatos
        {
            public List<TuItem> items { get; set; }
        }

        public class TuItem
        {
            [JsonProperty("sugar_g")]


            public string SugarG { get; set; }

            [JsonProperty("fiber_g")]
            public string FiberG { get; set; }

            [JsonProperty("serving_size_g")]
            public string ServingSizeG { get; set; }

            [JsonProperty("sodium_mg")]
            public string SodiumMg { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("potassium_mg")]
            public string PotassiumMg { get; set; }

            [JsonProperty("fat_saturated_g")]
            public string FatSaturatedG { get; set; }

            [JsonProperty("fat_total_g")]
            public string FatTotalG { get; set; }

            [JsonProperty("calories")]
            public string Calories { get; set; }

            [JsonProperty("cholesterol_mg")]
            public string CholesterolMg { get; set; }

            [JsonProperty("protein_g")]
            public string ProteinG { get; set; }

            [JsonProperty("carbohydrates_total_g")]
            public string CarbohydratesTotalG { get; set; }
        }

        private async void btnConsulta_Click(object sender, EventArgs e)
        {
            string api_url = "https://api.calorieninjas.com/v1/nutrition?query=";
            string userQuery = textQuery.Text;
            string YOUR_API_KEY = "z7sgLG2vWGQRKJwVXn4Vtg==cyxxU43LwN4zHIbQ";

            var client = new RestClient(api_url);
            var request = new RestRequest();
            request.Method = Method.Get;

            request.AddHeader("X-Api-Key", YOUR_API_KEY);
            request.AddParameter("query", userQuery);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                
                var data = JsonConvert.DeserializeObject<TuClaseDeDatos>(response.Content);
                dataGridView1.DataSource = data.items; 
            }
            else
            {
                MessageBox.Show("Error en la solicitud: " + response.ErrorMessage);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonGoBack(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String user = textQuery.Text;
            if (user.ToLower().Trim().Equals("2lb chicken"))
            {
                textQuery.Text = "";
                textQuery.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String user = textQuery.Text;
            if (user.ToLower().Trim().Equals("2lb chicken") || user.Trim().Equals(""))
            {
                textQuery.Text = "2lb chicken";
                textQuery.ForeColor = Color.Gray;
            }
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.OrangeRed;
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
    }
}
