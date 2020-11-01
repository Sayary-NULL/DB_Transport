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
            this.настройкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вариантРейсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.договорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подрятчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.вариантРейсаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.договорToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.подрядчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инфоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчитатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сравнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dGWMain = new System.Windows.Forms.DataGridView();
            this.LNameDataGrid = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGWMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.таблицыToolStripMenuItem,
            this.добавитьЗаписьToolStripMenuItem,
            this.инфоToolStripMenuItem,
            this.toolStripMenuItem1});
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
            // настройкиToolStripMenuItem1
            // 
            this.настройкиToolStripMenuItem1.Name = "настройкиToolStripMenuItem1";
            this.настройкиToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.настройкиToolStripMenuItem1.Text = "Настройки";
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
            this.маршрутToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.маршрутToolStripMenuItem.Text = "Маршрут";
            this.маршрутToolStripMenuItem.Click += new System.EventHandler(this.маршрутToolStripMenuItem_Click);
            // 
            // вариантРейсаToolStripMenuItem
            // 
            this.вариантРейсаToolStripMenuItem.Name = "вариантРейсаToolStripMenuItem";
            this.вариантРейсаToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.вариантРейсаToolStripMenuItem.Text = "Вариант рейса";
            this.вариантРейсаToolStripMenuItem.Click += new System.EventHandler(this.вариантРейсаToolStripMenuItem_Click);
            // 
            // договорToolStripMenuItem
            // 
            this.договорToolStripMenuItem.Name = "договорToolStripMenuItem";
            this.договорToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.договорToolStripMenuItem.Text = "Договор";
            this.договорToolStripMenuItem.Click += new System.EventHandler(this.договорToolStripMenuItem_Click);
            // 
            // подрятчикToolStripMenuItem
            // 
            this.подрятчикToolStripMenuItem.Name = "подрятчикToolStripMenuItem";
            this.подрятчикToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.подрятчикToolStripMenuItem.Text = "Подрядчик";
            this.подрятчикToolStripMenuItem.Click += new System.EventHandler(this.подрятчикToolStripMenuItem_Click);
            // 
            // добавитьЗаписьToolStripMenuItem
            // 
            this.добавитьЗаписьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.маршрутToolStripMenuItem1,
            this.вариантРейсаToolStripMenuItem1,
            this.договорToolStripMenuItem1,
            this.подрядчикToolStripMenuItem});
            this.добавитьЗаписьToolStripMenuItem.Name = "добавитьЗаписьToolStripMenuItem";
            this.добавитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.добавитьЗаписьToolStripMenuItem.Text = "Добавить";
            // 
            // маршрутToolStripMenuItem1
            // 
            this.маршрутToolStripMenuItem1.Name = "маршрутToolStripMenuItem1";
            this.маршрутToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.маршрутToolStripMenuItem1.Text = "Маршрут";
            this.маршрутToolStripMenuItem1.Click += new System.EventHandler(this.маршрутToolStripMenuItem1_Click);
            // 
            // вариантРейсаToolStripMenuItem1
            // 
            this.вариантРейсаToolStripMenuItem1.Name = "вариантРейсаToolStripMenuItem1";
            this.вариантРейсаToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.вариантРейсаToolStripMenuItem1.Text = "Вариант рейса";
            this.вариантРейсаToolStripMenuItem1.Click += new System.EventHandler(this.вариантРейсаToolStripMenuItem1_Click_1);
            // 
            // договорToolStripMenuItem1
            // 
            this.договорToolStripMenuItem1.Name = "договорToolStripMenuItem1";
            this.договорToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.договорToolStripMenuItem1.Text = "Договор";
            // 
            // подрядчикToolStripMenuItem
            // 
            this.подрядчикToolStripMenuItem.Name = "подрядчикToolStripMenuItem";
            this.подрядчикToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.подрядчикToolStripMenuItem.Text = "Подрядчик";
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
            this.расчитатьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.расчитатьToolStripMenuItem.Text = "Расчитать ";
            this.расчитатьToolStripMenuItem.Click += new System.EventHandler(this.расчитатьToolStripMenuItem_Click);
            // 
            // сравнитьToolStripMenuItem
            // 
            this.сравнитьToolStripMenuItem.Name = "сравнитьToolStripMenuItem";
            this.сравнитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сравнитьToolStripMenuItem.Text = "Сравнить";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1574, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1655, 27);
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
            // LNameDataGrid
            // 
            this.LNameDataGrid.AutoSize = true;
            this.LNameDataGrid.Location = new System.Drawing.Point(12, 32);
            this.LNameDataGrid.Name = "LNameDataGrid";
            this.LNameDataGrid.Size = new System.Drawing.Size(83, 13);
            this.LNameDataGrid.TabIndex = 4;
            this.LNameDataGrid.Text = "LNameDataGrid";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1736, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "обновить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1817, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Инфо";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dGWMain);
            this.Controls.Add(this.LNameDataGrid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximumSizeChanged += new System.EventHandler(this.FormMain_MaximumSizeChanged);
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
        private System.Windows.Forms.ToolStripMenuItem маршрутToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem вариантРейсаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem договорToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem подрядчикToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}