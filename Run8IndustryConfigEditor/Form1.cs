using System.Data;

namespace Run8IndustryConfigEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnLoadFile.Enabled = false;
            if(openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                btnLoadFile.Enabled = true;
            }
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnLoadFile.Enabled = false;
            labelLoadingFile.Visible = true;
            IndustryConfiguration industryConfiguration = new IndustryConfiguration(openFileDialog.FileName);
            labelLoadingFile.Text = "Loading Complete";

            dataGridView1.ColumnCount = industryConfiguration.IndustryCount;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
            new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView1.Name = "Industries";
            dataGridView1.Location = new Point(8, 8);
            dataGridView1.Size = new Size(500, 250);
            dataGridView1.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].Name = "Industry Name";
            dataGridView1.Columns[1].Name = "Local Freight Code";
            dataGridView1.Columns[2].Name = "Industry Tag";
            dataGridView1.Columns[3].Name = "Track Count";
            dataGridView1.Columns[4].Name = "Car Count";

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.Dock = DockStyle.Fill;

            foreach(Industry industry in industryConfiguration.Industries)
            {
                string[] row = {industry.Name, industry.LocalFreightCode, industry.Tag, industry.TrackCount.ToString(), industry.CarCount.ToString() };
                dataGridView1.Rows.Add(row);
            }

            panelData.Visible = true;
            panelLoadFile.Visible = false;
        }
    }
}
