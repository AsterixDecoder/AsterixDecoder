using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace AsterixDecoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            AsterixFile asterixFile = new AsterixFile("201002-lebl-080001_smr.ast");
            List<CAT10> lista10 = asterixFile.getListCAT10();
            dataGridView1.ColumnCount = 45;
            dataGridView1.Columns[0].Name = "Number";
            dataGridView1.Columns[1].Name = "Category";
            dataGridView1.Columns[2].Name = "SAC";
            dataGridView1.Columns[3].Name = "SIC";
            dataGridView1.Columns[4].Name = "Message Type";
            dataGridView1.Columns[5].Name = "Target Report Descriptor";//Mirar como expandir
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





            for (int i = 0; i < 10; i++)
            {


                //string dataAges = cat21.GetDataAges();
                string[] row = lista10[i].GetValues(27);
                //new string[] { Convert.ToString(i), category, sac, sic, targetID, trackNumber, "Target Report Descriptor", serviceID, timeofreport, position, positionHigh, airspeed, trueairspeed, targetaddress, tappposition, tappvelocity, tmessageposition, tmessagepositionhigh, tmessagevel, tmessagevelhigh, geometricHeight + " ft", "NUCr or NACv: " + nucr, mopsversion, m3acode, rollangle, flightlevel + " FL", magneticheading, targetstatus, barometricrate + " ft/min", geometricrate, airborneVector, trackanglerate, emitterCategory, "WindSpeed: " + meteo[0] + "Wind Direction: " + meteo[1] + "Temperature: " + meteo[2] + "Turbulence" + meteo[3], selectedAltitude + " ft", finalselAltitude, trajectoryintent, servicemanagement, opstatus, surface, messageAmplitude, modeSMBData, acasResolution, receiverID, "Data Ages" };
                dataGridView1.Rows.Add(row);

            }
        }
    }
}
