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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.panelLoadFile = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.industryGrid = new System.Windows.Forms.DataGridView();
            this.editingPanel = new System.Windows.Forms.DataGridView();
            this.panelData = new System.Windows.Forms.SplitContainer();
            this.industryListGroupBox = new System.Windows.Forms.GroupBox();
            this.editingPanelGroupBox = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelLoadFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.industryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editingPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelData)).BeginInit();
            this.panelData.Panel1.SuspendLayout();
            this.panelData.Panel2.SuspendLayout();
            this.panelData.SuspendLayout();
            this.industryListGroupBox.SuspendLayout();
            this.editingPanelGroupBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.panelLoadFile.Controls.Add(this.label1);
            this.panelLoadFile.Controls.Add(this.progressBar1);
            this.panelLoadFile.Controls.Add(this.btnLoadFile);
            this.panelLoadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoadFile.Location = new System.Drawing.Point(0, 25);
            this.panelLoadFile.Name = "panelLoadFile";
            this.panelLoadFile.Size = new System.Drawing.Size(1064, 536);
            this.panelLoadFile.TabIndex = 1;
            this.panelLoadFile.VisibleChanged += new System.EventHandler(this.panelLoadFile_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(406, 325);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(236, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
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
            this.editingPanel.Location = new System.Drawing.Point(3, 19);
            this.editingPanel.Name = "editingPanel";
            this.editingPanel.RowTemplate.Height = 25;
            this.editingPanel.Size = new System.Drawing.Size(495, 514);
            this.editingPanel.TabIndex = 1;
            // 
            // panelData
            // 
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.IsSplitterFixed = true;
            this.panelData.Location = new System.Drawing.Point(0, 25);
            this.panelData.Name = "panelData";
            // 
            // panelData.Panel1
            // 
            this.panelData.Panel1.Controls.Add(this.industryListGroupBox);
            // 
            // panelData.Panel2
            // 
            this.panelData.Panel2.Controls.Add(this.editingPanelGroupBox);
            this.panelData.Size = new System.Drawing.Size(1064, 536);
            this.panelData.SplitterDistance = 559;
            this.panelData.TabIndex = 2;
            this.panelData.Visible = false;
            // 
            // industryListGroupBox
            // 
            this.industryListGroupBox.Controls.Add(this.industryGrid);
            this.industryListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.industryListGroupBox.Location = new System.Drawing.Point(0, 0);
            this.industryListGroupBox.Name = "industryListGroupBox";
            this.industryListGroupBox.Size = new System.Drawing.Size(559, 536);
            this.industryListGroupBox.TabIndex = 1;
            this.industryListGroupBox.TabStop = false;
            this.industryListGroupBox.Text = "Industries";
            // 
            // editingPanelGroupBox
            // 
            this.editingPanelGroupBox.Controls.Add(this.editingPanel);
            this.editingPanelGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editingPanelGroupBox.Location = new System.Drawing.Point(0, 0);
            this.editingPanelGroupBox.Name = "editingPanelGroupBox";
            this.editingPanelGroupBox.Size = new System.Drawing.Size(501, 536);
            this.editingPanelGroupBox.TabIndex = 2;
            this.editingPanelGroupBox.TabStop = false;
            this.editingPanelGroupBox.Text = "EditingPanel";
            this.editingPanelGroupBox.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "ind";
            this.saveFileDialog1.Filter = "IND|*.ind";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 561);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelLoadFile);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Run8 Industry Configuration Editor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.panelLoadFile.ResumeLayout(false);
            this.panelLoadFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.industryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editingPanel)).EndInit();
            this.panelData.Panel1.ResumeLayout(false);
            this.panelData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelData)).EndInit();
            this.panelData.ResumeLayout(false);
            this.industryListGroupBox.ResumeLayout(false);
            this.editingPanelGroupBox.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLoadFile;
        private Panel panelLoadFile;
        private OpenFileDialog openFileDialog;
        private DataGridView industryGrid;
        private DataGridView editingPanel;
        private SplitContainer panelData;
        private GroupBox editingPanelGroupBox;
        private GroupBox industryListGroupBox;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ProgressBar progressBar1;
        private Label label1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
    }
}
