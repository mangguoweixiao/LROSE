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
            this.initMRBtn = new System.Windows.Forms.Button();
            this.initPMBtn = new System.Windows.Forms.Button();
            this.PMIntoBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpStandard.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewDb
            // 
            this.btnNewDb.Location = new System.Drawing.Point(109, 19);
            this.btnNewDb.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewDb.Name = "btnNewDb";
            this.btnNewDb.Size = new System.Drawing.Size(152, 34);
            this.btnNewDb.TabIndex = 0;
            this.btnNewDb.Text = "新建数据库";
            this.btnNewDb.UseVisualStyleBackColor = true;
            this.btnNewDb.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDbInit
            // 
            this.btnDbInit.Location = new System.Drawing.Point(18, 119);
            this.btnDbInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnDbInit.Name = "btnDbInit";
            this.btnDbInit.Size = new System.Drawing.Size(90, 30);
            this.btnDbInit.TabIndex = 1;
            this.btnDbInit.Text = "初始化全部";
            this.btnDbInit.UseVisualStyleBackColor = true;
            this.btnDbInit.Click += new System.EventHandler(this.btnDbInit_Click);
            // 
            // btnDbDelete
            // 
            this.btnDbDelete.Location = new System.Drawing.Point(18, 67);
            this.btnDbDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDbDelete.Name = "btnDbDelete";
            this.btnDbDelete.Size = new System.Drawing.Size(122, 34);
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
            this.cmbDb.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Size = new System.Drawing.Size(152, 20);
            this.cmbDb.TabIndex = 3;
            this.cmbDb.Text = "请选择相应数据库";
            this.cmbDb.SelectedIndexChanged += new System.EventHandler(this.cmbDb_SelectedIndexChanged);
            this.cmbDb.TextChanged += new System.EventHandler(this.cmbDb_TextChanged);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // txtDbInit
            // 
            this.txtDbInit.Location = new System.Drawing.Point(131, 275);
            this.txtDbInit.Margin = new System.Windows.Forms.Padding(2);
            this.txtDbInit.Multiline = true;
            this.txtDbInit.Name = "txtDbInit";
            this.txtDbInit.Size = new System.Drawing.Size(349, 112);
            this.txtDbInit.TabIndex = 4;
            this.txtDbInit.TextChanged += new System.EventHandler(this.txtDbInit_TextChanged);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(41, 20);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(111, 39);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "MR数据入库";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(179, 67);
            this.btnSure.Margin = new System.Windows.Forms.Padding(2);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(138, 34);
            this.btnSure.TabIndex = 8;
            this.btnSure.Text = "确认数据库";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // grpStandard
            // 
            this.grpStandard.Controls.Add(this.initMRBtn);
            this.grpStandard.Controls.Add(this.initPMBtn);
            this.grpStandard.Controls.Add(this.btnSure);
            this.grpStandard.Controls.Add(this.btnDbDelete);
            this.grpStandard.Controls.Add(this.cmbDb);
            this.grpStandard.Controls.Add(this.btnDbInit);
            this.grpStandard.Location = new System.Drawing.Point(131, 82);
            this.grpStandard.Margin = new System.Windows.Forms.Padding(2);
            this.grpStandard.Name = "grpStandard";
            this.grpStandard.Padding = new System.Windows.Forms.Padding(2);
            this.grpStandard.Size = new System.Drawing.Size(348, 172);
            this.grpStandard.TabIndex = 9;
            this.grpStandard.TabStop = false;
            this.grpStandard.Text = "选择数据库";
            // 
            // initMRBtn
            // 
            this.initMRBtn.Location = new System.Drawing.Point(224, 119);
            this.initMRBtn.Name = "initMRBtn";
            this.initMRBtn.Size = new System.Drawing.Size(93, 30);
            this.initMRBtn.TabIndex = 10;
            this.initMRBtn.Text = "初始化MR";
            this.initMRBtn.UseVisualStyleBackColor = true;
            this.initMRBtn.Click += new System.EventHandler(this.initMRBtn_Click);
            // 
            // initPMBtn
            // 
            this.initPMBtn.Location = new System.Drawing.Point(122, 119);
            this.initPMBtn.Name = "initPMBtn";
            this.initPMBtn.Size = new System.Drawing.Size(86, 30);
            this.initPMBtn.TabIndex = 9;
            this.initPMBtn.Text = "初始化PM";
            this.initPMBtn.UseVisualStyleBackColor = true;
            this.initPMBtn.Click += new System.EventHandler(this.initPMBtn_Click);
            // 
            // PMIntoBtn
            // 
            this.PMIntoBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PMIntoBtn.Location = new System.Drawing.Point(200, 20);
            this.PMIntoBtn.Name = "PMIntoBtn";
            this.PMIntoBtn.Size = new System.Drawing.Size(108, 39);
            this.PMIntoBtn.TabIndex = 10;
            this.PMIntoBtn.Text = "PM数据入库";
            this.PMIntoBtn.UseVisualStyleBackColor = true;
            this.PMIntoBtn.Click += new System.EventHandler(this.PMIntoBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewDb);
            this.groupBox1.Location = new System.Drawing.Point(131, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 68);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新建数据库";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.PMIntoBtn);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(131, 403);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 75);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "下一步";
            // 
            // dbInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 544);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDbInit);
            this.Controls.Add(this.grpStandard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "dbInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据解析入库";
            this.Load += new System.EventHandler(this.dbInit_Load);
            this.grpStandard.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Button PMIntoBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button initMRBtn;
        private System.Windows.Forms.Button initPMBtn;
    }
}