
namespace Test1.Forms.FromPrilojenie3
{
    partial class FormPrilo3Contract
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dTPBy = new System.Windows.Forms.DateTimePicker();
            this.dTPWith = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Mount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(580, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Расчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "По";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "C";
            // 
            // dTPBy
            // 
            this.dTPBy.Location = new System.Drawing.Point(216, 13);
            this.dTPBy.Name = "dTPBy";
            this.dTPBy.Size = new System.Drawing.Size(139, 20);
            this.dTPBy.TabIndex = 15;
            this.dTPBy.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            // 
            // dTPWith
            // 
            this.dTPWith.Location = new System.Drawing.Point(33, 13);
            this.dTPWith.Name = "dTPWith";
            this.dTPWith.Size = new System.Drawing.Size(141, 20);
            this.dTPWith.TabIndex = 14;
            this.dTPWith.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 330);
            this.dataGridView1.TabIndex = 13;
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(483, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Номер договора";
            // 
            // FormPrilo3Contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 380);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dTPBy);
            this.Controls.Add(this.dTPWith);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormPrilo3Contract";
            this.Text = "FormPrilo3Contract";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTPBy;
        private System.Windows.Forms.DateTimePicker dTPWith;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELC;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}