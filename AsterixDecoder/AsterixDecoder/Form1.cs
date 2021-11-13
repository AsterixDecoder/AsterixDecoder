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

        private void button1_Click(object sender, EventArgs e)
        {
            AsterixFile asterixfile = new AsterixFile("201002-lebl-080001_adsb.ast");
            List<CAT21> lista = asterixfile.getListCAT21();

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
            dataGridView1.Columns[17].Name = "Time of Message Reception Position High Res";//Lo quitaremos porque no sale en ningun vuelo y ya esta lo mismo pero en baja resolucion
            dataGridView1.Columns[18].Name = "Time of Message Reception Velocity";
            dataGridView1.Columns[19].Name = "Time of Message Reception Velocity High Res";//Lo quitaremos porque no sale en ningun vuelo y ya esta lo mismo pero en baja resolucion
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

            //Adaptamos columnas a texto
            
            dataGridView1.Columns[9].AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[22].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[30].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[32].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;




            for (int i=0;i<10;i++)
            {
                CAT21 cat21 = lista[i];
                string category=Convert.ToString(cat21.GetCategory());
                string sac = Convert.ToString(cat21.GetSystemAreaCode());
                string sic = Convert.ToString(cat21.GetSystemIdentificationCode());
                string targetID = cat21.GetTargetIdentification();
                string trackNumber = Convert.ToString(cat21.GetTrackNumber());
                string serviceID = Convert.ToString(cat21.GetServiceIdentification());
                string[] targetReportDescriptor = cat21.GetTargetReportDescriptor();
                string targetreport = MultipleString(targetReportDescriptor);
               
                string timeofreport = Convert.ToString(cat21.GetTimeOfReportTransmission());
                timeofreport = StringTime(timeofreport);


                double latitude = cat21.GetLatitudeWGS84();
                double longitude = cat21.GetLongitudeWGS84();
                string position = StringPosition(latitude, longitude,4);
                latitude = cat21.GetLatitudeWGS84High();
                longitude = cat21.GetLongitudeWGS84High();
                string positionHigh = StringPosition(latitude, longitude,7);
                string airspeed = Convert.ToString(cat21.GetAirspeed());
                airspeed = StringUnits(airspeed, "Mach");
                string trueairspeed = Convert.ToString(cat21.GetTrueAirspeed());
                trueairspeed = StringUnits(trueairspeed,"knot");
                int target = cat21.GetTargetAddress();
                string targetaddress = target.ToString("X");
                //TimeSpans
                string tappposition = Convert.ToString(cat21.GetTimeOfApplicabilityPosition());
                tappposition = StringTime(tappposition);

                string tappvelocity = Convert.ToString(cat21.GetTimeOfApplicabilityVelocity());
                tappvelocity = StringTime(tappvelocity);

                string tmessageposition = Convert.ToString(cat21.GetTimeOfMessagePosition());
                tmessageposition = StringTime(tmessageposition);
                string tmessagepositionhigh = Convert.ToString(cat21.GetTimeOfMessagePositionHigh());

                string tmessagevel = Convert.ToString(cat21.GetTimeOfMessageVelocity());
                tmessagevel = StringTime(tmessagevel);
                string tmessagevelhigh = Convert.ToString(cat21.GetTimeOfMessageVelocityHigh());

                string geometricHeight = Convert.ToString(cat21.GetGeometricHeight());
                geometricHeight = StringUnits(geometricHeight, "ft");

                int[] qualityIndicatorsInfo = cat21.GetQualityIndicators();
                string[] qualityIndicatorsName = new string[] { "NUCr or NACv", "NUCp or NIC", "Navigation Integrity Category for Barometric Altitude", "Surveillance or Source Integrity Level", "Navigation Accuracy Category for Position", "SIL-Supplement", "Horizontal Position System Design Assurance Level", "Geometric Altitude Accuracy", "Position Integrity Category" };
                string[] qualityIndicators=new string[qualityIndicatorsName.Length];
                string[] qualityUnits = new string[] { "", "", "", "", "", "", "", "", "" };
                for (int k=0; k < qualityIndicatorsInfo.Length; k++)
                {
                    
                    qualityIndicators[k] = Convert.ToString(qualityIndicatorsInfo[k]);
                    if (qualityIndicators[k]=="-1")
                    {
                        qualityIndicators[k] = "N/A";
                    }
                }
                if (qualityIndicators[5] == "0")
                {
                    qualityIndicators[5] = "Measured per flight hour";
                }
                if (qualityIndicators[5] == "1")
                {
                    qualityIndicators[5] = "Measured per sample";
                }
                string quality = MultipleDouble(qualityIndicators, qualityIndicatorsName,qualityUnits);
                string mopsversion = cat21.GetMOPSVersion();
                string m3acode = cat21.GetMode3ACode();
                string rollangle = Convert.ToString(cat21.GetRollAngle());
                rollangle = StringUnits(rollangle, "°");
                string flightlevel = Convert.ToString(cat21.GetFlightLevel());
                flightlevel = StringUnits(flightlevel, "FL");

                string magneticheading = Convert.ToString(cat21.GetMagneticHeading());
                magneticheading = StringUnits(magneticheading, "°");
                string[] targetstatusInfo = cat21.GetTargetStatus();
                targetstatusInfo[2] = "Priority Status: " + targetstatusInfo[2];
                targetstatusInfo[3] = "Surveillance Status: " + targetstatusInfo[3];
                string targetstatus = MultipleString(targetstatusInfo);


                string barometricrate = Convert.ToString(cat21.GetBarometricVerticalRate());
                barometricrate = StringUnits(barometricrate, "ft/min");
                string geometricrate = Convert.ToString(cat21.GetGeometricVerticalRate());
                geometricrate = StringUnits(geometricrate, "ft/min");

                string[] airborneVectorInfo = cat21.GetAirborneVector();
                string airborneVector;
                if (airborneVectorInfo[0] == "NaN")
                {
                    airborneVector = "Not Available";
                }
                else
                {
                    airborneVector = "GS: " + airborneVectorInfo[0] + "knts, T.A: " + airborneVectorInfo[1].Remove(6) + "°";
                }
                string trackanglerate = Convert.ToString(cat21.GetTrackAngleRate());
                trackanglerate = StringUnits(trackanglerate, "°/s");
                string emitterCategory = cat21.GetEmitterCategory();
                string[] meteoInfo = cat21.GetMetInformation();
                string[] meteoName= new string[] { "Wind Speed","Wind Direction","Temperature","Turbulence"};
                string[] meteoUnits = new string[] { "knot", "°", "°C", "" };
                string meteo = MultipleDouble(meteoInfo,meteoName,meteoUnits);
                string selectedAltitude = Convert.ToString(cat21.GetSelectedAltitude());
                selectedAltitude = StringUnits(selectedAltitude, "ft");
                string finalselAltitude = Convert.ToString(cat21.GetFinalStateSelectedAltitude());
                finalselAltitude = StringUnits(finalselAltitude, "ft");
                string trajectoryintent = cat21.GetTrajectoryIntent();
                string servicemanagement = Convert.ToString(cat21.GetServiceManagement());
                servicemanagement = StringUnits(servicemanagement, "sec");
                string[] opstatusData = cat21.GetOperationalStatus();
                string opstatus = MultipleString(opstatusData); 
                string[] surfaceData = cat21.GetSurfaceCapabilities();
                string surface = MultipleString(surfaceData); 
                string messageAmplitude = Convert.ToString(cat21.GetMessageAmplitude());
                messageAmplitude = StringUnits(messageAmplitude, "dBm");
                string modeSMBData = cat21.GetModeSMBData();
                string acasResolution = cat21.GetAcasResolution();
                string receiverID = Convert.ToString(cat21.GetReceiverID());
                string[] dataAgesInfo = cat21.GetDataAges();
                string[] dataAgesName = new string[] { "Age of latest information of Aircraft Operational Status", "Age of last update of Target Report Descriptor", "Age of last update of Mode 3A Code", "Age of last update of Quality Indicators", "Age of last update Trajectory Intent", "Age of latest measurement of Message Amplitude", "Age of Geometric Height information", "Age of Flight Level information","Age of Selected Altitude","Age of Final Selected Altitude","Age of Air Speed information","Age of value of True Air Speed","Age of value for Magnetic Heading","Age of Barometric Vertical Rate","Age of Geometric Vertical Rate","Age of the Ground Vector","Age of the Track Angle Rate","Age of the Target Identification","Age of the Target Status","Age of the Meteorological data","Age of Roll Angle","Age of ACAS Resolution","Age of Surface Capabilities"};
                string[] dataAgesUnits = new string[] { "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s" };
                string dataAges = MultipleDouble(dataAgesInfo, dataAgesName,dataAgesUnits);
                string[] row = new string[] { Convert.ToString(i), category, sac, sic, targetID, trackNumber,targetreport, serviceID, timeofreport, position, positionHigh, airspeed, trueairspeed, targetaddress, tappposition,tappvelocity,tmessageposition,tmessagepositionhigh,tmessagevel,tmessagevelhigh,geometricHeight, quality,mopsversion,m3acode,rollangle,flightlevel, magneticheading, targetstatus,barometricrate,geometricrate, airborneVector, trackanglerate, emitterCategory, meteo, selectedAltitude, finalselAltitude, trajectoryintent,servicemanagement,opstatus,surface,messageAmplitude,modeSMBData,acasResolution,receiverID,dataAges};
                dataGridView1.Rows.Add(row);
     
            }


        }

        private string MultipleDouble(string[] value, string[] name,string[] units)
        {
            string data="";
            for(int i=0;i<value.Length;i++)
            {
                if (value[i] != "N/A")
                {
                    data = data + name[i] + ": " + value[i] +units[i]+ Environment.NewLine;
                }
            }
            if (data == "")
            {
                data = "N/A";
            }
            return data;
        }
        private string MultipleString(string[] info)
        {
            string data = "";
            int length = info.Length;
            for (int i = 0; i < length; i++)
            {
                if (info[i] != "N/A" && i!=length-1)
                {
                    data = data + info[i] + Environment.NewLine;
                }
                if (info[i] != "N/A" && i == length - 1)
                {
                    data = data + info[i];
                }
            }
            if (data == "")
            {
                data = "N/A";
            }
            return data;
        }

        private string StringTime(string time)
        {
            if (time.Length >= 10)
            {
                time = time.Remove(time.Length - 4);
            }
            else
            {
                time = "Not Available";
            }
            return time;
        }

        private string StringUnits(string value, string units)
        {
            if (value == "NaN")
            {
                value = "Not Available";
            }
            else
            {
                value = value + " " + units;
            }
            return value;
        }
        private string StringPosition(double lat, double lon, int presition)
        {
            string position;
            if (lat == double.NaN || lon==double.NaN)
            {
                position = "Not Available";
            }
            else
            {
                int deg = (int)lat;
                double degDouble = Convert.ToDouble(deg);
                position = Convert.ToString(deg) + "°";
                double minDouble = (lat - degDouble)*60;
                int min = (int) minDouble;
                position = position + Convert.ToString(min) + "'";
                double sec = (minDouble - Convert.ToDouble(min)) * 60;
                string secString = Convert.ToString(sec);
                secString= secString.Remove(presition);
                position = position + secString + "'',";
                deg = (int) lon;
                degDouble = Convert.ToDouble(deg);
                position = position + Convert.ToString(deg) + "°";
                minDouble = (lon - degDouble) * 60;
                min = (int) minDouble;
                position = position + Convert.ToString(min) + "'";
                sec = (minDouble - Convert.ToDouble(min)) * 60;
                secString = Convert.ToString(sec);
                secString = secString.Remove(presition);
                position = position + secString + "''";


            }
            return position;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;

            //dataGridView1.AutoResizeRow(row, DataGridViewAutoSizeRowMode.AllCells);
            //dataGridView1.Rows[row].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[column].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }
    }
}
