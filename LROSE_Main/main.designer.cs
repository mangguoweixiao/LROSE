﻿namespace LROSE_Main
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmDbInit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDataToDb = new System.Windows.Forms.ToolStripMenuItem();
            this.mRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnalysis1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnalysis2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mRToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDbInit,
            this.tsmDataToDb,
            this.tsmQuery,
            this.tsmAnalysis});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1030, 26);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // tsmDbInit
            // 
            this.tsmDbInit.Name = "tsmDbInit";
            this.tsmDbInit.Size = new System.Drawing.Size(110, 22);
            this.tsmDbInit.Text = "数据库管理";
            this.tsmDbInit.Click += new System.EventHandler(this.tsmDbInit_Click);
            // 
            // tsmDataToDb
            // 
            this.tsmDataToDb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mRToolStripMenuItem,
            this.pMToolStripMenuItem});
            this.tsmDataToDb.Name = "tsmDataToDb";
            this.tsmDataToDb.Size = new System.Drawing.Size(92, 22);
            this.tsmDataToDb.Text = "数据入库";
            this.tsmDataToDb.Click += new System.EventHandler(this.tsmDataToDb_Click);
            // 
            // mRToolStripMenuItem
            // 
            this.mRToolStripMenuItem.Name = "mRToolStripMenuItem";
            this.mRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mRToolStripMenuItem.Text = "MR";
            this.mRToolStripMenuItem.Click += new System.EventHandler(this.mRToolStripMenuItem_Click);
            // 
            // pMToolStripMenuItem
            // 
            this.pMToolStripMenuItem.Name = "pMToolStripMenuItem";
            this.pMToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pMToolStripMenuItem.Text = "PM";
            this.pMToolStripMenuItem.Click += new System.EventHandler(this.pMToolStripMenuItem_Click);
            // 
            // tsmQuery
            // 
            this.tsmQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mRToolStripMenuItem1,
            this.pMToolStripMenuItem1});
            this.tsmQuery.Name = "tsmQuery";
            this.tsmQuery.Size = new System.Drawing.Size(56, 22);
            this.tsmQuery.Text = "查询";
            this.tsmQuery.Click += new System.EventHandler(this.tsmQuery_Click);
            // 
            // tsmAnalysis
            // 
            this.tsmAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAnalysis1,
            this.tsmAnalysis2});
            this.tsmAnalysis.Name = "tsmAnalysis";
            this.tsmAnalysis.Size = new System.Drawing.Size(56, 22);
            this.tsmAnalysis.Text = "分析";
            this.tsmAnalysis.Click += new System.EventHandler(this.tsmAnalysis_Click);
            // 
            // tsmAnalysis1
            // 
            this.tsmAnalysis1.Name = "tsmAnalysis1";
            this.tsmAnalysis1.Size = new System.Drawing.Size(152, 22);
            this.tsmAnalysis1.Text = "一维分析";
            this.tsmAnalysis1.Click += new System.EventHandler(this.tsmAnalysis1_Click);
            // 
            // tsmAnalysis2
            // 
            this.tsmAnalysis2.Name = "tsmAnalysis2";
            this.tsmAnalysis2.Size = new System.Drawing.Size(152, 22);
            this.tsmAnalysis2.Text = "二维分析";
            this.tsmAnalysis2.Click += new System.EventHandler(this.tsmAnalysis2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(105, 32);
            // 
            // dbToolStripMenuItem
            // 
            this.dbToolStripMenuItem.Name = "dbToolStripMenuItem";
            this.dbToolStripMenuItem.Size = new System.Drawing.Size(104, 28);
            this.dbToolStripMenuItem.Text = "db";
            // 
            // mRToolStripMenuItem1
            // 
            this.mRToolStripMenuItem1.Name = "mRToolStripMenuItem1";
            this.mRToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.mRToolStripMenuItem1.Text = "MR";
            this.mRToolStripMenuItem1.Click += new System.EventHandler(this.mRToolStripMenuItem1_Click);
            // 
            // pMToolStripMenuItem1
            // 
            this.pMToolStripMenuItem1.Name = "pMToolStripMenuItem1";
            this.pMToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.pMToolStripMenuItem1.Text = "PM";
            this.pMToolStripMenuItem1.Click += new System.EventHandler(this.pMToolStripMenuItem1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 656);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "爱立信LROSE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem dbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDbInit;
        private System.Windows.Forms.ToolStripMenuItem tsmDataToDb;
        private System.Windows.Forms.ToolStripMenuItem mRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmQuery;
        private System.Windows.Forms.ToolStripMenuItem tsmAnalysis;
        private System.Windows.Forms.ToolStripMenuItem tsmAnalysis1;
        private System.Windows.Forms.ToolStripMenuItem tsmAnalysis2;
        private System.Windows.Forms.ToolStripMenuItem mRToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pMToolStripMenuItem1;
    }
}
