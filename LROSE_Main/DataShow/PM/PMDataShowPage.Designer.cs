namespace PMDataOperation.DataShow.PM
{
    partial class PMDataShowPage
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
            this.PMDataGridView = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.PMDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PMDataGridView
            // 
            this.PMDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PMDataGridView.Location = new System.Drawing.Point(374, 12);
            this.PMDataGridView.Name = "PMDataGridView";
            this.PMDataGridView.RowTemplate.Height = 23;
            this.PMDataGridView.Size = new System.Drawing.Size(544, 459);
            this.PMDataGridView.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(7, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(338, 460);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // PMDataShowPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 479);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.PMDataGridView);
            this.Name = "PMDataShowPage";
            this.Text = "PM数据展示";
            this.Load += new System.EventHandler(this.PMDataShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PMDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PMDataGridView;
        private System.Windows.Forms.ListBox listBox1;
    }
}