namespace Run8IndustryConfigEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.panelLoadFile = new System.Windows.Forms.Panel();
            this.labelLoadingFile = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.industryGrid = new System.Windows.Forms.DataGridView();
            this.editingPanel = new System.Windows.Forms.DataGridView();
            this.panelData = new System.Windows.Forms.SplitContainer();
            this.panelLoadFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.industryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editingPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelData)).BeginInit();
            this.panelData.Panel1.SuspendLayout();
            this.panelData.Panel2.SuspendLayout();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.AutoSize = true;
            this.btnLoadFile.Location = new System.Drawing.Point(406, 273);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(236, 39);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load Configuration File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelLoadFile
            // 
            this.panelLoadFile.Controls.Add(this.labelLoadingFile);
            this.panelLoadFile.Controls.Add(this.btnLoadFile);
            this.panelLoadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoadFile.Location = new System.Drawing.Point(0, 0);
            this.panelLoadFile.Name = "panelLoadFile";
            this.panelLoadFile.Size = new System.Drawing.Size(1064, 561);
            this.panelLoadFile.TabIndex = 1;
            // 
            // labelLoadingFile
            // 
            this.labelLoadingFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLoadingFile.AutoSize = true;
            this.labelLoadingFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLoadingFile.Location = new System.Drawing.Point(406, 249);
            this.labelLoadingFile.Name = "labelLoadingFile";
            this.labelLoadingFile.Size = new System.Drawing.Size(236, 21);
            this.labelLoadingFile.TabIndex = 1;
            this.labelLoadingFile.Text = "Loading Industry Configuration...";
            this.labelLoadingFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLoadingFile.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ind";
            this.openFileDialog.Filter = "IND files|*.ind";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // industryGrid
            // 
            this.industryGrid.AllowUserToResizeColumns = false;
            this.industryGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.industryGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.industryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.industryGrid.Location = new System.Drawing.Point(0, 0);
            this.industryGrid.Name = "industryGrid";
            this.industryGrid.RowTemplate.Height = 25;
            this.industryGrid.Size = new System.Drawing.Size(560, 561);
            this.industryGrid.TabIndex = 0;
            this.industryGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // editingPanel
            // 
            this.editingPanel.AllowUserToResizeColumns = false;
            this.editingPanel.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editingPanel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.editingPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editingPanel.Location = new System.Drawing.Point(0, 0);
            this.editingPanel.Name = "editingPanel";
            this.editingPanel.RowTemplate.Height = 25;
            this.editingPanel.Size = new System.Drawing.Size(500, 561);
            this.editingPanel.TabIndex = 1;
            // 
            // panelData
            // 
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.IsSplitterFixed = true;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            // 
            // panelData.Panel1
            // 
            this.panelData.Panel1.Controls.Add(this.industryGrid);
            // 
            // panelData.Panel2
            // 
            this.panelData.Panel2.Controls.Add(this.editingPanel);
            this.panelData.Size = new System.Drawing.Size(1064, 561);
            this.panelData.SplitterDistance = 560;
            this.panelData.TabIndex = 2;
            this.panelData.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 561);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelLoadFile);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelLoadFile.ResumeLayout(false);
            this.panelLoadFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.industryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editingPanel)).EndInit();
            this.panelData.Panel1.ResumeLayout(false);
            this.panelData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelData)).EndInit();
            this.panelData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnLoadFile;
        private Panel panelLoadFile;
        private OpenFileDialog openFileDialog;
        private Label labelLoadingFile;
        private DataGridView industryGrid;
        private DataGridView editingPanel;
        private SplitContainer panelData;
    }
}
