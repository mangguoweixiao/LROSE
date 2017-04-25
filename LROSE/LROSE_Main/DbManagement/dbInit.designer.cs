namespace LROSE_Main.DbManagement
{
    partial class dbInit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbInit));
            this.btnNewDb = new System.Windows.Forms.Button();
            this.btnDbInit = new System.Windows.Forms.Button();
            this.btnDbDelete = new System.Windows.Forms.Button();
            this.cmbDb = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.txtDbInit = new System.Windows.Forms.TextBox();
            this.lblDb = new System.Windows.Forms.Label();
            this.pgbDbInit = new System.Windows.Forms.ProgressBar();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewDb
            // 
            this.btnNewDb.Location = new System.Drawing.Point(197, 40);
            this.btnNewDb.Name = "btnNewDb";
            this.btnNewDb.Size = new System.Drawing.Size(522, 28);
            this.btnNewDb.TabIndex = 0;
            this.btnNewDb.Text = "新建数据库";
            this.btnNewDb.UseVisualStyleBackColor = true;
            this.btnNewDb.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDbInit
            // 
            this.btnDbInit.Location = new System.Drawing.Point(534, 118);
            this.btnDbInit.Name = "btnDbInit";
            this.btnDbInit.Size = new System.Drawing.Size(75, 29);
            this.btnDbInit.TabIndex = 1;
            this.btnDbInit.Text = "初始化";
            this.btnDbInit.UseVisualStyleBackColor = true;
            this.btnDbInit.Click += new System.EventHandler(this.btnDbInit_Click);
            // 
            // btnDbDelete
            // 
            this.btnDbDelete.Location = new System.Drawing.Point(644, 118);
            this.btnDbDelete.Name = "btnDbDelete";
            this.btnDbDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDbDelete.TabIndex = 2;
            this.btnDbDelete.Text = "删除数据库";
            this.btnDbDelete.UseVisualStyleBackColor = true;
            this.btnDbDelete.Click += new System.EventHandler(this.btnDbDeleter_Click);
            // 
            // cmbDb
            // 
            this.cmbDb.FormattingEnabled = true;
            this.cmbDb.Items.AddRange(new object[] {
            "请选择数据库"});
            this.cmbDb.Location = new System.Drawing.Point(271, 121);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Size = new System.Drawing.Size(226, 26);
            this.cmbDb.TabIndex = 3;
            this.cmbDb.Text = "请选择数据库";
            this.cmbDb.SelectedIndexChanged += new System.EventHandler(this.cmbDb_SelectedIndexChanged);
            this.cmbDb.TextChanged += new System.EventHandler(this.cmbDb_TextChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // txtDbInit
            // 
            this.txtDbInit.Location = new System.Drawing.Point(197, 290);
            this.txtDbInit.Multiline = true;
            this.txtDbInit.Name = "txtDbInit";
            this.txtDbInit.Size = new System.Drawing.Size(522, 178);
            this.txtDbInit.TabIndex = 4;
            this.txtDbInit.TextChanged += new System.EventHandler(this.txtDbInit_TextChanged);
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Location = new System.Drawing.Point(197, 129);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(62, 18);
            this.lblDb.TabIndex = 5;
            this.lblDb.Text = "数据库";
            this.lblDb.Click += new System.EventHandler(this.lblDb_Click);
            // 
            // pgbDbInit
            // 
            this.pgbDbInit.Location = new System.Drawing.Point(197, 205);
            this.pgbDbInit.Name = "pgbDbInit";
            this.pgbDbInit.Size = new System.Drawing.Size(522, 23);
            this.pgbDbInit.TabIndex = 6;
            this.pgbDbInit.Click += new System.EventHandler(this.pgbDbInit_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(422, 510);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 31);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dbInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 595);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pgbDbInit);
            this.Controls.Add(this.lblDb);
            this.Controls.Add(this.txtDbInit);
            this.Controls.Add(this.cmbDb);
            this.Controls.Add(this.btnDbDelete);
            this.Controls.Add(this.btnDbInit);
            this.Controls.Add(this.btnNewDb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dbInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据解析入库";
            this.Load += new System.EventHandler(this.dbInit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewDb;
        private System.Windows.Forms.Button btnDbInit;
        private System.Windows.Forms.Button btnDbDelete;
        private System.Windows.Forms.ComboBox cmbDb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox txtDbInit;
        private System.Windows.Forms.Label lblDb;
        private System.Windows.Forms.ProgressBar pgbDbInit;
        private System.Windows.Forms.Button btnNext;
    }
}