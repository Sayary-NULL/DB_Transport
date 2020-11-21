namespace Test1.Forms
{
    partial class FormPrilo3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dTPWith = new System.Windows.Forms.DateTimePicker();
            this.dTPBy = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Mount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mount,
            this.SC,
            this.MC,
            this.LC,
            this.ESC,
            this.ELC});
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 330);
            this.dataGridView1.TabIndex = 0;
            // 
            // dTPWith
            // 
            this.dTPWith.Location = new System.Drawing.Point(33, 64);
            this.dTPWith.Name = "dTPWith";
            this.dTPWith.Size = new System.Drawing.Size(141, 20);
            this.dTPWith.TabIndex = 1;
            this.dTPWith.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // dTPBy
            // 
            this.dTPBy.Location = new System.Drawing.Point(216, 64);
            this.dTPBy.Name = "dTPBy";
            this.dTPBy.Size = new System.Drawing.Size(139, 20);
            this.dTPBy.TabIndex = 2;
            this.dTPBy.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "По";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(383, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Расчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(139, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(270, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(188, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(474, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Выбрать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Порядковый номер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Название";
            // 
            // Mount
            // 
            this.Mount.HeaderText = "Месяц";
            this.Mount.Name = "Mount";
            this.Mount.ReadOnly = true;
            this.Mount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SC
            // 
            this.SC.HeaderText = "МК";
            this.SC.Name = "SC";
            this.SC.ReadOnly = true;
            this.SC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MC
            // 
            this.MC.HeaderText = "СК";
            this.MC.Name = "MC";
            this.MC.ReadOnly = true;
            this.MC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LC
            // 
            this.LC.HeaderText = "БК";
            this.LC.Name = "LC";
            this.LC.ReadOnly = true;
            this.LC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ESC
            // 
            this.ESC.HeaderText = "ОМК";
            this.ESC.Name = "ESC";
            this.ESC.ReadOnly = true;
            this.ESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ELC
            // 
            this.ELC.HeaderText = "ОБК";
            this.ELC.Name = "ELC";
            this.ELC.ReadOnly = true;
            this.ELC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormPrilo3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 435);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dTPBy);
            this.Controls.Add(this.dTPWith);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(686, 500);
            this.MinimumSize = new System.Drawing.Size(686, 377);
            this.Name = "FormPrilo3";
            this.Text = "FormPrilo3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dTPWith;
        private System.Windows.Forms.DateTimePicker dTPBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELC;
    }
}