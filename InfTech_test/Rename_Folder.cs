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
    public partial class Rename_Folder : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;";
        private OleDbConnection myConnection;

        private void Show_Folder()
        {

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();

                string query = "SELECT ID, Folder_name, Parent_folder_code FROM Folder ";

                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                OleDbDataReader reader = command.ExecuteReader();

                listView1.Columns.Add("ID", 100);
                listView1.Columns.Add("Folder_name", 100);
                listView1.Columns.Add("Parent_folder_code", 100);

                // в цикле построчно читаем ответ от БД
                while (reader.Read())
                {
                    string[] arr = new string[3];
                    arr[0] = reader[0].ToString();
                    arr[1] = reader[1].ToString();
                    arr[2] = reader[2].ToString();
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

        public Rename_Folder()
        {
            InitializeComponent();
            Show_Folder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();
                string query = "UPDATE Folder SET Folder_name = '" + textBox2.Text + "' WHERE ID =" + textBox1.Text + "";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // выполняем запрос к MS Access
                command.ExecuteNonQuery();

                Task t = new Task(new Action(() =>
                {
                    listView1.Clear();
                    Show_Folder();
                    this.Refresh();
                }));
                t.Start();

                MessageBox.Show("Folder name updete successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }
    }
}
