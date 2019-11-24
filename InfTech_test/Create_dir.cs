using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace InfTech_test
{
    public partial class Create_dir : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;";
        private OleDbConnection myConnection;


        public Create_dir()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();
                string query = "INSERT INTO Folder ( Folder_name, Parent_folder_code) VALUES ('"  + textBox2.Text + "', '" + textBox3.Text + "')";

                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
                MessageBox.Show("Folder created successfully");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }
    }
}
