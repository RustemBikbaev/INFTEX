namespace InfTech_test
{
    partial class Upload_file
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Open_file_dialog = new System.Windows.Forms.Button();
            this.Uplode = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(209, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите описание файла";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите код папки расположения файла";
            // 
            // Open_file_dialog
            // 
            this.Open_file_dialog.Location = new System.Drawing.Point(104, 97);
            this.Open_file_dialog.Name = "Open_file_dialog";
            this.Open_file_dialog.Size = new System.Drawing.Size(131, 39);
            this.Open_file_dialog.TabIndex = 6;
            this.Open_file_dialog.Text = "Выберите файл";
            this.Open_file_dialog.UseVisualStyleBackColor = true;
            this.Open_file_dialog.Click += new System.EventHandler(this.Open_file_dialog_Click);
            // 
            // Uplode
            // 
            this.Uplode.Location = new System.Drawing.Point(104, 153);
            this.Uplode.Name = "Uplode";
            this.Uplode.Size = new System.Drawing.Size(131, 40);
            this.Uplode.TabIndex = 7;
            this.Uplode.Text = "Загрузить";
            this.Uplode.UseVisualStyleBackColor = true;
            this.Uplode.Click += new System.EventHandler(this.Uplode_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(241, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Upload_file
            // 
            this.ClientSize = new System.Drawing.Size(396, 226);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Uplode);
            this.Controls.Add(this.Open_file_dialog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Name = "Upload_file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Open_file_dialog;
        private System.Windows.Forms.Button Uplode;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}