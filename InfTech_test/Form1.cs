using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace InfTech_test
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;";
        private OleDbConnection myConnection;

        public void AddNodeinNode(TreeNode Parent, List<List<string>> all_folders, List<string> parent_info, List<MyFile> myFiles)
        {
            int k = 0;
            foreach (List<string> Folder in all_folders)
            {
                if (parent_info[0] == Folder[2])
                { 
                    TreeNode new_node = new TreeNode(Folder[1]);
                    Parent.Nodes.Add(new_node);
                    AddNodeinNode(Parent.Nodes[k], all_folders, Folder, myFiles);
                    k++;
                }               
            }
            File_Node(parent_info[0], myFiles, Parent);
        }

        public class MyFile
        {
            public MyFile(string id, string filename, string title, byte[] data, string extension, byte[] icons)
            {
                Dir_Id = id;
                FileName = filename;
                Title = title;
                Data = data;
                Extension = extension;
                Icons = icons;

            }
            public string Dir_Id { get; private set; }
            public string FileName { get; private set; }
            public string Title { get; private set; }
            public byte[] Data { get; private set; }
            public string Extension { get; private set; }
            public byte[] Icons { get; private set; }
        }

        public void File_Node(string ID, List<MyFile> myFiles, TreeNode Parent)
        {
            foreach (MyFile File in myFiles)
            {
                if (File.Dir_Id==ID) // определение корневых папок 
                {
                    TreeNode new_node = new TreeNode(File.FileName + "." + File.Extension);
                    new_node.Tag = "file";
                    new_node.Text = File.Title;
                    Parent.Nodes.Add(new_node);

                }
            }
        }
        
        public void Add_Node_for_TreeViwe()
        {
            //создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);
            // открываем соединение с БД
            myConnection.Open();
            string query = "SELECT ID, Folder_name, Parent_folder_code FROM Folder ";
            string query2 = "SELECT File.Folder_code, File.File_name, File.Description, File.Content, File_extension.Type, File_extension.Icons FROM File_extension INNER JOIN File ON File_extension.ID = File.Code_file_type";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbCommand command2 = new OleDbCommand(query2, myConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            OleDbDataReader reader2 = command2.ExecuteReader();

            List< MyFile > Files_data = new List<MyFile>();
            // в цикле построчно читаем ответ от БД
            while (reader2.Read())
            {
                MyFile list = new MyFile(reader2[0].ToString(), reader2[1].ToString(), reader2[2].ToString(), (byte[])reader2.GetValue(3), reader2[4].ToString(), (byte[])reader2.GetValue(5));
                Files_data.Add(list);
            }

            List<List<string>> Folders_data = new List<List<string>>();
            List<string> Folder_ID = new List<string>();

            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                Folder_ID.Add(reader[0].ToString());
                List<string> list = new List<string>();
                list.Add(reader[0].ToString());
                list.Add(reader[1].ToString());
                list.Add(reader[2].ToString());
                Folders_data.Add(list);
            }

            foreach (List<string> ID_P in Folders_data)
            {
                if (!Folder_ID.Contains(ID_P[2])) // определение корневой папки 
                {
                    TreeNode node1 = new TreeNode(ID_P[1]);
                    treeView1.Nodes.Add(node1);
                    AddNodeinNode(treeView1.Nodes[0], Folders_data, ID_P, Files_data);
                    break;
                }
            }
            //закрываем OleDbDataReader
            reader.Close();
        }

        //private void GetTreeViewItems()
        //{
        //    myConnection = new OleDbConnection(connectString);
        //    // открываем соединение с БД
        //    myConnection.Open();
        //    string query = "SELECT ID, Folder_name, Parent_folder_code FROM Folder ";
        //    OleDbDataAdapter da = new OleDbDataAdapter(query, myConnection);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    ds.Relations.Add("ChildRows", ds.Tables["Folder"].Columns["ID"],
        //        ds.Tables["Folder"].Columns["Parent_folder_code"]);

        //    foreach (DataRow level1DataRow in ds.Tables["Folder"].Rows)
        //    {
        //        if (string.IsNullOrEmpty(level1DataRow["Parent_folder_code"].ToString()))
        //        {
        //            TreeNode parentTreeNode = new TreeNode();
        //            parentTreeNode.Text = level1DataRow["Folder_name"].ToString();            
        //            GetChildRows(level1DataRow, parentTreeNode);
        //            treeView1.Nodes.Add(parentTreeNode);
        //        }
        //    }
        //}

        //private void GetChildRows(DataRow dataRow, TreeNode treeNode)
        //{
        //    DataRow[] childRows = dataRow.GetChildRows("ChildRows");
        //    foreach (DataRow row in childRows)
        //    {
        //        TreeNode childTreeNode = new TreeNode();
        //        childTreeNode.Text = row["Folder_name"].ToString();
        //        //treeNode.ChildNodes.Add(childTreeNode);

        //        if (row.GetChildRows("ChildRows").Length > 0)
        //        {
        //            GetChildRows(row, childTreeNode);
        //        }
        //    }
        //}


        void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            string minusPath = Application.StartupPath + Path.DirectorySeparatorChar +"icons" + Path.DirectorySeparatorChar + "f_c.png";
            string plusPath = Application.StartupPath + Path.DirectorySeparatorChar + "icons" + Path.DirectorySeparatorChar + "f_o.png";
            string filePath = Application.StartupPath + Path.DirectorySeparatorChar + "icons" + Path.DirectorySeparatorChar + "file.png";
            
            Rectangle nodeRect = e.Node.Bounds;
            /*--------- 1. draw expand/collapse icon ---------*/
            Point ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 2);
            Image expandImg = null;
            if (e.Node.Tag == "file")
            {
                expandImg = Image.FromFile(filePath);
            }
            else
            {
                if (e.Node.IsExpanded || e.Node.Nodes.Count < 1)
                    expandImg = Image.FromFile(minusPath);
                else
                    expandImg = Image.FromFile(plusPath);
            }
            
            Graphics g = Graphics.FromImage(expandImg);
            IntPtr imgPtr = g.GetHdc();
            g.ReleaseHdc();
            e.Graphics.DrawImage(expandImg, ptExpand);

            /*--------- 2. draw node text ---------*/
            Font nodeFont = e.Node.NodeFont;       
            if (nodeFont == null)
                nodeFont = ((TreeView)sender).Font;
            
            Brush textBrush = SystemBrushes.WindowText;
            //to highlight the text when selected
            if ((e.State & TreeNodeStates.Focused) != 0)
                textBrush = SystemBrushes.HotTrack;
            //Inflate to not be cut
            Rectangle textRect = nodeRect;
            //need to extend node rect
            textRect.Width += 40;
            e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush, Rectangle.Inflate(textRect, -12, 0));
        }

        public Form1()
        {
            InitializeComponent();
            treeView1.Nodes.Clear();
            Add_Node_for_TreeViwe();
            this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);
        }

        private void Create_dir_Click(object sender, EventArgs e)
        {
            try
            {
                Create_dir f2 = new Create_dir();
                f2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Delete_dir_Click(object sender, EventArgs e)
        {
            try
            {
                Delete_dir f3 = new Delete_dir();
                f3.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void Delete_file_Click(object sender, EventArgs e)
        {
            try
            {
                Delete_file f6 = new Delete_file();
                f6.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void Upload_file_Click(object sender, EventArgs e)
        {
            try
            {
                Upload_file f4 = new Upload_file();
                f4.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void Download_file_Click(object sender, EventArgs e)
        {
            try
            {
                Download_file f5 = new Download_file();
                f5.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            try
            {
                Rename f5 = new Rename();
                f5.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File_contents f5 = new File_contents();
                f5.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }


        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            var node = treeView1.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                if (node.Tag == "file")
                {
                    var text = node.Text;

                    if (!text.Equals(this.toolTip1.GetToolTip(this)))
                    {
                        this.toolTip1.Show(text, this, e.Location.X + 40, e.Location.Y + 90, 3000);
                    }
                }
                
            }
            else
            {
                this.toolTip1.RemoveAll();
            }
        }

        private void Expansion_Click(object sender, EventArgs e)
        {
            try
            {
                Expansion2 f5 = new Expansion2();
                f5.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");

            }
        }
    }
}

