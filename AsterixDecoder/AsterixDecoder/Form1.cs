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
            AsterixFile asterixfile= new AsterixFile("201002-lebl-080001_adsb.ast");
            List<CAT21> lista=asterixfile.getListCAT21();
            CAT21 cat21 = lista[546];

            byte[] fieldEspec = cat21.GetFieldEspec();
            int systemIC = cat21.GetSystemIdentificationCode();
            int systemAC = cat21.GetSystemAreaCode();
            int trackNumber = cat21.GetTrackNumber();
            double latitude = cat21.GetLatitudeWGS84();
            double longitude = cat21.GetLongitudeWGS84();
            double latitudehigh = cat21.GetLatitudeWGS84High();
            double longitudehigh = cat21.GetLongitudeWGS84High();
            double GeometricHeight = cat21.GetGeometricHeight();
            double roll = cat21.GetRollAngle();
            double flightlevel = cat21.GetFlightLevel();
            Console.WriteLine("Longitud Field Espec: " + fieldEspec.Length);
            Console.WriteLine("SAC: " + systemAC);
            Console.WriteLine("SIC: " + systemIC);
            Console.WriteLine("Track Number: " + trackNumber);
            Console.WriteLine("Latitude: " + latitude);
            Console.WriteLine("Longitude: " + longitude);
            Console.WriteLine("Latitude High resolution: " + latitudehigh);
            Console.WriteLine("Longitude High resolution: " + longitudehigh);
            Console.WriteLine("GeometricHeight: " + GeometricHeight);
            Console.WriteLine("Roll Angle: " + roll);
            Console.WriteLine("Flight Level: " + flightlevel);


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


        }
    }
}
