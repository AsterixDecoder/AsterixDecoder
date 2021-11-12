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
            dataGridView1.ColumnCount = 45;
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
            dataGridView1.Columns[14].Name = "Time of Applicability Position";
            dataGridView1.Columns[15].Name = "Time of Applicability Velocity";
            dataGridView1.Columns[16].Name = "Time of Message Reception Position";
            dataGridView1.Columns[17].Name = "Time of Message Reception Position High Res";
            dataGridView1.Columns[18].Name = "Time of Message Reception Velocity";
            dataGridView1.Columns[19].Name = "Time of Message Reception Velocity High Res";
            dataGridView1.Columns[20].Name = "Geometric Height";
            dataGridView1.Columns[21].Name = "Quality Indicators";
            dataGridView1.Columns[22].Name = "MOPS Version";
            dataGridView1.Columns[23].Name = "Mode 3A Code";
            dataGridView1.Columns[24].Name = "Roll Angle";
            dataGridView1.Columns[25].Name = "Flight Level";
            dataGridView1.Columns[26].Name = "Magentic Heading";
            dataGridView1.Columns[27].Name = "Target Status";
            dataGridView1.Columns[28].Name = "Barometric Vertical Rate";
            dataGridView1.Columns[29].Name = "Geometric Vertical Rate";
            dataGridView1.Columns[30].Name = "Airborne Ground Vector";
            dataGridView1.Columns[31].Name = "Track Angle Rate";
            dataGridView1.Columns[32].Name = "Emitter Category";
            dataGridView1.Columns[33].Name = "Met Information";
            dataGridView1.Columns[34].Name = "Selected Altitude";
            dataGridView1.Columns[35].Name = "Final State Selected Altitude";
            dataGridView1.Columns[36].Name = "Trajectory Intent";
            dataGridView1.Columns[37].Name = "Service Management";
            dataGridView1.Columns[38].Name = "Aircraft Operational Status";
            dataGridView1.Columns[39].Name = "Surface Capabilities and Characteristics";
            dataGridView1.Columns[40].Name = "Message Amplitude";
            dataGridView1.Columns[41].Name = "Mode S MB Data";
            dataGridView1.Columns[42].Name = "ACAS Resolution";
            dataGridView1.Columns[43].Name = "Receiver ID";
            dataGridView1.Columns[44].Name = "Data Ages";




            for (int i=0;i<10;i++)
            {
                CAT21 cat21 = lista[i];
                string category=Convert.ToString(cat21.GetCategory());
                string sac = Convert.ToString(cat21.GetSystemAreaCode());
                string sic = Convert.ToString(cat21.GetSystemIdentificationCode());
                string targetID = cat21.GetTargetIdentification();
                string trackNumber = Convert.ToString(cat21.GetTrackNumber());
                string serviceID = Convert.ToString(cat21.GetServiceIdentification());
                //decimal timeofreportnopadded = Convert.ToDecimal(cat21.GetTimeOfReportTransmission());
               
                string timeofreport0 = Convert.ToString(cat21.GetTimeOfReportTransmission());
                string timeofreport1 = timeofreport0.Remove( timeofreport0.Length-1);
                string timeofreport2 = timeofreport1.Remove(timeofreport1.Length - 1);
                string timeofreport = timeofreport2.Remove(timeofreport2.Length - 1);

                string position= Convert.ToString(cat21.GetLatitudeWGS84())+"/n" + Convert.ToString(cat21.GetLongitudeWGS84());
                string positionHigh = Convert.ToString(cat21.GetLatitudeWGS84High()) + "/n" + Convert.ToString(cat21.GetLongitudeWGS84High());
                string airspeed = Convert.ToString(cat21.GetAirspeed());
                string trueairspeed = Convert.ToString(cat21.GetTrueAirspeed());
                string targetaddress = Convert.ToString(cat21.GetTargetAddress());
                //TimeSpans
                string tappposition = Convert.ToString(cat21.GetTimeOfApplicabilityPosition());
                string tappvelocity = Convert.ToString(cat21.GetTimeOfApplicabilityVelocity());

                string tmessageposition;
                string tmessageposition0 = Convert.ToString(cat21.GetTimeOfMessagePosition());//
                if (tmessageposition0.Length >= 10)
                {
                    string tmessageposition1 = tmessageposition0.Remove(tmessageposition0.Length - 1);
                    string tmessageposition2 = tmessageposition1.Remove(tmessageposition1.Length - 1);
                    string tmessageposition3 = tmessageposition2.Remove(tmessageposition2.Length - 1);
                    tmessageposition = tmessageposition3.Remove(tmessageposition3.Length - 1);
                }
                else {
                    tmessageposition = tmessageposition0;//
                }
                
                string tmessagepositionhigh = Convert.ToString(cat21.GetTimeOfMessagePositionHigh());

                string tmessagevel;
                string tmessagevel0 = Convert.ToString(cat21.GetTimeOfMessageVelocity());//
                if (tmessagevel0.Length >= 10)
                {
                    string tmessagevel1 = tmessagevel0.Remove(tmessagevel0.Length - 1);
                    string tmessagevel2 = tmessagevel1.Remove(tmessagevel1.Length - 1);
                    string tmessagevel3 = tmessagevel2.Remove(tmessagevel2.Length - 1);
                    tmessagevel = tmessagevel3.Remove(tmessagevel3.Length - 1);
                }
                else {
                    tmessagevel = Convert.ToString(cat21.GetTimeOfMessageVelocity());//
                }
                string tmessagevelhigh = Convert.ToString(cat21.GetTimeOfMessageVelocityHigh());
                string geometricHeight = Convert.ToString(cat21.GetGeometricHeight());
                string nucr = Convert.ToString(cat21.GetNucr());
                string mopsversion = cat21.GetMOPSVersion();
                string m3acode = cat21.GetMode3ACode();
                string rollangle = Convert.ToString(cat21.GetRollAngle());
                string flightlevel = Convert.ToString(cat21.GetFlightLevel());
                string magneticheading = Convert.ToString(cat21.GetMagneticHeading());
                string targetstatus = cat21.GetTargetStatus();
                string barometricrate = Convert.ToString(cat21.GetBarometricVerticalRate());
                string geometricrate = Convert.ToString(cat21.GetGeometricVerticalRate());
                string airborneVector = cat21.GetAirborneVector();
                string trackanglerate = Convert.ToString(cat21.GetTrackAngleRate());
                string emitterCategory = cat21.GetEmitterCategory();
                string[] meteo = cat21.GetMetInformation();
                string selectedAltitude = Convert.ToString(cat21.GetSelectedAltitude());
                string finalselAltitude = Convert.ToString(cat21.GetFinalStateSelectedAltitude());
                string trajectoryintent = cat21.GetTrajectoryIntent();
                string servicemanagement = Convert.ToString(cat21.GetServiceManagement());
                string[] opstatusData = cat21.GetOperationalStatus();
                string opstatus = opstatusData[0] + Environment.NewLine + opstatusData[1] + Environment.NewLine + opstatusData[2] + Environment.NewLine + opstatusData[3] + Environment.NewLine + opstatusData[4] + Environment.NewLine + opstatusData[5] + Environment.NewLine + opstatusData[6];
                string[] surfaceData = cat21.GetSurfaceCapabilities();
                string surface = surfaceData[0] + Environment.NewLine + surfaceData[1] + Environment.NewLine + surfaceData[2] + Environment.NewLine + surfaceData[3] + Environment.NewLine + surfaceData[4] + Environment.NewLine + surfaceData[5] + Environment.NewLine + surfaceData[6];
                string messageAmplitude = Convert.ToString(cat21.GetMessageAmplitude());
                string modeSMBData = cat21.GetModeSMBData();
                string acasResolution = cat21.GetAcasResolution();
                string receiverID = Convert.ToString(cat21.GetReceiverID());
                //string dataAges = cat21.GetDataAges();
                string[] row = new string[] { Convert.ToString(i), category, sac, sic, targetID, trackNumber,"Target Report Descriptor", serviceID, timeofreport, position, positionHigh, airspeed, trueairspeed, targetaddress, tappposition,tappvelocity,tmessageposition,tmessagepositionhigh,tmessagevel,tmessagevelhigh,geometricHeight +" ft", "NUCr or NACv: "+ nucr,mopsversion,m3acode,rollangle,flightlevel+ " FL", magneticheading, targetstatus,barometricrate + " ft/min",geometricrate, airborneVector, trackanglerate, emitterCategory, "WindSpeed: "+ meteo[0]+ "Wind Direction: " + meteo[1] +"Temperature: "+meteo[2] +"Turbulence"+ meteo[3], selectedAltitude +" ft", finalselAltitude, trajectoryintent,servicemanagement,opstatus,surface,messageAmplitude,modeSMBData,acasResolution,receiverID,"Data Ages"};
                dataGridView1.Rows.Add(row);
     
            }


        }
    }
}
