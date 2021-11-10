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



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsterixFile asterixfile = new AsterixFile("201002-lebl-080001_adsb.ast");
            List<CAT21> lista = asterixfile.getListCAT21();
            //CAT21 cat21 = lista[546];

            //byte[] fieldEspec = cat21.GetFieldEspec();
            //int systemIC = cat21.GetSystemIdentificationCode();
 
            //double latitude = cat21.GetLatitudeWGS84();
            //double longitude = cat21.GetLongitudeWGS84();
            //double latitudehigh = cat21.GetLatitudeWGS84High();
            //double longitudehigh = cat21.GetLongitudeWGS84High();
            //double GeometricHeight = cat21.GetGeometricHeight();
            //double roll = cat21.GetRollAngle();
            //double flightlevel = cat21.GetFlightLevel();
            //Console.WriteLine("Longitud Field Espec: " + fieldEspec.Length);
            //Console.WriteLine("SAC: " + systemAC);
            //Console.WriteLine("SIC: " + systemIC);
            //Console.WriteLine("Track Number: " + trackNumber);
            //Console.WriteLine("Latitude: " + latitude);
            //Console.WriteLine("Longitude: " + longitude);
            //Console.WriteLine("Latitude High resolution: " + latitudehigh);
            //Console.WriteLine("Longitude High resolution: " + longitudehigh);
            //Console.WriteLine("GeometricHeight: " + GeometricHeight);
            //Console.WriteLine("Roll Angle: " + roll);
            //Console.WriteLine("Flight Level: " + flightlevel);


            //Print en hexadecimal
            //byte[] arraystringcopy =cat21.GetArray();
            //for (int j = 0; j < arraystringcopy.Length; j++) {
            //Console.WriteLine("{0:X}", arraystringcopy[j]);
            //Console.WriteLine( j +":::"+ arraystringcopy[j]) ;
            //}

            //Print en decimal
            //for (int j = 0; j < lista.Count; j++)
            //{
            //    //Console.WriteLine("Vuelo"+(j+1) +" "+ lista[j].GetLatitudeWGS84High());
            //    //Console.WriteLine("Vuelo" + (j + 1) + " " + lista[j].GetLongitudeWGS84High());

            //}
            dataGridView1.ColumnCount = 14;
            dataGridView1.Columns[0].Name = "Number";
            dataGridView1.Columns[1].Name = "Category";
            dataGridView1.Columns[2].Name = "SAC";
            dataGridView1.Columns[3].Name = "SIC";
            dataGridView1.Columns[4].Name = "Target Identification";
            dataGridView1.Columns[5].Name = "Track Number";
            dataGridView1.Columns[6].Name = "Target Report Descriptor";//Mirar como expandir
            dataGridView1.Columns[7].Name = "Service Identification";
            dataGridView1.Columns[8].Name = "Time of Report Transmission";
            dataGridView1.Columns[9].Name = "Position in WGS-84 Coordinates";
            dataGridView1.Columns[10].Name = "Position in WGS-84 Coordinates High Resolution";
            dataGridView1.Columns[11].Name = "Air Speed";
            dataGridView1.Columns[12].Name = "True Airspeed";
            dataGridView1.Columns[13].Name = "Target Adress";

            for (int i=0;i<10;i++)
            {
                CAT21 cat21 = lista[i];
                string category=Convert.ToString(cat21.GetCategory());
                string sac = Convert.ToString(cat21.GetSystemAreaCode());
                string sic = Convert.ToString(cat21.GetSystemIdentificationCode());
                string targetID = cat21.GetTargetIdentification();
                string trackNumber = Convert.ToString(cat21.GetTrackNumber());
                string serviceID = Convert.ToString(cat21.GetServiceIdentification());
                string timeofreport = Convert.ToString(cat21.GetTimeOfReportTransmission());
                string position= Convert.ToString(cat21.GetLatitudeWGS84())+" "+ Convert.ToString(cat21.GetLongitudeWGS84());
                string positionHigh = Convert.ToString(cat21.GetLatitudeWGS84High()) + " " + Convert.ToString(cat21.GetLongitudeWGS84High());
                string airspeed = Convert.ToString(cat21.GetAirspeed());
                string trueairspeed = Convert.ToString(cat21.GetTrueAirspeed());
                string targetaddress = Convert.ToString(cat21.GetTargetAddress());
                string[] row = new string[] { Convert.ToString(i), category, sac, sic, targetID, trackNumber," ", serviceID, timeofreport, position, positionHigh, airspeed, trueairspeed, targetaddress};
                dataGridView1.Rows.Add(row);
     
            }


        }
    }
}
