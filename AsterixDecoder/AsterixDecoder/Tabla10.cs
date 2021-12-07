using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;


namespace AsterixDecoder
{
    public partial class Tabla10 : Form
    {
        AsterixFile asterixFile;
        Flight flight;
        List<Flight> listaflights = new List<Flight>();
        Coordinates coordinates;
        List<CAT10> lista;
        DataTable dataTable = new DataTable();
        string filename;
        public Tabla10(List<CAT10> lista)
        {
            InitializeComponent();
            this.lista = lista;       
           
        }


        private void Tabla10_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            LoadData GridForm = new LoadData();
            int length = lista.Count;
            Stopwatch watch = new Stopwatch();
            //Adaptamos columnas a texto
            progressBar1CAT10.Visible = true;
            progressBar1CAT10.Maximum = length;
            progressBar1CAT10.Minimum = 0;
            progressBar1CAT10.Step = 1;

            dataTable.Columns.Add("Number");
            dataTable.Columns.Add("Category");
            dataTable.Columns.Add("SAC");
            dataTable.Columns.Add("SIC");
            dataTable.Columns.Add("Message Type");
            dataTable.Columns.Add("Target Report Descriptor");
            dataTable.Columns.Add("Time of Day");
            dataTable.Columns.Add("Position in WGS-84 Coordinates");
            dataTable.Columns.Add("Position in Polar Coordinates");
            dataTable.Columns.Add("Position in Cartesian Coordinates");
            dataTable.Columns.Add("Calculated Track Velocity in Polar Coordinates");
            dataTable.Columns.Add("Calculated Track Velocity in Cartesian Coordinates");
            dataTable.Columns.Add("Track Number");
            dataTable.Columns.Add("Track Status");
            dataTable.Columns.Add("Mode 3/A Code");
            dataTable.Columns.Add("Target Address");
            dataTable.Columns.Add("Target Identification");
            dataTable.Columns.Add("Mode S MB Data");
            dataTable.Columns.Add("Vehicle Fleet Identification");
            dataTable.Columns.Add("Flight Level");
            dataTable.Columns.Add("Measured Height");
            dataTable.Columns.Add("Target Size and Orientation");
            dataTable.Columns.Add("System Status");
            dataTable.Columns.Add("Preprogrammed Message");
            dataTable.Columns.Add("Standard Deviation of Position");
            dataTable.Columns.Add("Presence");
            dataTable.Columns.Add("Amplitude of Primary Plor");
            dataTable.Columns.Add("Calculated Acceleration");

            textBox1.Visible = false;


            watch.Start();
            for (int i = 0; i < length; i++)
            {

                string[] row = lista[i].GetValues(28);
                row[0] = i.ToString();
                row[1] = "10";

                dataTable.Rows.Add(row);
                progressBar1CAT10.PerformStep();
            }
            DataView dataView = new DataView(dataTable);
            dataGridView1.DataSource = dataView;
            progressBar1CAT10.Visible = false;
            textBox1.Visible = true;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Visible = true;
            watch.Stop();
            long milisec = watch.ElapsedMilliseconds / 1000;
            string tiempo = Convert.ToString(milisec);
            Console.WriteLine("Codigo tarda " + tiempo + " segundos");


        }
        //private void Tabla10_SizeChanged(object sender, EventArgs e)
        //{
        //    //dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        //}


