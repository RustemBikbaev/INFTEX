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
    public partial class Download_file : Form
    {


        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;";
        private OleDbConnection myConnection;


        public void View_files()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            try
            {
                //создаем экземпляр класса OleDbConnection
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();
               
                string query = "SELECT  File.ID,  File.File_name, File_extension.Type,  File.Description,  File.Folder_code FROM File INNER JOIN File_extension ON File_extension.ID = File.Code_file_type";

                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                OleDbDataReader reader = command.ExecuteReader();

                listView1.Columns.Add("ID", 100);
                listView1.Columns.Add("File_name", 100);
                listView1.Columns.Add("Type", 100);
                listView1.Columns.Add("Description", 100);
                listView1.Columns.Add("Folder_code", 100);

                // в цикле построчно читаем ответ от БД
                while (reader.Read())
                {
                    string[] arr = new string[5];
                    arr[0] = reader[0].ToString();
                    arr[1] = reader[1].ToString();
                    arr[2] = reader[2].ToString();
                    arr[3] = reader[3].ToString();
                    arr[4] = reader[4].ToString();
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


        public Download_file()
        {
            InitializeComponent();
            View_files();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);
            // открываем соединение с БД
            myConnection.Open();

            string query = "SELECT File.File_name, File_extension.Type, File.Content FROM File INNER JOIN File_extension ON File.Code_file_type = File_extension.ID  WHERE File.ID = " + textBox1.Text + "";
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string filename = reader.GetString(0);
                string type = reader.GetString(1);
                byte[] data = (byte[])reader.GetValue(2);

                using (System.IO.FileStream fs = new System.IO.FileStream(filename + "." + type, System.IO.FileMode.OpenOrCreate))
                {
                    fs.Write(data, 0, data.Length);

                }
            }
            MessageBox.Show("File download successfully");
        }

        private void Download_file_Load(object sender, EventArgs e)
        {

        }
    }
}
