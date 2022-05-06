using System.Data;

namespace Run8IndustryConfigEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupGrids();
        }

        private void SetupGrids()
        {
            panelData.SplitterDistance = this.Width / 2;

            // industry grid
            industryGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            industryGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            industryGrid.ColumnHeadersDefaultCellStyle.Font =
            new Font(industryGrid.Font, FontStyle.Bold);

            industryGrid.Name = "Industries";
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

            editingPanel.Name = "EditingGrid";
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

        private void SetupCarEditor(Industry industry)
        {
            // clear any existing data
            editingPanel.Columns.Clear();
            editingPanel.Rows.Clear();
            editingPanel.ClearSelection();

            editingPanel.Name = "Cars";
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

            int columnCount = editingPanel.Columns.Count;

            //If we want the last column to fill the remaining space
            int lastColumnIndex = columnCount - 1;

            //Loop through each column and set the DataGridViewAutoSizeColumnMode
            //In this case, if we will set the size of all columns automatically, but have
            //the last column fill any extra space available.
            foreach (DataGridViewColumn column in editingPanel.Columns)
            {
                if (column.Index == columnCount - lastColumnIndex) //Last column will fill extra space
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else //Any other column will be sized based on the max content size
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnLoadFile.Enabled = false;
            if(openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                btnLoadFile.Enabled = true;
            }
        }

        private void LoadFile()
        {
            DataContext.IndustryConfiguration = new IndustryConfiguration(openFileDialog.FileName);
            BeginInvoke((ThreadStart)(() =>
            {
                labelLoadingFile.Text = "Loading Complete";

                SetupIndustryGrid();

                panelData.Visible = true;
                panelLoadFile.Visible = false;

                foreach (Industry industry in DataContext.IndustryConfiguration.Industries)
                {

                    string[] row = { industry.Tag, industry.Name, industry.LocalFreightCode, industry.TrackCount.ToString(), industry.CarCount.ToString() };
                    industryGrid.Rows.Add(row);
                }

                int columnCount = industryGrid.Columns.Count;

                //If we want the last column to fill the remaining space
                int lastColumnIndex = columnCount - 1;

                //Loop through each column and set the DataGridViewAutoSizeColumnMode
                //In this case, if we will set the size of all columns automatically, but have
                //the last column fill any extra space available.
                foreach (DataGridViewColumn column in industryGrid.Columns)
                {
                    if (column.Index == columnCount - lastColumnIndex) //Last column will fill extra space
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else //Any other column will be sized based on the max content size
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }));
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnLoadFile.Enabled = false;
            labelLoadingFile.Visible = true;

            try
            {
                var thread = new Thread(LoadFile) { IsBackground = true };
                thread.Start();
            } catch(Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int editCarIndex = industryGrid.Columns["editCars"].Index;
            int editTracksIndex = industryGrid.Columns["editTracks"].Index;
            int deleteIndex = industryGrid.Columns["deleteRow"].Index;

            // ignore cells that arent button cells
            if (e.RowIndex < 0 || (e.ColumnIndex != editCarIndex && e.ColumnIndex != editTracksIndex && e.ColumnIndex != deleteIndex)) return;

            Industry industry = DataContext.IndustryConfiguration.Industries[e.RowIndex];

            if(e.ColumnIndex == editTracksIndex)
            {
                TrackEditorForm editorForm = new TrackEditorForm(industry);
                editorForm.ShowDialog();
            } else if (e.ColumnIndex == editCarIndex)
            {
                //CarEditorForm editorForm = new CarEditorForm(industry);
                //editorForm.ShowDialog();
                SetupCarEditor(industry);
            } else if (e.ColumnIndex == deleteIndex)
            {
                DialogResult res = MessageBox.Show("you won't be able to undo it without loosing your changes", "are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(res == DialogResult.Yes)
                {
                    industryGrid.Rows.RemoveAt(e.RowIndex);
                }
            } 
            else
            {
                MessageBox.Show($"invalid operation x_x");
            }
        }
    }
}
