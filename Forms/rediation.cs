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
    public partial class rediation : Form
    {
        public rediation()
        {
            InitializeComponent();
            for (int i = 0; i < Method.terrainNumber(); i++)
            {
                comboBox1.Items.Add(i + 1);
            }
            for (int i = 0; i < Method.yearNumber(); i++)
            {
                comboBox2.Items.Add(i + 1);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0] == ',')
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            terrain a = new terrain();
            this.Hide();
            a.Closed += (s, args) => this.Close();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Method.form3Check() == true)
            {
                temp a = new temp();
                this.Hide();
                a.Closed += (s, args) => this.Close();
                a.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double v = Convert.ToDouble(textBox1.Text);
                try
                {
                    Method.form3Add(Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox2.Text), Convert.ToDouble(textBox1.Text));
                }
                catch (Exception p)
                {
                    MessageBox.Show("You didn't choose a terrain or year.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("You didn't enter a value for a solar radiation or the value is too big." + "\n" + "The maximum value that can be entered is 2147483647.");
            }          
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
