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
    public partial class Delete_file : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;";
        private OleDbConnection myConnection;

        private void Show_File()
        {

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();

                string query = "SELECT ID, File_name, Description, Folder_code FROM File ";

                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                OleDbDataReader reader = command.ExecuteReader();

                listView1.Columns.Add("ID", 100);
                listView1.Columns.Add("File_name", 100);
                listView1.Columns.Add("Description", 100);
                listView1.Columns.Add("Folder_code", 100);

                // в цикле построчно читаем ответ от БД
                while (reader.Read())
                {
                    string[] arr = new string[4];
                    arr[0] = reader[0].ToString();
                    arr[1] = reader[1].ToString();
                    arr[2] = reader[2].ToString();
                    arr[3] = reader[3].ToString();
                    ListViewItem item = new ListViewItem(arr);
                    listView1.Items.Add(item);

                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }

        }

        public Delete_file()
        {
            InitializeComponent();
            Show_File();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();
                string query = "DELETE FROM File WHERE ID =" + textBox1.Text + "";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // выполняем запрос к MS Access
                command.ExecuteNonQuery();

                Task t = new Task(new Action(() =>
                {
                    listView1.Clear();
                    Show_File();
                    this.Refresh();
                }));
                t.Start();

                MessageBox.Show("Folder deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
