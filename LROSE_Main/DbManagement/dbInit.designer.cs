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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.grpStandard = new System.Windows.Forms.GroupBox();
            this.grpStandard.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewDb
            // 
            this.btnNewDb.Location = new System.Drawing.Point(131, 27);
            this.btnNewDb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewDb.Name = "btnNewDb";
            this.btnNewDb.Size = new System.Drawing.Size(348, 19);
            this.btnNewDb.TabIndex = 0;
            this.btnNewDb.Text = "新建数据库";
            this.btnNewDb.UseVisualStyleBackColor = true;
            this.btnNewDb.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDbInit
            // 
            this.btnDbInit.Location = new System.Drawing.Point(19, 67);
            this.btnDbInit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDbInit.Name = "btnDbInit";
            this.btnDbInit.Size = new System.Drawing.Size(79, 21);
            this.btnDbInit.TabIndex = 1;
            this.btnDbInit.Text = "初始化";
            this.btnDbInit.UseVisualStyleBackColor = true;
            this.btnDbInit.Click += new System.EventHandler(this.btnDbInit_Click);
            // 
            // btnDbDelete
            // 
            this.btnDbDelete.Location = new System.Drawing.Point(251, 67);
            this.btnDbDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDbDelete.Name = "btnDbDelete";
            this.btnDbDelete.Size = new System.Drawing.Size(79, 21);
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
            this.cmbDb.Location = new System.Drawing.Point(109, 18);
            this.cmbDb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Size = new System.Drawing.Size(152, 20);
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
            this.txtDbInit.Location = new System.Drawing.Point(131, 193);
            this.txtDbInit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDbInit.Multiline = true;
            this.txtDbInit.Name = "txtDbInit";
            this.txtDbInit.Size = new System.Drawing.Size(349, 120);
            this.txtDbInit.TabIndex = 4;
            this.txtDbInit.TextChanged += new System.EventHandler(this.txtDbInit_TextChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(269, 332);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 21);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(138, 67);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(79, 21);
            this.btnSure.TabIndex = 8;
            this.btnSure.Text = "确认";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // grpStandard
            // 
            this.grpStandard.Controls.Add(this.btnSure);
            this.grpStandard.Controls.Add(this.btnDbDelete);
            this.grpStandard.Controls.Add(this.cmbDb);
            this.grpStandard.Controls.Add(this.btnDbInit);
            this.grpStandard.Location = new System.Drawing.Point(131, 68);
            this.grpStandard.Margin = new System.Windows.Forms.Padding(2);
            this.grpStandard.Name = "grpStandard";
            this.grpStandard.Padding = new System.Windows.Forms.Padding(2);
            this.grpStandard.Size = new System.Drawing.Size(348, 104);
            this.grpStandard.TabIndex = 9;
            this.grpStandard.TabStop = false;
            this.grpStandard.Text = "数据库";
            // 
            // dbInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 397);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtDbInit);
            this.Controls.Add(this.btnNewDb);
            this.Controls.Add(this.grpStandard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "dbInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据解析入库";
            this.Load += new System.EventHandler(this.dbInit_Load);
            this.grpStandard.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.GroupBox grpStandard;
    }
}