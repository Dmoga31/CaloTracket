namespace caloTracker
{
    partial class FoodForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.food = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sugar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fiber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sodium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Potassium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cholesterol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carbs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.buttonCreateAccount = new System.Windows.Forms.Button();
            this.labelClose = new System.Windows.Forms.Label();
            this.textQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.food,
            this.Sugar,
            this.Serving,
            this.Fiber,
            this.Sodium,
            this.Potassium,
            this.FatS,
            this.FatT,
            this.Calories,
            this.Cholesterol,
            this.Protein,
            this.Carbs});
            this.dataGridView1.Location = new System.Drawing.Point(12, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(681, 118);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // food
            // 
            this.food.DataPropertyName = "name";
            this.food.HeaderText = "Food";
            this.food.MinimumWidth = 6;
            this.food.Name = "food";
            this.food.Width = 125;
            // 
            // Sugar
            // 
            this.Sugar.DataPropertyName = "SugarG";
            this.Sugar.HeaderText = "Sugar";
            this.Sugar.MinimumWidth = 6;
            this.Sugar.Name = "Sugar";
            this.Sugar.Width = 125;
            // 
            // Serving
            // 
            this.Serving.DataPropertyName = "ServingSizeG";
            this.Serving.HeaderText = "Serving Size G";
            this.Serving.MinimumWidth = 6;
            this.Serving.Name = "Serving";
            this.Serving.Width = 125;
            // 
            // Fiber
            // 
            this.Fiber.DataPropertyName = "FiberG";
            this.Fiber.HeaderText = "Fiber";
            this.Fiber.MinimumWidth = 6;
            this.Fiber.Name = "Fiber";
            this.Fiber.Width = 125;
            // 
            // Sodium
            // 
            this.Sodium.DataPropertyName = "SodiumMg";
            this.Sodium.HeaderText = "Sodium";
            this.Sodium.MinimumWidth = 6;
            this.Sodium.Name = "Sodium";
            this.Sodium.Width = 125;
            // 
            // Potassium
            // 
            this.Potassium.DataPropertyName = "PotassiumMg";
            this.Potassium.HeaderText = "Potassium";
            this.Potassium.MinimumWidth = 6;
            this.Potassium.Name = "Potassium";
            this.Potassium.Width = 125;
            // 
            // FatS
            // 
            this.FatS.DataPropertyName = "FatSaturatedG";
            this.FatS.HeaderText = "Fat saturated ";
            this.FatS.MinimumWidth = 6;
            this.FatS.Name = "FatS";
            this.FatS.Width = 125;
            // 
            // FatT
            // 
            this.FatT.DataPropertyName = "FatTotalG";
            this.FatT.HeaderText = "Fat total";
            this.FatT.MinimumWidth = 6;
            this.FatT.Name = "FatT";
            this.FatT.Width = 125;
            // 
            // Calories
            // 
            this.Calories.DataPropertyName = "calories";
            this.Calories.HeaderText = "Calories";
            this.Calories.MinimumWidth = 6;
            this.Calories.Name = "Calories";
            this.Calories.Width = 125;
            // 
            // Cholesterol
            // 
            this.Cholesterol.DataPropertyName = "CholesterolMg";
            this.Cholesterol.HeaderText = "Cholesterol";
            this.Cholesterol.MinimumWidth = 6;
            this.Cholesterol.Name = "Cholesterol";
            this.Cholesterol.Width = 125;
            // 
            // Protein
            // 
            this.Protein.DataPropertyName = "ProteinG";
            this.Protein.HeaderText = "Protein";
            this.Protein.MinimumWidth = 6;
            this.Protein.Name = "Protein";
            this.Protein.Width = 125;
            // 
            // Carbs
            // 
            this.Carbs.DataPropertyName = "CarbohydratesTotalG";
            this.Carbs.HeaderText = "Carbohydrate";
            this.Carbs.MinimumWidth = 6;
            this.Carbs.Name = "Carbs";
            this.Carbs.Width = 125;
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackColor = System.Drawing.Color.OrangeRed;
            this.btnConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(117, 338);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(513, 42);
            this.btnConsulta.TabIndex = 2;
            this.btnConsulta.Text = "Check your food information";
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // buttonCreateAccount
            // 
            this.buttonCreateAccount.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateAccount.FlatAppearance.BorderSize = 0;
            this.buttonCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateAccount.Location = new System.Drawing.Point(12, 12);
            this.buttonCreateAccount.Name = "buttonCreateAccount";
            this.buttonCreateAccount.Size = new System.Drawing.Size(114, 38);
            this.buttonCreateAccount.TabIndex = 7;
            this.buttonCreateAccount.Text = "GO BACK";
            this.buttonCreateAccount.UseVisualStyleBackColor = false;
            this.buttonCreateAccount.Click += new System.EventHandler(this.buttonGoBack);
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.SystemColors.Window;
            this.labelClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelClose.Location = new System.Drawing.Point(663, 12);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(30, 29);
            this.labelClose.TabIndex = 1;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            this.labelClose.MouseEnter += new System.EventHandler(this.labelClose_MouseEnter);
            this.labelClose.MouseLeave += new System.EventHandler(this.labelClose_MouseLeave);
            // 
            // textQuery
            // 
            this.textQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textQuery.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textQuery.Location = new System.Drawing.Point(56, 149);
            this.textQuery.Name = "textQuery";
            this.textQuery.Size = new System.Drawing.Size(619, 45);
            this.textQuery.TabIndex = 202;
            this.textQuery.Text = "2lb chicken";
            this.textQuery.Enter += new System.EventHandler(this.textBoxUsername_Enter);
            this.textQuery.Leave += new System.EventHandler(this.textBoxUsername_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(718, 75);
            this.label1.TabIndex = 203;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // FoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(702, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textQuery);
            this.Controls.Add(this.labelClose);
            this.Controls.Add(this.buttonCreateAccount);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FoodForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FoodForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn food;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sugar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serving;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fiber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sodium;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potassium;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calories;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cholesterol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carbs;
        private System.Windows.Forms.Button buttonCreateAccount;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.TextBox textQuery;
        private System.Windows.Forms.Label label1;
    }
}