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
    public partial class Expansion2 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;";
        private OleDbConnection myConnection;
        // массив для хранения бинарных данных файла
        byte[] file_Data;

        private void Show_Expansion()
        {

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();

                string query = "SELECT ID, Type, Icons FROM File_extension ";

                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                OleDbDataReader reader = command.ExecuteReader();

                listView1.Columns.Add("ID", 100);
                listView1.Columns.Add("Type", 100);
                listView1.Columns.Add("Icons", 100);

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
        public Expansion2()
        {
            InitializeComponent();
            Show_Expansion();
        }


        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                string query = "INSERT INTO File_extension (Type, Icons) VALUES ('"+ textBox2.Text + "', '" + file_Data + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                myConnection.Close();
                MessageBox.Show("Extension upload successfully");

                Task t = new Task(new Action(() =>
                {
                    listView1.Clear();
                    Show_Expansion();
                    this.Refresh();
                }));
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();
                string query = "DELETE FROM File_extension WHERE ID =" + textBox1.Text + "";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // выполняем запрос к MS Access
                command.ExecuteNonQuery();

                Task t = new Task(new Action(() =>
                {
                    listView1.Clear();
                    Show_Expansion();
                    this.Refresh();
                }));
                t.Start();

                MessageBox.Show("Extension deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void obzor_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "All files (*.*)|*.*";
            if (opfd.ShowDialog(this) == DialogResult.OK)
            {

                using (System.IO.FileStream fs = new System.IO.FileStream(opfd.FileName, System.IO.FileMode.Open))
                {
                    file_Data = new byte[fs.Length];
                    fs.Read(file_Data, 0, file_Data.Length);
                }
            }
        }
    }
}
