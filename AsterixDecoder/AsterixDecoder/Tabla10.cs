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
            LoadData GridForm = new LoadData();
            int length = lista.Count;
            progressBar1CAT10.Visible = true;
            Stopwatch watch = new Stopwatch();
            //Adaptamos columnas a texto
            progressBar1CAT10.Visible = true;
            progressBar1CAT10.Minimum = 0;
            // Sets the progress bar's maximum value to a number representing  
            // all operations complete -- in this case, all five files read.  
            progressBar1CAT10.Maximum = length;
            // Sets the Step property to amount to increase with each iteration.  
            // In this case, it will increase by one with every file read.  
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

            //dataGridView1.Visible = true;
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

            string s;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    s = row.Cells[12].Value.ToString();
                    if  (s.Equals( textBox1.Text) || textBox1.Text == "")
                    {
                        row.Visible = true;

                    }
                    else { row.Visible = false; }
                        
                }
                catch (Exception)
                {

                }


            }
            


            
        }
        



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 5 && dataGridView1.CurrentCell.Value != "No Data")
            {
                if (dataGridView1.CurrentCell.Value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = lista[dataGridView1.CurrentCell.RowIndex].GetTargetDescriptor();
                //dataGridView1.CurrentRow.Height = 200;
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 13 && dataGridView1.CurrentCell.Value != "No Data")
            {
                if (dataGridView1.CurrentCell.Value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = lista[dataGridView1.CurrentCell.RowIndex].GetTrackStatus();

            }
        }

    }
}

