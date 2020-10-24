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
            this.Mount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTPWith = new System.Windows.Forms.DateTimePicker();
            this.dTPBy = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 284);
            this.dataGridView1.TabIndex = 0;
            // 
            // Mount
            // 
            this.Mount.HeaderText = "Месяц";
            this.Mount.Name = "Mount";
            this.Mount.ReadOnly = true;
            // 
            // SC
            // 
            this.SC.HeaderText = "МК";
            this.SC.Name = "SC";
            this.SC.ReadOnly = true;
            // 
            // MC
            // 
            this.MC.HeaderText = "СК";
            this.MC.Name = "MC";
            this.MC.ReadOnly = true;
            // 
            // LC
            // 
            this.LC.HeaderText = "БК";
            this.LC.Name = "LC";
            this.LC.ReadOnly = true;
            // 
            // ESC
            // 
            this.ESC.HeaderText = "ОМК";
            this.ESC.Name = "ESC";
            this.ESC.ReadOnly = true;
            // 
            // ELC
            // 
            this.ELC.HeaderText = "ОБК";
            this.ELC.Name = "ELC";
            this.ELC.ReadOnly = true;
            // 
            // dTPWith
            // 
            this.dTPWith.Location = new System.Drawing.Point(32, 11);
            this.dTPWith.Name = "dTPWith";
            this.dTPWith.Size = new System.Drawing.Size(141, 20);
            this.dTPWith.TabIndex = 1;
            this.dTPWith.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // dTPBy
            // 
            this.dTPBy.Location = new System.Drawing.Point(215, 11);
            this.dTPBy.Name = "dTPBy";
            this.dTPBy.Size = new System.Drawing.Size(139, 20);
            this.dTPBy.TabIndex = 2;
            this.dTPBy.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "По";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Расчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPrilo3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dTPBy);
            this.Controls.Add(this.dTPWith);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(686, 377);
            this.MinimumSize = new System.Drawing.Size(686, 377);
            this.Name = "FormPrilo3";
            this.Text = "FormPrilo3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELC;
        private System.Windows.Forms.DateTimePicker dTPWith;
        private System.Windows.Forms.DateTimePicker dTPBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}