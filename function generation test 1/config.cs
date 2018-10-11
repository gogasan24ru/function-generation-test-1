using System;
using System.Windows.Forms;

namespace function_generation_test_1
{
    public partial class F_config_window : Form
    {
        public F_config_window()
        {
            InitializeComponent();
        }

        private void BTN_end_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTN_begin_Click(object sender, EventArgs e)
        {
            string result="";
            foreach (var item in CBL_operations.CheckedItems)
            {
                result += item.ToString() + ", ";
            }
            //MessageBox.Show("selected items: "+result);
            data_input next = new data_input((int)NUD_variables.Value,(int)NUD_consts.Value,(int)NUD_threads.Value);

            next.Show(); this.Hide();
        }

        private void NUD_variables_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