        //private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridView1.CurrentCell.ColumnIndex == 5|| dataGridView1.CurrentCell.ColumnIndex == 13 && dataGridView1.CurrentCell.Value != "No Data")
        //    {
        //        dataGridView1.CurrentCell.Value = "Click to expand";

        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable2 = new DataTable();
            string id;
            int i = 0;
            dataTable2.Columns.Add("Number");
            dataTable2.Columns.Add("Category");
            dataTable2.Columns.Add("SAC");
            dataTable2.Columns.Add("SIC");
            dataTable2.Columns.Add("Message Type");
            dataTable2.Columns.Add("Target Report Descriptor");
            dataTable2.Columns.Add("Time of Day");
            dataTable2.Columns.Add("Position in WGS-84 Coordinates");
            dataTable2.Columns.Add("Position in Polar Coordinates");
            dataTable2.Columns.Add("Position in Cartesian Coordinates");
            dataTable2.Columns.Add("Calculated Track Velocity in Polar Coordinates");
            dataTable2.Columns.Add("Calculated Track Velocity in Cartesian Coordinates");
            dataTable2.Columns.Add("Track Number");
            dataTable2.Columns.Add("Track Status");
            dataTable2.Columns.Add("Mode 3/A Code");
            dataTable2.Columns.Add("Target Address");
            dataTable2.Columns.Add("Target Identification");
            dataTable2.Columns.Add("Mode S MB Data");
            dataTable2.Columns.Add("Vehicle Fleet Identification");
            dataTable2.Columns.Add("Flight Level");
            dataTable2.Columns.Add("Measured Height");
            dataTable2.Columns.Add("Target Size and Orientation");
            dataTable2.Columns.Add("System Status");
            dataTable2.Columns.Add("Preprogrammed Message");
            dataTable2.Columns.Add("Standard Deviation of Position");
            dataTable2.Columns.Add("Presence");
            dataTable2.Columns.Add("Amplitude of Primary Plor");
            dataTable2.Columns.Add("Calculated Acceleration");

            while (i < dataGridView1.RowCount - 1)
            {
                string[] values = lista[i].GetValues(28);
                id = values[12];
                //id = dataGridView1.Rows[i].Cells[12].Value.ToString();
               
                if (id.Equals(textBox1.Text) || textBox1.Text == "")
                {
                    values[0] = i.ToString();
                    values[1] = "10";

                    dataTable2.Rows.Add(values);
                }
                i++;
            }


            DataView dataView2 = new DataView(dataTable2);
            dataGridView2.DataSource = dataView2;
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = "";
            string caption = "";
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            string value = Convert.ToString(dataGridView1.CurrentCell.Value);

            if (column== 5 && value != "No Data")
            {
                //if (dataGridView1.CurrentCell.Value != "Click to expand")
                //{
                //    dataGridView1.CurrentCell.Value = "Click to expand";
                //}
                //else
                //    dataGridView1.CurrentCell.Value = lista[row].GetTargetDescriptor();
                message= lista[row].GetTargetDescriptor();
                caption = "Target Descriptor";

            }
            if (column == 13 && value != "No Data")
            {
                //if (value != "Click to expand")
                //{
                //    dataGridView1.CurrentCell.Value = "Click to expand";
                //}
                //else
                //    dataGridView1.CurrentCell.Value = lista[row].GetTrackStatus();
                message = lista[row].GetTrackStatus();
                caption = "Track Status";

            }
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = "";
            string caption = "";
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            string value = Convert.ToString(dataGridView1.CurrentCell.Value);
            int index = (int)dataGridView1.Rows[row].Cells[0].Value;


            if (column == 5 && value != "No Data")
            {
                //if (dataGridView1.CurrentCell.Value != "Click to expand")
                //{
                //    dataGridView1.CurrentCell.Value = "Click to expand";
                //}
                //else
                //    dataGridView1.CurrentCell.Value = lista[row].GetTargetDescriptor();
                message = lista[index].GetTargetDescriptor();
                caption = "Target Descriptor";

            }
            if (column == 13 && value != "No Data")
            {
                //if (value != "Click to expand")
                //{
                //    dataGridView1.CurrentCell.Value = "Click to expand";
                //}
                //else
                //    dataGridView1.CurrentCell.Value = lista[row].GetTrackStatus();
                message = lista[index].GetTrackStatus();
                caption = "Track Status";

            }
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }

        private void ViewAll_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
        }
    }
}

