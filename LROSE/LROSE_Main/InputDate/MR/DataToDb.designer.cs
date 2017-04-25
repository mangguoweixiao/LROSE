namespace LROSE_Main.InputDate.MR
{
    partial class DataToDb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataToDb));
            this.grpStandard = new System.Windows.Forms.GroupBox();
            this.rdoTd = new System.Windows.Forms.RadioButton();
            this.rdoFd = new System.Windows.Forms.RadioButton();
            this.rdoTdd = new System.Windows.Forms.RadioButton();
            this.rdoFdd = new System.Windows.Forms.RadioButton();
            this.btnToDb = new System.Windows.Forms.Button();
            this.pgbToDb = new System.Windows.Forms.ProgressBar();
            this.txtShowPro = new System.Windows.Forms.TextBox();
            this.grpStandard.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStandard
            // 
            this.grpStandard.Controls.Add(this.rdoTd);
            this.grpStandard.Controls.Add(this.rdoFd);
            this.grpStandard.Controls.Add(this.rdoTdd);
            this.grpStandard.Controls.Add(this.rdoFdd);
            this.grpStandard.Location = new System.Drawing.Point(208, 114);
            this.grpStandard.Name = "grpStandard";
            this.grpStandard.Size = new System.Drawing.Size(484, 122);
            this.grpStandard.TabIndex = 0;
            this.grpStandard.TabStop = false;
            this.grpStandard.Text = "文件类型";
            // 
            // rdoTd
            // 
            this.rdoTd.AutoSize = true;
            this.rdoTd.Location = new System.Drawing.Point(272, 52);
            this.rdoTd.Name = "rdoTd";
            this.rdoTd.Size = new System.Drawing.Size(51, 22);
            this.rdoTd.TabIndex = 3;
            this.rdoTd.TabStop = true;
            this.rdoTd.Text = "TD";
            this.rdoTd.UseVisualStyleBackColor = true;
            // 
            // rdoFd
            // 
            this.rdoFd.AutoSize = true;
            this.rdoFd.Location = new System.Drawing.Point(384, 52);
            this.rdoFd.Name = "rdoFd";
            this.rdoFd.Size = new System.Drawing.Size(51, 22);
            this.rdoFd.TabIndex = 2;
            this.rdoFd.TabStop = true;
            this.rdoFd.Text = "FD";
            this.rdoFd.UseVisualStyleBackColor = true;
            // 
            // rdoTdd
            // 
            this.rdoTdd.AutoSize = true;
            this.rdoTdd.Location = new System.Drawing.Point(48, 52);
            this.rdoTdd.Name = "rdoTdd";
            this.rdoTdd.Size = new System.Drawing.Size(60, 22);
            this.rdoTdd.TabIndex = 1;
            this.rdoTdd.TabStop = true;
            this.rdoTdd.Text = "TDD";
            this.rdoTdd.UseVisualStyleBackColor = true;
            // 
            // rdoFdd
            // 
            this.rdoFdd.AutoSize = true;
            this.rdoFdd.Location = new System.Drawing.Point(160, 52);
            this.rdoFdd.Name = "rdoFdd";
            this.rdoFdd.Size = new System.Drawing.Size(60, 22);
            this.rdoFdd.TabIndex = 0;
            this.rdoFdd.TabStop = true;
            this.rdoFdd.Text = "FDD";
            this.rdoFdd.UseVisualStyleBackColor = true;
            // 
            // btnToDb
            // 
            this.btnToDb.Location = new System.Drawing.Point(396, 345);
            this.btnToDb.Name = "btnToDb";
            this.btnToDb.Size = new System.Drawing.Size(98, 34);
            this.btnToDb.TabIndex = 1;
            this.btnToDb.Text = "文件解析";
            this.btnToDb.UseVisualStyleBackColor = true;
            this.btnToDb.Click += new System.EventHandler(this.btnToDb_Click);
            // 
            // pgbToDb
            // 
            this.pgbToDb.Location = new System.Drawing.Point(208, 279);
            this.pgbToDb.Name = "pgbToDb";
            this.pgbToDb.Size = new System.Drawing.Size(484, 22);
            this.pgbToDb.TabIndex = 2;
            // 
            // txtShowPro
            // 
            this.txtShowPro.Location = new System.Drawing.Point(209, 424);
            this.txtShowPro.Multiline = true;
            this.txtShowPro.Name = "txtShowPro";
            this.txtShowPro.Size = new System.Drawing.Size(483, 144);
            this.txtShowPro.TabIndex = 5;
            // 
            // DataToDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 580);
            this.Controls.Add(this.txtShowPro);
            this.Controls.Add(this.pgbToDb);
            this.Controls.Add(this.btnToDb);
            this.Controls.Add(this.grpStandard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataToDb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据解析入库";
            this.grpStandard.ResumeLayout(false);
            this.grpStandard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStandard;
        private System.Windows.Forms.RadioButton rdoTd;
        private System.Windows.Forms.RadioButton rdoFd;
        private System.Windows.Forms.RadioButton rdoTdd;
        private System.Windows.Forms.RadioButton rdoFdd;
        private System.Windows.Forms.Button btnToDb;
        private System.Windows.Forms.ProgressBar pgbToDb;
        private System.Windows.Forms.TextBox txtShowPro;

        public System.EventHandler dataToDb_Load { get; set; }

        public System.EventHandler radioButton4_CheckedChanged { get; set; }
    }
}