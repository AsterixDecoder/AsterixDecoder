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
        public Tabla10()
        {
            InitializeComponent();
        }
		AsterixFile asterixFile;
        List<CAT10> lista10;

        private void Tabla10_Load(object sender, EventArgs e)
        {
        }
        private void Tabla10_SizeChanged(object sender, EventArgs e)
        {
            //Size s = new Size(this.ClientSize.Width - 50, this.ClientSize.Height - 50);
            //dataGridView1.MaximumSize = s;

            //dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 5 && dataGridView1.CurrentCell.Value != "No Data")
            {
                if (dataGridView1.CurrentCell.Value!= "Click to Expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to Expand";
                }
                else
                dataGridView1.CurrentCell.Value = lista10[dataGridView1.CurrentCell.RowIndex].GetTargetDescriptor();
                //dataGridView1.CurrentRow.Height = 200;
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 13 && dataGridView1.CurrentCell.Value != "No Data")
            {
                if (dataGridView1.CurrentCell.Value != "Click to Expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to Expand";
                }
                else
                    dataGridView1.CurrentCell.Value = lista10[dataGridView1.CurrentCell.RowIndex].GetTrackStatus();

            }
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


            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                try { dataGridView1.Rows[i].Visible = false; } catch (Exception) { }
                    
            }
            string s;
            for (int i = 0; i < 28; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        s = row.Cells[i].Value.ToString();
                        if (System.Text.RegularExpressions.Regex.IsMatch(s, textBox1.Text) || textBox1.Text == "")
                        {
                            row.Visible = true;

                        }
                        
                    }
                    catch (Exception)
                    {

                    }


                }
            }


            
        }

        private void btnloadcat10_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            progressBar1CAT10.Visible = true;
            asterixFile = new AsterixFile("201002-lebl-080001_smr.ast");
            lista10 = asterixFile.getListCAT10();
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


            progressBar1CAT10.Minimum = 0;
            // Sets the progress bar's maximum value to a number representing  
            // all operations complete -- in this case, all five files read.  
            progressBar1CAT10.Maximum = 1000;
            // Sets the Step property to amount to increase with each iteration.  
            // In this case, it will increase by one with every file read.  
            progressBar1CAT10.Step = 1;


            watch.Start();
            for (int i = 0; i < 5000; i++)
            {



                string[] row = lista10[i].GetValues(28);
                row[0] = i.ToString();
                row[1] = "10";

                dataGridView1.Rows.Add(row);
                progressBar1CAT10.PerformStep();

            }
            watch.Stop();
            long milisec = watch.ElapsedMilliseconds / 1000;
            string tiempo = Convert.ToString(milisec);
            LoadingCAT10.Visible = true;
            LoadingCAT10.Text = "All flights loaded";
            progressBar1CAT10.Visible = false;

            Console.WriteLine("Codigo tarda " + tiempo + " segundos");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

