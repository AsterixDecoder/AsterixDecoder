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
        string filename;
        public Tabla10(List<CAT10> lista)
        {
            InitializeComponent();
            this.lista = lista;       
           
        }


        private void Tabla10_Load(object sender, EventArgs e)
        {
            LoadData GridForm = new LoadData();
            progressBar1.Visible = true;
            Stopwatch watch = new Stopwatch();
            //Adaptamos columnas a texto
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            // Sets the progress bar's maximum value to a number representing  
            // all operations complete -- in this case, all five files read.  
            progressBar1.Maximum = 5000;
            // Sets the Step property to amount to increase with each iteration.  
            // In this case, it will increase by one with every file read.  
            progressBar1.Step = 1;

            dataGridView1.ColumnCount = 28;
            dataGridView1.Columns[0].Name = "Number";
            dataGridView1.Columns[1].Name = "Category";
            dataGridView1.Columns[2].Name = "SAC";
            dataGridView1.Columns[3].Name = "SIC";
            dataGridView1.Columns[4].Name = "Message Type";
            dataGridView1.Columns[5].Name = "Target Report Descriptor";
            dataGridView1.Columns[6].Name = "Time of Day";
            dataGridView1.Columns[7].Name = "Position in WGS-84 Coordinates";
            dataGridView1.Columns[8].Name = "Position in Polar Coordinates";
            dataGridView1.Columns[9].Name = "Position in Cartesian Coordinates";
            dataGridView1.Columns[10].Name = "Calculated Track Velocity in Polar Coordinates";
            dataGridView1.Columns[11].Name = "Calculated Track Velocity in Cartesian Coordinates";
            dataGridView1.Columns[12].Name = "Track Number";
            dataGridView1.Columns[13].Name = "Track Status";
            dataGridView1.Columns[14].Name = "Mode 3/A Code";
            dataGridView1.Columns[15].Name = "Target Address";
            dataGridView1.Columns[16].Name = "Target Identification";
            dataGridView1.Columns[17].Name = "Mode S MB Data";
            dataGridView1.Columns[18].Name = "Vehible Fleet Identification";
            dataGridView1.Columns[19].Name = "Flight Level";
            dataGridView1.Columns[20].Name = "Measured Height";
            dataGridView1.Columns[21].Name = "Target Size and Orientation";
            dataGridView1.Columns[22].Name = "System Status";
            dataGridView1.Columns[23].Name = "Preprogrammed Message";
            dataGridView1.Columns[24].Name = "Standard Deviation of Position";
            dataGridView1.Columns[25].Name = "Presence";
            dataGridView1.Columns[26].Name = "Amplitude of Primary Plor";
            dataGridView1.Columns[27].Name = "Calculated Acceleration";

            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.Visible = true;
            textBox1.Visible = false;


            watch.Start();
            for (int i = 0; i < 5000; i++)
            {



                string[] row = lista[i].GetValues(28);
                row[0] = i.ToString();
                row[1] = "10";

                dataGridView1.Rows.Add(row);
                progressBar1.PerformStep();
            }
            watch.Stop();
            long milisec = watch.ElapsedMilliseconds / 1000;
            string tiempo = Convert.ToString(milisec);
            progressBar1.Visible = false;
            dataGridView1.Visible = true;
            textBox1.Visible = true;
            Console.WriteLine("Codigo tarda " + tiempo + " segundos");


        }

        private void Tabla10_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 5|| dataGridView1.CurrentCell.ColumnIndex == 13 && dataGridView1.CurrentCell.Value != "No Data")
            {
                dataGridView1.CurrentCell.Value = "Click to Expand";

            }
        }

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
                if (dataGridView1.CurrentCell.Value != "Click to Expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to Expand";
                }
                else
                    dataGridView1.CurrentCell.Value = lista[dataGridView1.CurrentCell.RowIndex].GetTargetDescriptor();
                //dataGridView1.CurrentRow.Height = 200;
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 13 && dataGridView1.CurrentCell.Value != "No Data")
            {
                if (dataGridView1.CurrentCell.Value != "Click to Expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to Expand";
                }
                else
                    dataGridView1.CurrentCell.Value = lista[dataGridView1.CurrentCell.RowIndex].GetTrackStatus();

            }
        }
    }
}
