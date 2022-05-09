using System.Data;

namespace Run8IndustryConfigEditor
{
    public partial class MainForm : Form
    {
        public string? filePath;
        public IndustryConfiguration? industryConfiguration;
        private int currentEditingType = -1;
        private Industry? currentEditingIndustry;

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

            DataGridViewTextBoxColumn industryTagCol = new DataGridViewTextBoxColumn();
            industryTagCol.HeaderText = "Industry Tag";
            industryTagCol.Name = "industryTag";
            industryTagCol.MaxInputLength = 4;

            DataGridViewTextBoxColumn industryNameCol = new DataGridViewTextBoxColumn();
            industryNameCol.HeaderText = "Industry Name";
            industryNameCol.Name = "industryName";
            industryNameCol.MaxInputLength = 255;

            DataGridViewTextBoxColumn localFreightCodeCol = new DataGridViewTextBoxColumn();
            localFreightCodeCol.HeaderText = "Local Freight Code";
            localFreightCodeCol.Name = "localFreightCode";
            localFreightCodeCol.ReadOnly = true;

            DataGridViewTextBoxColumn trackCountCol = new DataGridViewTextBoxColumn();
            trackCountCol.HeaderText = "Track Count";
            trackCountCol.Name = "trackCount";
            trackCountCol.ReadOnly = true;

            DataGridViewTextBoxColumn carCountCol = new DataGridViewTextBoxColumn();
            carCountCol.HeaderText = "Car Count";
            carCountCol.Name = "carCount";
            carCountCol.ReadOnly = true;

            industryGrid.Columns.Add(industryTagCol);
            industryGrid.Columns.Add(industryNameCol);
            industryGrid.Columns.Add(localFreightCodeCol);
            industryGrid.Columns.Add(trackCountCol);
            industryGrid.Columns.Add(carCountCol);

            industryGrid.Columns.Add(trackEditBtnCol);
            industryGrid.Columns.Add(carsEditBtnCol);
        }

        // clears the editing panel and resets it
        private void ResetEditingPanel()
        {
            // clear any existing data
            editingPanel.Columns.Clear();
            editingPanel.Rows.Clear();
            editingPanel.ClearSelection();
            currentEditingType = -1;
            currentEditingIndustry = null;
            editingPanel.ReadOnly = false;
            editingPanelGroupBox.Visible = false;
        }

        /*
         * Creates the editing panel columns for car editing and populates the data
         */
        private void SetupCarEditor(Industry industry)
        {
            // clear any existing data
            ResetEditingPanel();
            currentEditingType = 0;
            currentEditingIndustry = industry;

            DataGridViewComboBoxColumn carTypeCol = new DataGridViewComboBoxColumn();
            carTypeCol.HeaderText = "Car Type";
            carTypeCol.Name = "carType";
            foreach(ECarType eCarType in Enum.GetValues(typeof(ECarType)))
            {
                if (eCarType == ECarType.All || eCarType == ECarType.Loco || eCarType == ECarType.Shoving_Platform) continue;
                carTypeCol.Items.Add(eCarType.ToString());
            }

            DataGridViewTextBoxColumn destinationCountCol = new DataGridViewTextBoxColumn();
            destinationCountCol.HeaderText = "Destination Count";
            destinationCountCol.Name = "destCount";
            destinationCountCol.ReadOnly = true;

            editingPanel.Name = "cars";
           
            editingPanel.Columns.Add(carTypeCol);
            editingPanel.Columns.Add("time", "Time");
            editingPanel.Columns.Add("capacity", "Capacity");
            editingPanel.Columns.Add(destinationCountCol);
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
            currentEditingType = 1;
            currentEditingIndustry = industry;

            editingPanel.Name = "tracks";
            editingPanel.ReadOnly = true;
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

        // Clears all the grids data and resets them
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

        // Event to handle Load File button being clicked
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

        // Threaded method for loading a file
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

        // Event to handle when file is opened in dialog
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

        // event to handle button cell clicks
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(industryConfiguration == null)
            {
                System.Diagnostics.Debug.WriteLine("IndustryConfiguration was null somehow..");
                return;
            }
            int editCarIndex = industryGrid.Columns["editCars"].Index;
            int editTracksIndex = industryGrid.Columns["editTracks"].Index;

            // ignore cells that arent button cells
            if (e.RowIndex < 0 || (e.ColumnIndex != editCarIndex && e.ColumnIndex != editTracksIndex)) return;

            Industry industry = industryConfiguration.Industries[e.RowIndex];

            if(e.ColumnIndex == editTracksIndex)
            {
                SetupTrackEditor(industry);
            } else if (e.ColumnIndex == editCarIndex)
            {
                SetupCarEditor(industry);
            }
            else
            {
                MessageBox.Show($"invalid operation x_x");
            }
        }

