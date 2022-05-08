using System.Data;

namespace Run8IndustryConfigEditor
{
    public partial class MainForm : Form
    {
        public string? filePath;
        public IndustryConfiguration? industryConfiguration;
        public MainForm()
        {
            InitializeComponent();
            SetupGrids();
        }

        /*
         * Sets up common grid view styling
         */
        private void SetupGrids()
        {
            panelData.SplitterDistance = this.Width / 2;

            // industry grid
            industryGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            industryGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            industryGrid.ColumnHeadersDefaultCellStyle.Font =
            new Font(industryGrid.Font, FontStyle.Bold);

            industryGrid.Name = "industries";
            industryGrid.Location = new Point(8, 8);
            industryGrid.Size = new Size(panelData.Panel1.Width, panelData.Panel1.Height);
            industryGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            industryGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            industryGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            industryGrid.GridColor = Color.Black;
            industryGrid.RowHeadersVisible = false;
            industryGrid.AutoGenerateColumns = false;
            industryGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            industryGrid.MultiSelect = true;
            industryGrid.Dock = DockStyle.Fill;


            // editing grid
            editingPanel.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            editingPanel.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            editingPanel.ColumnHeadersDefaultCellStyle.Font =
            new Font(editingPanel.Font, FontStyle.Bold);

            editingPanel.Name = "editingGrid";
            editingPanel.Location = new Point(8, 8);
            editingPanel.Size = new Size(panelData.Panel2.Width, panelData.Panel2.Height);
            editingPanel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            editingPanel.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            editingPanel.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            editingPanel.GridColor = Color.Black;
            editingPanel.RowHeadersVisible = false;
            editingPanel.AutoGenerateColumns = false;
            editingPanel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            editingPanel.MultiSelect = true;
            editingPanel.Dock = DockStyle.Fill;
        }

        /*
         * Creates the industry grid columns
         */
        private void SetupIndustryGrid()
        {
            DataGridViewButtonColumn trackEditBtnCol = new DataGridViewButtonColumn();
            trackEditBtnCol.HeaderText = "Tracks";
            trackEditBtnCol.Name = "editTracks";
            trackEditBtnCol.Text = "Edit Tracks";
            trackEditBtnCol.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn carsEditBtnCol = new DataGridViewButtonColumn();
            carsEditBtnCol.HeaderText = "Cars";
            carsEditBtnCol.Name = "editCars";
            carsEditBtnCol.Text = "Edit Cars";
            carsEditBtnCol.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn deleteRowBtnCol = new DataGridViewButtonColumn();
            deleteRowBtnCol.HeaderText = "Delete";
            deleteRowBtnCol.Name = "deleteRow";
            deleteRowBtnCol.Text = "Delete";
            deleteRowBtnCol.UseColumnTextForButtonValue = true;

            industryGrid.Columns.Add("tag", "Industry Tag");
            industryGrid.Columns.Add("name", "Industry Name");
            industryGrid.Columns.Add("localFreightCode", "Local Freight Code");
            industryGrid.Columns.Add("trackCount", "Track Count");
            industryGrid.Columns.Add("carCount", "Car Count");

            industryGrid.Columns.Add(trackEditBtnCol);
            industryGrid.Columns.Add(carsEditBtnCol);
            industryGrid.Columns.Add(deleteRowBtnCol);
        }

        private void ResetEditingPanel()
        {
            // clear any existing data
            editingPanel.Columns.Clear();
            editingPanel.Rows.Clear();
            editingPanel.ClearSelection();
        }

        /*
         * Creates the editing panel columns for car editing and populates the data
         */
        private void SetupCarEditor(Industry industry)
        {
            // clear any existing data
            ResetEditingPanel();

            editingPanel.Name = "cars";
            editingPanel.Columns.Add("carType", "Type");
            editingPanel.Columns.Add("time", "Time");
            editingPanel.Columns.Add("capacity", "Capacity");
            editingPanel.Columns.Add("destCount", "Destination Count");
            editingPanel.Columns.Add("dests", "Destinations");

            for (int i = 0; i < industry.CarCount; i++)
            {
                Car car = industry.Cars[i];

                string[] s =
                {
                    car.CarType.ToString(),
                    car.Time.ToString(),
                    car.Capacity.ToString(),
                    car.DestinationCount.ToString(),
                    String.Join(", ", car.Destinations)
                };
                editingPanel.Rows.Add(s);
            }

            SizeDataGrid(editingPanel);
            editingPanelGroupBox.Text = $"Cars for {industry.Name}";
            editingPanelGroupBox.Visible = true;
        }

