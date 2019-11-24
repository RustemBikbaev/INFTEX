namespace InfTech_test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Create_dir = new System.Windows.Forms.Button();
            this.Delete_dir = new System.Windows.Forms.Button();
            this.Download_file = new System.Windows.Forms.Button();
            this.Upload_file = new System.Windows.Forms.Button();
            this.Delete_file = new System.Windows.Forms.Button();
            this.Rename = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Expansion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Create_dir
            // 
            this.Create_dir.Location = new System.Drawing.Point(0, 2);
            this.Create_dir.Name = "Create_dir";
            this.Create_dir.Size = new System.Drawing.Size(97, 32);
            this.Create_dir.TabIndex = 0;
            this.Create_dir.Text = "Создать Папку";
            this.Create_dir.UseVisualStyleBackColor = true;
            this.Create_dir.Click += new System.EventHandler(this.Create_dir_Click);
            // 
            // Delete_dir
            // 
            this.Delete_dir.Location = new System.Drawing.Point(103, 2);
            this.Delete_dir.Name = "Delete_dir";
            this.Delete_dir.Size = new System.Drawing.Size(97, 32);
            this.Delete_dir.TabIndex = 1;
            this.Delete_dir.Text = "Удалить Папку";
            this.Delete_dir.UseVisualStyleBackColor = true;
            this.Delete_dir.Click += new System.EventHandler(this.Delete_dir_Click);
            // 
            // Download_file
            // 
            this.Download_file.Location = new System.Drawing.Point(309, 2);
            this.Download_file.Name = "Download_file";
            this.Download_file.Size = new System.Drawing.Size(97, 32);
            this.Download_file.TabIndex = 3;
            this.Download_file.Text = "Скачать файл";
            this.Download_file.UseVisualStyleBackColor = true;
            this.Download_file.Click += new System.EventHandler(this.Download_file_Click);
            // 
            // Upload_file
            // 
            this.Upload_file.Location = new System.Drawing.Point(206, 2);
            this.Upload_file.Name = "Upload_file";
            this.Upload_file.Size = new System.Drawing.Size(97, 32);
            this.Upload_file.TabIndex = 4;
            this.Upload_file.Text = "Загрузить файл";
            this.Upload_file.UseVisualStyleBackColor = true;
            this.Upload_file.Click += new System.EventHandler(this.Upload_file_Click);
            // 
            // Delete_file
            // 
            this.Delete_file.Location = new System.Drawing.Point(412, 2);
            this.Delete_file.Name = "Delete_file";
            this.Delete_file.Size = new System.Drawing.Size(97, 32);
            this.Delete_file.TabIndex = 5;
            this.Delete_file.Text = "Удалить файл";
            this.Delete_file.UseVisualStyleBackColor = true;
            this.Delete_file.Click += new System.EventHandler(this.Delete_file_Click);
            // 
            // Rename
            // 
            this.Rename.Location = new System.Drawing.Point(515, 2);
            this.Rename.Name = "Rename";
            this.Rename.Size = new System.Drawing.Size(97, 32);
            this.Rename.TabIndex = 6;
            this.Rename.Text = "Переименовать";
            this.Rename.UseVisualStyleBackColor = true;
            this.Rename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 41);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 397);
            this.treeView1.TabIndex = 7;
            this.treeView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(222, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(556, 397);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Просмотр файла";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Expansion
            // 
            this.Expansion.Location = new System.Drawing.Point(725, 2);
            this.Expansion.Name = "Expansion";
            this.Expansion.Size = new System.Drawing.Size(142, 33);
            this.Expansion.TabIndex = 11;
            this.Expansion.Text = "Работа с расширениями";
            this.Expansion.UseVisualStyleBackColor = true;
            this.Expansion.Click += new System.EventHandler(this.Expansion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.Expansion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.Rename);
            this.Controls.Add(this.Delete_file);
            this.Controls.Add(this.Upload_file);
            this.Controls.Add(this.Download_file);
            this.Controls.Add(this.Delete_dir);
            this.Controls.Add(this.Create_dir);
            this.Name = "Form1";
            this.Text = "Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Create_dir;
        private System.Windows.Forms.Button Delete_dir;
        private System.Windows.Forms.Button Download_file;
        private System.Windows.Forms.Button Upload_file;
        private System.Windows.Forms.Button Delete_file;
        private System.Windows.Forms.Button Rename;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Expansion;
    }
}

