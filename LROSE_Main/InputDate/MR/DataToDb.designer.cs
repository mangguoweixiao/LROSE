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
            this.grpStandard.Location = new System.Drawing.Point(139, 87);
            this.grpStandard.Margin = new System.Windows.Forms.Padding(2);
            this.grpStandard.Name = "grpStandard";
            this.grpStandard.Padding = new System.Windows.Forms.Padding(2);
            this.grpStandard.Size = new System.Drawing.Size(323, 81);
            this.grpStandard.TabIndex = 0;
            this.grpStandard.TabStop = false;
            this.grpStandard.Text = "文件类型";
            // 
            // rdoTd
            // 
            this.rdoTd.AutoSize = true;
            this.rdoTd.Location = new System.Drawing.Point(181, 35);
            this.rdoTd.Margin = new System.Windows.Forms.Padding(2);
            this.rdoTd.Name = "rdoTd";
            this.rdoTd.Size = new System.Drawing.Size(35, 16);
            this.rdoTd.TabIndex = 3;
            this.rdoTd.TabStop = true;
            this.rdoTd.Text = "TD";
            this.rdoTd.UseVisualStyleBackColor = true;
            // 
            // rdoFd
            // 
            this.rdoFd.AutoSize = true;
            this.rdoFd.Location = new System.Drawing.Point(256, 35);
            this.rdoFd.Margin = new System.Windows.Forms.Padding(2);
            this.rdoFd.Name = "rdoFd";
            this.rdoFd.Size = new System.Drawing.Size(35, 16);
            this.rdoFd.TabIndex = 2;
            this.rdoFd.TabStop = true;
            this.rdoFd.Text = "FD";
            this.rdoFd.UseVisualStyleBackColor = true;
            // 
            // rdoTdd
            // 
            this.rdoTdd.AutoSize = true;
            this.rdoTdd.Location = new System.Drawing.Point(32, 35);
            this.rdoTdd.Margin = new System.Windows.Forms.Padding(2);
            this.rdoTdd.Name = "rdoTdd";
            this.rdoTdd.Size = new System.Drawing.Size(41, 16);
            this.rdoTdd.TabIndex = 1;
            this.rdoTdd.TabStop = true;
            this.rdoTdd.Text = "TDD";
            this.rdoTdd.UseVisualStyleBackColor = true;
            // 
            // rdoFdd
            // 
            this.rdoFdd.AutoSize = true;
            this.rdoFdd.Location = new System.Drawing.Point(107, 35);
            this.rdoFdd.Margin = new System.Windows.Forms.Padding(2);
            this.rdoFdd.Name = "rdoFdd";
            this.rdoFdd.Size = new System.Drawing.Size(41, 16);
            this.rdoFdd.TabIndex = 0;
            this.rdoFdd.TabStop = true;
            this.rdoFdd.Text = "FDD";
            this.rdoFdd.UseVisualStyleBackColor = true;
            // 
            // btnToDb
            // 
            this.btnToDb.Location = new System.Drawing.Point(246, 199);
            this.btnToDb.Margin = new System.Windows.Forms.Padding(2);
            this.btnToDb.Name = "btnToDb";
            this.btnToDb.Size = new System.Drawing.Size(109, 45);
            this.btnToDb.TabIndex = 1;
            this.btnToDb.Text = "解析入库";
            this.btnToDb.UseVisualStyleBackColor = true;
            this.btnToDb.Click += new System.EventHandler(this.btnToDb_Click);
            // 
            // txtShowPro
            // 
            this.txtShowPro.Location = new System.Drawing.Point(139, 283);
            this.txtShowPro.Margin = new System.Windows.Forms.Padding(2);
            this.txtShowPro.Multiline = true;
            this.txtShowPro.Name = "txtShowPro";
            this.txtShowPro.Size = new System.Drawing.Size(323, 97);
            this.txtShowPro.TabIndex = 5;
            // 
            // DataToDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 387);
            this.Controls.Add(this.txtShowPro);
            this.Controls.Add(this.btnToDb);
            this.Controls.Add(this.grpStandard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "DataToDb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MR数据解析入库";
            this.Load += new System.EventHandler(this.DataToDb_Load);
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
        private System.Windows.Forms.TextBox txtShowPro;

        public System.EventHandler dataToDb_Load { get; set; }

        public System.EventHandler radioButton4_CheckedChanged { get; set; }
    }
}