        /*
         * Sets up the editing panel columns for track editing and populates the data
         */
        private void SetupTrackEditor(Industry industry)
        {
            // clear any existing data
            ResetEditingPanel();

            editingPanel.Name = "tracks";
            editingPanel.Columns.Add("prefix", "Prefix");
            editingPanel.Columns.Add("section", "Section");
            editingPanel.Columns.Add("node", "Node");

            for (int i = 0; i < industry.TrackCount; i++)
            {
                Track track = industry.Tracks[i];

                string[] s =
                {
                    track.Prefix.ToString(),
                    track.Section.ToString(),
                    track.Node.ToString(),
                };
                editingPanel.Rows.Add(s);
            }

            SizeDataGrid(editingPanel);
            editingPanelGroupBox.Text = $"Tracks for {industry.Name}";
            editingPanelGroupBox.Visible = true;
        }

        private void ClearGrids()
        {
            industryGrid.Columns.Clear();
            industryGrid.Rows.Clear();
            editingPanel.Columns.Clear();
            editingPanel.Rows.Clear();
            editingPanelGroupBox.Visible = false;
        }

        /*
         * Makes datagrid use the full width of its container
         */
        private void SizeDataGrid(DataGridView dataGrid)
        {
            int columnCount = dataGrid.Columns.Count;
            int lastColumnIndex = columnCount - 1;
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                if (column.Index == columnCount - lastColumnIndex)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnLoadFile.Enabled = false;
            progressBar1.Visible = true;
            label1.Visible = true;
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                btnLoadFile.Enabled = true;
                progressBar1.Visible = false;
                label1.Visible = false;
            }
        }

        private void LoadFile()
        {
            if (filePath == null) return;
            industryConfiguration = new IndustryConfiguration(filePath, progressBar1, label1);
            BeginInvoke((ThreadStart)(() =>
            {

                ClearGrids();
                SetupIndustryGrid();

                panelData.Visible = true;
                panelLoadFile.Visible = false;

                foreach (Industry industry in industryConfiguration.Industries)
                {

                    string[] row = { industry.Tag, industry.Name, industry.LocalFreightCode, industry.TrackCount.ToString(), industry.CarCount.ToString() };
                    industryGrid.Rows.Add(row);
                }

                SizeDataGrid(industryGrid);

                btnLoadFile.Enabled = true;
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                label1.Text = "Loading...";
                label1.Visible = false;
            }));
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                btnLoadFile.Enabled = false;
                progressBar1.Visible = true;
                label1.Visible = true;
                filePath = openFileDialog.FileName;
                var thread = new Thread(LoadFile) { IsBackground = true };
                thread.Start();
            } catch(Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(industryConfiguration == null)
            {
                System.Diagnostics.Debug.WriteLine("IndustryConfiguration was null somehow..");
                return;
            }
            int editCarIndex = industryGrid.Columns["editCars"].Index;
            int editTracksIndex = industryGrid.Columns["editTracks"].Index;
            int deleteIndex = industryGrid.Columns["deleteRow"].Index;

            // ignore cells that arent button cells
            if (e.RowIndex < 0 || (e.ColumnIndex != editCarIndex && e.ColumnIndex != editTracksIndex && e.ColumnIndex != deleteIndex)) return;

            Industry industry = industryConfiguration.Industries[e.RowIndex];

            if(e.ColumnIndex == editTracksIndex)
            {
                SetupTrackEditor(industry);
            } else if (e.ColumnIndex == editCarIndex)
            {
                SetupCarEditor(industry);
            } else if (e.ColumnIndex == deleteIndex)
            {
                DialogResult res = MessageBox.Show("you won't be able to undo it without loosing your changes", "are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(res == DialogResult.Yes)
                {
                    // remove from grid
                    industryGrid.Rows.RemoveAt(e.RowIndex);
                    // remove from industry config
                    industryConfiguration.Industries.RemoveAt(e.ColumnIndex);
                }
            } 
            else
            {
                MessageBox.Show($"invalid operation x_x");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGrids();
            panelLoadFile.Visible = true;
            panelData.Visible = false;
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                btnLoadFile.Enabled = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGrids();
            panelLoadFile.Visible = true;
            panelData.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }

        private void panelLoadFile_VisibleChanged(object sender, EventArgs e)
        {
            if(!panelLoadFile.Visible)
            {
                // show the toolstrip when not on main screen
                toolStrip1.Visible = true;
            } else
            {
                // hide toolstrip when showing main screen
                toolStrip1.Visible = false;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            filePath = files[0];
            btnLoadFile.Enabled = false;
            progressBar1.Visible = true;
            label1.Visible = true;

            try
            {
                var thread = new Thread(LoadFile) { IsBackground = true };
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(industryConfiguration != null)
                {
                    // save the file
                    try
                    {
                        var thread = new Thread(delegate ()
                        {
                            industryConfiguration.SaveFile(saveFileDialog1.FileName);
                        })
                        { IsBackground = true};
                        thread.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Oops", "There is nothing to save...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
