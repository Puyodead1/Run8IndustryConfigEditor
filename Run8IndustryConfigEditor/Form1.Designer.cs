namespace Run8IndustryConfigEditor
{
    partial class Form1
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
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.panelLoadFile = new System.Windows.Forms.Panel();
            this.labelLoadingFile = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelData = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelLoadFile.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.AutoSize = true;
            this.btnLoadFile.Location = new System.Drawing.Point(322, 200);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(141, 25);
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
            this.panelLoadFile.Size = new System.Drawing.Size(800, 450);
            this.panelLoadFile.TabIndex = 1;
            // 
            // labelLoadingFile
            // 
            this.labelLoadingFile.AutoSize = true;
            this.labelLoadingFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLoadingFile.Location = new System.Drawing.Point(277, 228);
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
            // panelData
            // 
            this.panelData.Controls.Add(this.dataGridView1);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(800, 450);
            this.panelData.TabIndex = 1;
            this.panelData.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelLoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelLoadFile.ResumeLayout(false);
            this.panelLoadFile.PerformLayout();
            this.panelData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnLoadFile;
        private Panel panelLoadFile;
        private OpenFileDialog openFileDialog;
        private Label labelLoadingFile;
        private Panel panelData;
        private DataGridView dataGridView1;
    }
}
