using System;
using System.Windows.Forms;
using Task_for_optimal_selection_of_terrains.Forms;

namespace Task_for_optimal_selection_of_terrains
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int kap;
            try
            {
                kap = Convert.ToInt32(textBox3.Text);
                try
                {
                    Method.form1CreateArray(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                    terrain a = new terrain();
                    this.Hide();
                    a.Closed += (s, args) => this.Close();
                    a.Show();
                }
                catch (Exception f)
                {
                    MessageBox.Show("The entered number of terrains is over the limit or is empty." + "\n" + " Enter a number between 1 and 1000." + "\n" + "The entered number of years is over the limit or is empty." + "\n" + " Enter a number between 1 and 1000.");
                }
            }
            catch (Exception v)
            {
                MessageBox.Show("The entered number of money is over the limit or is empty." + "\n" + "The maximum value that can be entered is 2147483647.");
            }
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
