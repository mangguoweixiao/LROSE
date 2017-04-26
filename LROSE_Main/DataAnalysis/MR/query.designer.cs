namespace LROSE_Main
{
    partial class query
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(query));
            this.lblTable = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.cmbVersion = new System.Windows.Forms.ComboBox();
            this.cmbCounter = new System.Windows.Forms.ComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTextBox1 = new System.Windows.Forms.TextBox();
            this.cmbTextBox2 = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.cmbDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ShowDataGridView = new System.Windows.Forms.DataGridView();
            this.cmbDateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ShowDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(423, 21);
            this.lblTable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(17, 12);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "表";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(222, 21);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 12);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "类型";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(65, 21);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(29, 12);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "版本";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(590, 21);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(29, 12);
            this.lblCounter.TabIndex = 3;
            this.lblCounter.Text = "指标";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(443, 76);
            this.lblThreshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(29, 12);
            this.lblThreshold.TabIndex = 4;
            this.lblThreshold.Text = "门限";
            this.lblThreshold.Click += new System.EventHandler(this.lblThreshold_Click);
            // 
            // cmbVersion
            // 
            this.cmbVersion.FormattingEnabled = true;
            this.cmbVersion.Location = new System.Drawing.Point(98, 18);
            this.cmbVersion.Margin = new System.Windows.Forms.Padding(2);
            this.cmbVersion.Name = "cmbVersion";
            this.cmbVersion.Size = new System.Drawing.Size(94, 20);
            this.cmbVersion.TabIndex = 5;
            this.cmbVersion.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbCounter
            // 
            this.cmbCounter.FormattingEnabled = true;
            this.cmbCounter.Location = new System.Drawing.Point(623, 18);
            this.cmbCounter.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCounter.Name = "cmbCounter";
            this.cmbCounter.Size = new System.Drawing.Size(198, 20);
            this.cmbCounter.TabIndex = 8;
            this.cmbCounter.SelectedIndexChanged += new System.EventHandler(this.cmbCounter_SelectedIndexChanged);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(64, 76);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 12);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "时段";
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(445, 18);
            this.cmbTable.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(109, 20);
            this.cmbTable.TabIndex = 11;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(255, 18);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(122, 20);
            this.cmbType.TabIndex = 12;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = " ---";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = " ---";
            // 
            // cmbTextBox1
            // 
            this.cmbTextBox1.Location = new System.Drawing.Point(477, 70);
            this.cmbTextBox1.Name = "cmbTextBox1";
            this.cmbTextBox1.Size = new System.Drawing.Size(100, 21);
            this.cmbTextBox1.TabIndex = 17;
            this.cmbTextBox1.TextChanged += new System.EventHandler(this.cmbTextBox1_TextChanged);
            // 
            // cmbTextBox2
            // 
            this.cmbTextBox2.Location = new System.Drawing.Point(616, 70);
            this.cmbTextBox2.Name = "cmbTextBox2";
            this.cmbTextBox2.Size = new System.Drawing.Size(100, 21);
            this.cmbTextBox2.TabIndex = 18;
            this.cmbTextBox2.TextChanged += new System.EventHandler(this.cmbTextBox2_TextChanged);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartButton.Location = new System.Drawing.Point(728, 54);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(78, 70);
            this.StartButton.TabIndex = 19;
            this.StartButton.Text = "开始查询";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cmbDateTimePicker1
            // 
            this.cmbDateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.cmbDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbDateTimePicker1.Location = new System.Drawing.Point(98, 70);
            this.cmbDateTimePicker1.Name = "cmbDateTimePicker1";
            this.cmbDateTimePicker1.Size = new System.Drawing.Size(132, 21);
            this.cmbDateTimePicker1.TabIndex = 20;
            this.cmbDateTimePicker1.ValueChanged += new System.EventHandler(this.cmbDateTimePicker1_ValueChanged);
            // 
            // ShowDataGridView
            // 
            this.ShowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowDataGridView.Location = new System.Drawing.Point(592, 145);
            this.ShowDataGridView.Name = "ShowDataGridView";
            this.ShowDataGridView.RowTemplate.Height = 23;
            this.ShowDataGridView.Size = new System.Drawing.Size(289, 296);
            this.ShowDataGridView.TabIndex = 21;
            this.ShowDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowDataGridView_CellContentClick);
            // 
            // cmbDateTimePicker2
            // 
            this.cmbDateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.cmbDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbDateTimePicker2.Location = new System.Drawing.Point(273, 70);
            this.cmbDateTimePicker2.Name = "cmbDateTimePicker2";
            this.cmbDateTimePicker2.Size = new System.Drawing.Size(132, 21);
            this.cmbDateTimePicker2.TabIndex = 22;
            this.cmbDateTimePicker2.ValueChanged += new System.EventHandler(this.cmbDateTimePicker2_ValueChanged);
            // 
            // query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 494);
            this.Controls.Add(this.cmbDateTimePicker2);
            this.Controls.Add(this.ShowDataGridView);
            this.Controls.Add(this.cmbDateTimePicker1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.cmbTextBox2);
            this.Controls.Add(this.cmbTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.cmbCounter);
            this.Controls.Add(this.cmbVersion);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "query";
            this.Text = "数据查询";
            this.Load += new System.EventHandler(this.analysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShowDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.ComboBox cmbVersion;
        private System.Windows.Forms.ComboBox cmbCounter;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cmbTextBox1;
        private System.Windows.Forms.TextBox cmbTextBox2;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.DateTimePicker cmbDateTimePicker1;
        private System.Windows.Forms.DataGridView ShowDataGridView;
        private System.Windows.Forms.DateTimePicker cmbDateTimePicker2;

    }
}