        // event to handle then open button being clicked in the toolstrip
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

        // event to handle then close button being clicked in the toolstrip
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGrids();
            panelLoadFile.Visible = true;
            panelData.Visible = false;
        }

        // event to handle then about button being clicked in the toolstrip
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }

        // event to handle hiding and showing the toolstrip so it only shows on the editing screen
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

        // event to handle drag and drop event
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

        // event to handle drag and drop file entering
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        // event to handle then save button being clicked in the toolstrip
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

        private void industryGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (industryConfiguration == null) return;

            DataGridViewCell cell = industryGrid[e.ColumnIndex, e.RowIndex];
            Industry industry = industryConfiguration.Industries[e.RowIndex];
            
            switch(cell.ColumnIndex)
            {
                case 0:
                    industry.Tag = (string)cell.Value;
                    break;
                case 1:
                    industry.Name = (string)cell.Value;
                    break;
            }
        }

        private void editingPanel_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (currentEditingIndustry == null || currentEditingType == -1) return;

            DataGridViewCell cell = editingPanel[e.ColumnIndex, e.RowIndex];

            if(currentEditingType == 0)
            {
                Car car = currentEditingIndustry.Cars[cell.RowIndex];
                // car editing
                switch(cell.ColumnIndex)
                {
                    case 0:
                        car.CarType = (ECarType)Enum.Parse(typeof(Car), (string)cell.Value);
                        break;
                    case 1:
                        car.Time = int.Parse((string)cell.Value);
                        break;
                    case 2:
                        car.Capacity = int.Parse((string)cell.Value);
                        break;
                    case 4:
                        car.Destinations = ((string)cell.Value).Split(",").ToList();
                        // remove any spaces and capitalize
                        car.Destinations.ForEach(v =>
                        {
                            v.Trim();
                            v.ToUpper();
                        });
                        // update destination count in data
                        car.DestinationCount = car.Destinations.Count;
                        // update destination count in grid
                        editingPanel[3, cell.RowIndex].Value = car.DestinationCount;
                        break;
                }
            } else if (currentEditingType == 1)
            {
                // track editing
                // TODO
            }
        }

        private void industryGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (industryConfiguration == null)
            {
                System.Diagnostics.Debug.WriteLine("IndustryConfiguration was null somehow..");
                return;
            }

            // remove from industry config
            industryConfiguration.Industries.RemoveAt(e.Row.Index);
        }

        private void editingPanel_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (industryConfiguration == null)
            {
                System.Diagnostics.Debug.WriteLine("industryconfiguration was null");
                return;
            }

            if (currentEditingIndustry == null)
            {
                System.Diagnostics.Debug.WriteLine("no current editing industry, wtf");
                return;
            }

            if(e.Row == null)
            {
                System.Diagnostics.Debug.WriteLine("row was null");
                return;
            }

            int industryIndex = industryConfiguration.Industries.IndexOf(currentEditingIndustry);

            switch (currentEditingType)
            {
                case 0:
                    // remove car from industry
                    currentEditingIndustry.Cars.RemoveAt(e.Row.Index);
                    currentEditingIndustry.CarCount = currentEditingIndustry.Cars.Count();
                    industryGrid.Rows[industryIndex].Cells[4].Value = currentEditingIndustry.CarCount.ToString();
                    break;
                case 1:
                    // remove track from industry
                    currentEditingIndustry.Tracks.RemoveAt(e.Row.Index);
                    currentEditingIndustry.TrackCount = currentEditingIndustry.Tracks.Count();
                    industryGrid.Rows[industryIndex].Cells[3].Value = currentEditingIndustry.TrackCount.ToString();
                    break;
            }
        }

        private void industryGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (industryConfiguration == null)
            {
                System.Diagnostics.Debug.WriteLine("IndustryConfiguration was null somehow..");
                return;
            }

            if (e.Row == null)
            {
                System.Diagnostics.Debug.WriteLine("row was null");
                return;
            }

            if(industryConfiguration.Industries[e.Row.Index] == currentEditingIndustry)
            {
                // the industry being edited was deleted, clear the editing grid
                ResetEditingPanel();
            }

            // remove from industry config
            industryConfiguration.Industries.RemoveAt(e.Row.Index);
        }
    }
}
