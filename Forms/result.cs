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
    public partial class result : Form
    {
        public result()
        {
            InitializeComponent();

            try
            {
                Method.form5Calculate();
                textBox1.Text = Method.getMaxEfficiency();
                textBox2.Text = Method.getSumCost();
                for (int i = 0; i < Method.getBoughtTerrainsLend(); i++)
                {
                    List<string> test = Method.getBoughtTerrains();
                    listBox1.Items.Add(test[i]);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("The values are too large." + "/n"+ "Try again.");
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void result_Load(object sender, EventArgs e)
        {

        }
    }
}
