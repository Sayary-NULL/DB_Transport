namespace Test1.Forms
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инфоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчитатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сравнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dGWMain = new System.Windows.Forms.DataGridView();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вариантРейсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.договорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подрятчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LNameDataGrid = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGWMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.таблицыToolStripMenuItem,
            this.инфоToolStripMenuItem,
            this.toolStripMenuItem1,
            this.добавитьЗаписьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem1});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "файл";
            // 
            // инфоToolStripMenuItem
            // 
            this.инфоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.расчитатьToolStripMenuItem,
            this.сравнитьToolStripMenuItem});
            this.инфоToolStripMenuItem.Name = "инфоToolStripMenuItem";
            this.инфоToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.инфоToolStripMenuItem.Text = "Приложение 3";
            // 
            // расчитатьToolStripMenuItem
            // 
            this.расчитатьToolStripMenuItem.Name = "расчитатьToolStripMenuItem";
            this.расчитатьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.расчитатьToolStripMenuItem.Text = "Расчитать ";
            this.расчитатьToolStripMenuItem.Click += new System.EventHandler(this.расчитатьToolStripMenuItem_Click);
            // 
            // сравнитьToolStripMenuItem
            // 
            this.сравнитьToolStripMenuItem.Name = "сравнитьToolStripMenuItem";
            this.сравнитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сравнитьToolStripMenuItem.Text = "Сравнить";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // добавитьЗаписьToolStripMenuItem
            // 
            this.добавитьЗаписьToolStripMenuItem.Name = "добавитьЗаписьToolStripMenuItem";
            this.добавитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.добавитьЗаписьToolStripMenuItem.Text = "Добавить запись";
            this.добавитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.добавитьЗаписьToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(234, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dGWMain
            // 
            this.dGWMain.AllowUserToAddRows = false;
            this.dGWMain.AllowUserToDeleteRows = false;
            this.dGWMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGWMain.Location = new System.Drawing.Point(12, 56);
            this.dGWMain.Name = "dGWMain";
            this.dGWMain.ReadOnly = true;
            this.dGWMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGWMain.Size = new System.Drawing.Size(1880, 493);
            this.dGWMain.TabIndex = 3;
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.маршрутToolStripMenuItem,
            this.вариантРейсаToolStripMenuItem,
            this.договорToolStripMenuItem,
            this.подрятчикToolStripMenuItem});
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // маршрутToolStripMenuItem
            // 
            this.маршрутToolStripMenuItem.Name = "маршрутToolStripMenuItem";
            this.маршрутToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.маршрутToolStripMenuItem.Text = "Маршрут";
            this.маршрутToolStripMenuItem.Click += new System.EventHandler(this.маршрутToolStripMenuItem_Click);
            // 
            // вариантРейсаToolStripMenuItem
            // 
            this.вариантРейсаToolStripMenuItem.Name = "вариантРейсаToolStripMenuItem";
            this.вариантРейсаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.вариантРейсаToolStripMenuItem.Text = "Вариант рейса";
            this.вариантРейсаToolStripMenuItem.Click += new System.EventHandler(this.вариантРейсаToolStripMenuItem_Click);
            // 
            // договорToolStripMenuItem
            // 
            this.договорToolStripMenuItem.Name = "договорToolStripMenuItem";
            this.договорToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.договорToolStripMenuItem.Text = "Договор";
            this.договорToolStripMenuItem.Click += new System.EventHandler(this.договорToolStripMenuItem_Click);
            // 
            // подрятчикToolStripMenuItem
            // 
            this.подрятчикToolStripMenuItem.Name = "подрятчикToolStripMenuItem";
            this.подрятчикToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.подрятчикToolStripMenuItem.Text = "Подрятчик";
            this.подрятчикToolStripMenuItem.Click += new System.EventHandler(this.подрятчикToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem1
            // 
            this.настройкиToolStripMenuItem1.Name = "настройкиToolStripMenuItem1";
            this.настройкиToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.настройкиToolStripMenuItem1.Text = "Настройки";
            // 
            // LNameDataGrid
            // 
            this.LNameDataGrid.AutoSize = true;
            this.LNameDataGrid.Location = new System.Drawing.Point(12, 32);
            this.LNameDataGrid.Name = "LNameDataGrid";
            this.LNameDataGrid.Size = new System.Drawing.Size(83, 13);
            this.LNameDataGrid.TabIndex = 4;
            this.LNameDataGrid.Text = "LNameDataGrid";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.LNameDataGrid);
            this.Controls.Add(this.dGWMain);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGWMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инфоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расчитатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сравнитьToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dGWMain;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вариантРейсаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem договорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подрятчикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem1;
        private System.Windows.Forms.Label LNameDataGrid;
    }
}