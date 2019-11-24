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
    public partial class Upload_file : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;";
        private OleDbConnection myConnection;

        string filename;
        string description;
        string extension;
        // массив для хранения бинарных данных файла
        byte[] file_Data;

        public void Combo_Box_init()
        {
            //создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);
            // открываем соединение с БД
            myConnection.Open();

            string query = "SELECT ID FROM Folder ";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();

            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());
            }
            myConnection.Close();
        }

        public Upload_file()
        {
            InitializeComponent();
            Combo_Box_init();
        }

        private void Open_file_dialog_Click(object sender, EventArgs e)
        {
            string file_types = "";
            List<List<string>> list = new List<List<string>>();
            try
            {
                myConnection = new OleDbConnection(connectString);
                // открываем соединение с БД
                myConnection.Open();

                string query = "SELECT ID, Type  FROM File_extension ";

                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, myConnection);

                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    List<string> arr = new List<string>();
                    arr.Add(reader[0].ToString());
                    arr.Add(reader[1].ToString());
                    list.Add(arr);
                    file_types += "(*." + reader[1].ToString() + ")|*." + reader[1].ToString() + "|";
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }

            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = file_types.Substring(0, file_types.LastIndexOf('|') - 1);
            if (opfd.ShowDialog(this) == DialogResult.OK)
            {
                filename = opfd.FileName.Substring(opfd.FileName.LastIndexOf('\\') + 1, opfd.FileName.LastIndexOf('.') - opfd.FileName.LastIndexOf('\\') - 1);
                extension = opfd.FileName.Substring(opfd.FileName.LastIndexOf('.') + 1);
                foreach (List<string> type in list)
                {
                    if (extension == type[1])
                    {
                        extension = type[0];
                        break;
                    }
                }
                description = textBox2.Text;
                using (System.IO.FileStream fs = new System.IO.FileStream(opfd.FileName, System.IO.FileMode.Open))
                {
                    file_Data = new byte[fs.Length];
                    fs.Read(file_Data, 0, file_Data.Length);
                }
            }
        }

        private void Uplode_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                string query = "INSERT INTO File (File_name, Description, Folder_code, Content, Code_file_type) VALUES ('" + filename + "', '" + description + "', " + comboBox1.SelectedItem.ToString() + ", '" + file_Data + "', '" + extension + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                myConnection.Close();
                MessageBox.Show("File upload successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }
    }
}
