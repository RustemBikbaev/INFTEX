using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfTech_test
{
    public partial class Rename : Form
    {
        public Rename()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Rename_File f = new Rename_File();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                Rename_Folder f = new Rename_Folder();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }
    }
}
