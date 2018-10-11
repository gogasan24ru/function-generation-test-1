namespace function_generation_test_1
{
    partial class F_config_window
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CBL_operations = new System.Windows.Forms.CheckedListBox();
            this.NUD_variables = new System.Windows.Forms.NumericUpDown();
            this.NUD_consts = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_begin = new System.Windows.Forms.Button();
            this.BTN_end = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NUD_threads = new System.Windows.Forms.NumericUpDown();
            this.CB_demonstration = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_variables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_consts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_threads)).BeginInit();
            this.SuspendLayout();
            // 
            // CBL_operations
            // 
            this.CBL_operations.Enabled = false;
            this.CBL_operations.FormattingEnabled = true;
            this.CBL_operations.Items.AddRange(new object[] {
            "Умножение",
            "Деление",
            "Сложение",
            "Вычитание"});
            this.CBL_operations.Location = new System.Drawing.Point(15, 108);
            this.CBL_operations.Name = "CBL_operations";
            this.CBL_operations.Size = new System.Drawing.Size(255, 64);
            this.CBL_operations.TabIndex = 2;
            // 
            // NUD_variables
            // 
            this.NUD_variables.Location = new System.Drawing.Point(150, 7);
            this.NUD_variables.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.NUD_variables.Name = "NUD_variables";
            this.NUD_variables.Size = new System.Drawing.Size(120, 20);
            this.NUD_variables.TabIndex = 3;
            this.NUD_variables.ValueChanged += new System.EventHandler(this.NUD_variables_ValueChanged);
            // 
            // NUD_consts
            // 
            this.NUD_consts.Enabled = false;
            this.NUD_consts.Location = new System.Drawing.Point(150, 33);
            this.NUD_consts.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.NUD_consts.Name = "NUD_consts";
            this.NUD_consts.Size = new System.Drawing.Size(120, 20);
            this.NUD_consts.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество констант";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество переменных";
            // 
            // BTN_begin
            // 
            this.BTN_begin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_begin.Location = new System.Drawing.Point(15, 178);
            this.BTN_begin.Name = "BTN_begin";
            this.BTN_begin.Size = new System.Drawing.Size(255, 23);
            this.BTN_begin.TabIndex = 7;
            this.BTN_begin.Text = "Начать";
            this.BTN_begin.UseVisualStyleBackColor = true;
            this.BTN_begin.Click += new System.EventHandler(this.BTN_begin_Click);
            // 
            // BTN_end
            // 
            this.BTN_end.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_end.Location = new System.Drawing.Point(15, 207);
            this.BTN_end.Name = "BTN_end";
            this.BTN_end.Size = new System.Drawing.Size(255, 23);
            this.BTN_end.TabIndex = 8;
            this.BTN_end.Text = "Выход";
            this.BTN_end.UseVisualStyleBackColor = true;
            this.BTN_end.Click += new System.EventHandler(this.BTN_end_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Потоки";
            // 
            // NUD_threads
            // 
            this.NUD_threads.Enabled = false;
            this.NUD_threads.Location = new System.Drawing.Point(150, 59);
            this.NUD_threads.Name = "NUD_threads";
            this.NUD_threads.Size = new System.Drawing.Size(120, 20);
            this.NUD_threads.TabIndex = 10;
            // 
            // CB_demonstration
            // 
            this.CB_demonstration.AutoSize = true;
            this.CB_demonstration.Enabled = false;
            this.CB_demonstration.Location = new System.Drawing.Point(15, 85);
            this.CB_demonstration.Name = "CB_demonstration";
            this.CB_demonstration.Size = new System.Drawing.Size(162, 17);
            this.CB_demonstration.TabIndex = 11;
            this.CB_demonstration.Text = "демонстрационный режим";
            this.CB_demonstration.UseVisualStyleBackColor = true;
            // 
            // F_config_window
            // 
            this.AcceptButton = this.BTN_begin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_end;
            this.ClientSize = new System.Drawing.Size(284, 237);
            this.Controls.Add(this.CB_demonstration);
            this.Controls.Add(this.NUD_threads);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTN_end);
            this.Controls.Add(this.BTN_begin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NUD_consts);
            this.Controls.Add(this.NUD_variables);
            this.Controls.Add(this.CBL_operations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_config_window";
            this.Text = "Lalka dnt know what it\'s name";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_variables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_consts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_threads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CBL_operations;
        private System.Windows.Forms.NumericUpDown NUD_variables;
        private System.Windows.Forms.NumericUpDown NUD_consts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_begin;
        private System.Windows.Forms.Button BTN_end;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUD_threads;
        private System.Windows.Forms.CheckBox CB_demonstration;

    }
}

