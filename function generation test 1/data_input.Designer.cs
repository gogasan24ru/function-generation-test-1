namespace function_generation_test_1
{
    partial class data_input
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
            this.DGV_main_data = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DGV_equal = new System.Windows.Forms.DataGridView();
            this.equal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_main_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_equal)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_main_data
            // 
            this.DGV_main_data.AllowUserToResizeRows = false;
            this.DGV_main_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_main_data.Location = new System.Drawing.Point(12, 12);
            this.DGV_main_data.Name = "DGV_main_data";
            this.DGV_main_data.RowHeadersWidth = 10;
            this.DGV_main_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.DGV_main_data.Size = new System.Drawing.Size(712, 209);
            this.DGV_main_data.TabIndex = 0;
            this.DGV_main_data.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_main_data_CellValueChanged);
            this.DGV_main_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(708, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Начать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DGV_equal
            // 
            this.DGV_equal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_equal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equal});
            this.DGV_equal.Location = new System.Drawing.Point(730, 12);
            this.DGV_equal.Name = "DGV_equal";
            this.DGV_equal.RowHeadersWidth = 10;
            this.DGV_equal.Size = new System.Drawing.Size(134, 209);
            this.DGV_equal.TabIndex = 4;
            this.DGV_equal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // equal
            // 
            this.equal.Frozen = true;
            this.equal.HeaderText = "=";
            this.equal.Name = "equal";
            // 
            // data_input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 262);
            this.Controls.Add(this.DGV_equal);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DGV_main_data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "data_input";
            this.Text = "Введите данные";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_main_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_equal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_main_data;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DGV_equal;
        private System.Windows.Forms.DataGridViewTextBoxColumn equal;
    }
}