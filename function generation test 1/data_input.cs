using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace function_generation_test_1
{
    public partial class data_input : Form
    {
        private bool formReady = false;

        public data_input(int vars, int consts, int threads)
        {
            InitializeComponent();
            for (int i = 0; i < DGV_main_data.Columns.Count; i++)
            {
                DGV_main_data.Columns[i].Width = 50;
            }

            char name = 'A';
            for (int i = 0; i < vars; i++)
            {


                DataGridViewColumn dgc = new DataGridViewColumn {SortMode = DataGridViewColumnSortMode.NotSortable};
                dgc.CellTemplate = new DataGridViewTextBoxCell();
                dgc.Name = name.ToString();
                dgc.HeaderText = name.ToString();
                //dgc.CellType = DGV_equal.Columns[0].CellType;
                DGV_main_data.Columns.Insert(DGV_main_data.Columns.Count, dgc);
                //            DGV_main_data.Columns.Add(columnName, columnName);
                DGV_main_data.Columns[DGV_main_data.Columns.Count - 1].Width = 50;
                DGV_main_data.Columns[DGV_main_data.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                name++;

            }

            foreach (DataGridViewRow row in DGV_main_data.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = 0;
                }
            }


            formReady = true;

            //DGV_main_data.SelectionMode=DataGridViewSelectionMode.FullColumnSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void добавитьСтолбецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string columnName = PromtText("Введите символьное обозначение переменной (1 символ, латиница)",
                                          "Название переменной");

            DataGridViewColumn dgc = new DataGridViewColumn {SortMode = DataGridViewColumnSortMode.NotSortable};
            dgc.CellTemplate = new DataGridViewTextBoxCell();
            dgc.Name = columnName;
            dgc.HeaderText = columnName;
            //dgc.CellType = DGV_equal.Columns[0].CellType;
            DGV_main_data.Columns.Insert(DGV_main_data.Columns.Count, dgc);
            //            DGV_main_data.Columns.Add(columnName, columnName);
            DGV_main_data.Columns[DGV_main_data.Columns.Count - 1].Width = 50;
            DGV_main_data.Columns[DGV_main_data.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }


        private string PromtText(string text, string caption)
        {
            var prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            var textLabel = new Label {Left = 50, Top = 20, Text = text};
            textLabel.Width = 700;
            var textBox = new TextBox {Left = 50, Top = 50, Width = 400};
            textBox.Text = " ";
            textBox.ResetCursor();
            var confirmation = new Button {Text = "Ok/enter", Left = 350, Width = 100, Top = 70};
            confirmation.Click += (sender, e) => { prompt.Close(); };
            textBox.TextChanged += (sender, e) =>
                {
                    if (textBox.Text.Length > 1)
                    {
                        textBox.Text = textBox.Text[0].ToString();
                    }
                };
            textBox.KeyPress += (sender, e) => { if (e.KeyChar == (char) Keys.Return) prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ActiveControl = (textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }



        private void DGV_main_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!formReady) return;
            Regex isDigit = new Regex("[0-9](,[0-9])?");
            try
            {
                //                MessageBox.Show(DGV_main_data.CurrentCell.Value.ToString());
                if (!isDigit.Match(DGV_main_data.CurrentCell.Value.ToString()).Success)
                    DGV_main_data.CurrentCell.Value = "";
            }
            catch (Exception)
            {

                //                throw;
            }



        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {

                DataObject d = ((DataGridView) sender).GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                //while (lines.Length < ((DataGridView)sender).Rows.Count)
                try
                {
                    ((DataGridView) sender).Rows.Add(lines.Length - ((DataGridView) sender).Rows.Count);
                }
                catch(Exception)
                {
                }
                int row = ((DataGridView) sender).CurrentCell.RowIndex;
                int col = ((DataGridView) sender).CurrentCell.ColumnIndex;
                foreach (string line in lines)
                {
                    if (row < ((DataGridView) sender).RowCount && line.Length >
                        0)
                    {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)
                        {
                            if (col + i <
                                ((DataGridView) sender).ColumnCount)
                            {
                                ((DataGridView) sender)[col + i, row].Value =
                                    Convert.ChangeType(cells[i], ((DataGridView) sender)[col + i, row].ValueType);
                            }
                            else
                            {
                                break;
                            }
                        }
                        row++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //            DGV_main_data.Rows[0].Cells[0].Value;





            List<List<argument>> collection = new List<List<argument>>();
            for (int i = 0; i < DGV_main_data.Rows.Count; i++)
            {
                char varname = 'A';
                List<argument> list = new List<argument>();
                for (int k = 0; k < DGV_main_data.Rows[i].Cells.Count; k++)
                {
                    var arg = new argument(varname++);
                    if (DGV_main_data.Rows[i].Cells[k].Value != null)
                    {
                        arg.applyValue(double.Parse(DGV_main_data.Rows[i].Cells[k].Value.ToString()));
                        list.Add(arg);
                    }
                }
                collection.Add(list);
            }

            List<double> equals = new List<double>();
            for (int i = 0; i < DGV_equal.Rows.Count; i++)
            {
                var value = DGV_equal.Rows[i].Cells[0].Value;
                if (value != null)
                    @equals.Add(double.Parse(value.ToString()));

            }


            Process nextStage = new Process(collection, equals);
            nextStage.Show();
            Hide();
        }


    }
}
