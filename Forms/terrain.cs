using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_for_optimal_selection_of_terrains.Forms
{
    public partial class terrain : Form
    {
        public terrain()
        {
            InitializeComponent();
            for (int i = 0; i < Method.terrainNumber(); i++)
            {
                comboBox1.Items.Add(i+1);
            }            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Method.terrainNumber() != 0 && Method.yearNumber() != 0)
            {
               if (Method.form2Check() == true)
               {
                   rediation a = new rediation();
                   this.Hide();
                   a.Closed += (s, args) => this.Close();
                   a.Show();
               }
            }
            else
            {
                MessageBox.Show("The number of terrains or years that you entered is 0.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start a = new Start();
            this.Hide();
            a.Closed += (s, args) => this.Close();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               int v = Convert.ToInt32(textBox1.Text);
                try
                {
                    Method.form2Add(Convert.ToInt32(comboBox1.Text), Convert.ToInt32(textBox1.Text));
                }
                catch (Exception p)
                {
                    MessageBox.Show("You didn't choose a terrain.");
                }   
            }
            catch (Exception f)
            {
                MessageBox.Show("The entered number of money is over the limit or is empty." + "\n" + "The maximum value that can be entered is 2147483647.");
            }

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
