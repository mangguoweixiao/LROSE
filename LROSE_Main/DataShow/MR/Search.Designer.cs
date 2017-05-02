namespace LROSE_Main.DataShow.MR
{
    partial class Search
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
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txb_column = new System.Windows.Forms.TextBox();
            this.lstCol = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstType = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_search = new System.Windows.Forms.DataGridView();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_output = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(347, 372);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 31;
            this.btn_search.Text = "执行检索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(624, 77);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 29;
            this.btn_delete.Text = "移出";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(520, 77);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 28;
            this.btn_add.Text = "添加/更新";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txb_column
            // 
            this.txb_column.Location = new System.Drawing.Point(559, 27);
            this.txb_column.Name = "txb_column";
            this.txb_column.Size = new System.Drawing.Size(148, 21);
            this.txb_column.TabIndex = 27;
            // 
            // lstCol
            // 
            this.lstCol.FormattingEnabled = true;
            this.lstCol.ItemHeight = 12;
            this.lstCol.Location = new System.Drawing.Point(84, 27);
            this.lstCol.Name = "lstCol";
            this.lstCol.Size = new System.Drawing.Size(151, 76);
            this.lstCol.TabIndex = 26;
            this.lstCol.SelectedValueChanged += new System.EventHandler(this.lstCol_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "内容：";
            // 
            // lstType
            // 
            this.lstType.FormattingEnabled = true;
            this.lstType.ItemHeight = 12;
            this.lstType.Location = new System.Drawing.Point(326, 27);
            this.lstType.Name = "lstType";
            this.lstType.Size = new System.Drawing.Size(151, 76);
            this.lstType.TabIndex = 24;
            this.lstType.SelectedIndexChanged += new System.EventHandler(this.lstType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "检索条件：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "字段：";
            // 
            // dgv_search
            // 
            this.dgv_search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_search.Location = new System.Drawing.Point(84, 121);
            this.dgv_search.Name = "dgv_search";
            this.dgv_search.RowTemplate.Height = 23;
            this.dgv_search.Size = new System.Drawing.Size(623, 94);
            this.dgv_search.TabIndex = 32;
            this.dgv_search.SelectionChanged += new System.EventHandler(this.dgv_search_SelectionChanged);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvResult.Location = new System.Drawing.Point(84, 221);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(623, 145);
            this.dgvResult.TabIndex = 33;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_output});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // tsmi_output
            // 
            this.tsmi_output.Name = "tsmi_output";
            this.tsmi_output.Size = new System.Drawing.Size(152, 22);
            this.tsmi_output.Text = "导出结果";
            this.tsmi_output.Click += new System.EventHandler(this.tsmi_output_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 442);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.dgv_search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txb_column);
            this.Controls.Add(this.lstCol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txb_column;
        private System.Windows.Forms.ListBox lstCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_search;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_output;
    }
}