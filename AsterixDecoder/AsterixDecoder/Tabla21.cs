using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace AsterixDecoder
{
    public partial class Tabla21 : Form
    {
        AsterixFile asterixFile;
        Flight flight;
        List<Flight> listaflights = new List<Flight>();
        Coordinates coordinates;
        List<CAT21> lista;
        string filename;

        public Tabla21(List<CAT21> lista)
        {
            InitializeComponent();
            this.lista = lista;

        }
        public void SetFileName(string name)
        {
            this.filename = name;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadData GridForm = new LoadData();
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            progressBar1.Visible = true;
            //asterixFile = new AsterixFile(this.filename);
            //lista = asterixFile.getListCAT21();
            int length = lista.Count;
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
            progressBar1.Minimum = 0;
            // Sets the progress bar's maximum value to a number representing  
            // all operations complete -- in this case, all five files read.  
            progressBar1.Maximum = 1000;
            // Sets the Step property to amount to increase with each iteration.  
            // In this case, it will increase by one with every file read.  
            progressBar1.Step = 1;

            //dataGridView1.Columns[9].AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[22].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[30].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[32].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[21].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[27].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[38].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[44].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly=true;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000; i++)
            {

                CAT21 cat21 = lista[i];
                string category = Convert.ToString(cat21.GetCategory());
                string sac = Convert.ToString(cat21.GetSystemAreaCode());
                string sic = Convert.ToString(cat21.GetSystemIdentificationCode());
                string targetID = cat21.GetTargetIdentification();
                string trackNumber = Convert.ToString(cat21.GetTrackNumber());
                string serviceID = Convert.ToString(cat21.GetServiceIdentification());

                string targetreport = GetTargetReportDescriptor(i);
                if (targetreport != "N/A")
                {
                    targetreport = "Click to expand";
                }

                string timeofreport = Convert.ToString(cat21.GetTimeOfReportTransmission());
                timeofreport = StringTime(timeofreport);


                double latitude = cat21.GetLatitudeWGS84();
                double longitude = cat21.GetLongitudeWGS84();
                string position = StringPosition(latitude, longitude, 5, i);
                latitude = cat21.GetLatitudeWGS84High();
                longitude = cat21.GetLongitudeWGS84High();
                string positionHigh = StringPosition(latitude, longitude, 7, i);
                string airspeed = Convert.ToString(cat21.GetAirspeed());
                airspeed = StringUnits(airspeed, "Mach");
                string trueairspeed = Convert.ToString(cat21.GetTrueAirspeed());
                trueairspeed = StringUnits(trueairspeed, "knot");
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


                string quality = GetQualityIndicators(i);
                if (quality != "N/A")
                {
                    quality = "Click to expand";
                }
                string mopsversion = cat21.GetMOPSVersion();
                string m3acode = cat21.GetMode3ACode();
                string rollangle = Convert.ToString(cat21.GetRollAngle());
                rollangle = StringUnits(rollangle, "°");
                string flightlevel = Convert.ToString(cat21.GetFlightLevel());
                flightlevel = StringUnits(flightlevel, "FL");

                string magneticheading = Convert.ToString(cat21.GetMagneticHeading());
                magneticheading = StringUnits(magneticheading, "°");

                string targetstatus = GetTargetStatus(i);
                if (targetstatus != "N/A")
                {
                    targetstatus = "Click to expand";
                }


                string barometricrate = Convert.ToString(cat21.GetBarometricVerticalRate());
                barometricrate = StringUnits(barometricrate, "ft/min");
                string geometricrate = Convert.ToString(cat21.GetGeometricVerticalRate());
                geometricrate = StringUnits(geometricrate, "ft/min");

                string airborneVector = GetAirborneVector(i);

                string trackanglerate = Convert.ToString(cat21.GetTrackAngleRate());
                trackanglerate = StringUnits(trackanglerate, "°/s");
                string emitterCategory = cat21.GetEmitterCategory();

                string meteo = GetMetInformation(i);
                string selectedAltitude = Convert.ToString(cat21.GetSelectedAltitude());
                selectedAltitude = StringUnits(selectedAltitude, "ft");
                string finalselAltitude = Convert.ToString(cat21.GetFinalStateSelectedAltitude());
                finalselAltitude = StringUnits(finalselAltitude, "ft");
                string trajectoryintent = cat21.GetTrajectoryIntent();
                string servicemanagement = Convert.ToString(cat21.GetServiceManagement());
                servicemanagement = StringUnits(servicemanagement, "sec");

                string opstatus = GetAircraftOperationalStatus(i);
                if (opstatus != "N/A")
                {
                    opstatus = "Click to expand";
                }
                string surface = GetSurfaceCapabilities(i);
                if (surface != "N/A")
                {
                    surface = "Click to expand";
                }
                string messageAmplitude = Convert.ToString(cat21.GetMessageAmplitude());
                messageAmplitude = StringUnits(messageAmplitude, "dBm");
                string modeSMBData = cat21.GetModeSMBData();
                string acasResolution = cat21.GetAcasResolution();
                string receiverID = Convert.ToString(cat21.GetReceiverID());

                string dataAges = GetDataAges(i);
                if (dataAges != "N/A")
                {
                    dataAges = "Click to expand";
                }
                string[] row = new string[] { Convert.ToString(i), category, sac, sic, targetID, trackNumber, targetreport, serviceID, timeofreport, position, positionHigh, airspeed, trueairspeed, targetaddress, tappposition, tappvelocity, tmessageposition, tmessagepositionhigh, tmessagevel, tmessagevelhigh, geometricHeight, quality, mopsversion, m3acode, rollangle, flightlevel, magneticheading, targetstatus, barometricrate, geometricrate, airborneVector, trackanglerate, emitterCategory, meteo, selectedAltitude, finalselAltitude, trajectoryintent, servicemanagement, opstatus, surface, messageAmplitude, modeSMBData, acasResolution, receiverID, dataAges };
                dataGridView1.Rows.Add(row);
                progressBar1.PerformStep();


                ////Añado class flight para googleearth
                //flight = new Flight(receiverID);//no se si i es el id cambialo porfa
                //coordinates = new Coordinates(latitude, longitude);
                //flight.SetcoordinatesCAT21(coordinates);
                //listaflights.Add(flight);

            }
            watch.Stop();
            long milliSec = watch.ElapsedMilliseconds/ (1000);
            Console.WriteLine(milliSec);
            progressBar1.Visible = false;
            Loading.Visible = true;
            Loading.Text = "All flights loaded";

          



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
        private string StringPosition(double lat, double lon, int presition, int row)
        {
            string position;
            int n = row;
            string lati = Convert.ToString(lat);
            string longi = Convert.ToString(lon);
            if (lati == "NaN" || longi=="NaN")
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
                if (secString.Length > presition)
                {
                    secString = secString.Remove(presition);
                }
                position = position + secString + "'',";
                deg = (int) lon;
                degDouble = Convert.ToDouble(deg);
                position = position + Convert.ToString(deg) + "°";
                minDouble = (lon - degDouble) * 60;
                min = (int) minDouble;
                position = position + Convert.ToString(min) + "'";
                sec = (minDouble - Convert.ToDouble(min)) * 60;
                secString = Convert.ToString(sec);
                if (secString.Length>presition)
                {
                    secString = secString.Remove(presition);
                }
                position = position + secString + "''";


            }
            return position;
        }

        private string GetTargetReportDescriptor(int row)
        {
            string[] targetReportDescriptor = lista[row].GetTargetReportDescriptor();
            string targetreport = MultipleString(targetReportDescriptor);
            return targetreport;
        }

        private string GetQualityIndicators(int row)
        {
            int[] qualityIndicatorsInfo = lista[row].GetQualityIndicators();
            string[] qualityIndicatorsName = new string[] { "NUCr or NACv", "NUCp or NIC", "Navigation Integrity Category for Barometric Altitude", "Surveillance or Source Integrity Level", "Navigation Accuracy Category for Position", "SIL-Supplement", "Horizontal Position System Design Assurance Level", "Geometric Altitude Accuracy", "Position Integrity Category" };
            string[] qualityIndicators = new string[qualityIndicatorsName.Length];
            string[] qualityUnits = new string[] { "", "", "", "", "", "", "", "", "" };
            for (int k = 0; k < qualityIndicatorsInfo.Length; k++)
            {

                qualityIndicators[k] = Convert.ToString(qualityIndicatorsInfo[k]);
                if (qualityIndicators[k] == "-1")
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
            string quality = MultipleDouble(qualityIndicators, qualityIndicatorsName, qualityUnits);
            return quality;
        }
        private string GetDataAges(int row)
        {
            string[] dataAgesInfo = lista[row].GetDataAges();
            for (int k = 0; k < dataAgesInfo.Length; k++)
            {
                if (dataAgesInfo[k] == "0")
                {
                    dataAgesInfo[k] = "N/A";
                }
            }
            string[] dataAgesName = new string[] { "Age of latest information of Aircraft Operational Status", "Age of last update of Target Report Descriptor", "Age of last update of Mode 3A Code", "Age of last update of Quality Indicators", "Age of last update Trajectory Intent", "Age of latest measurement of Message Amplitude", "Age of Geometric Height information", "Age of Flight Level information", "Age of Selected Altitude", "Age of Final Selected Altitude", "Age of Air Speed information", "Age of value of True Air Speed", "Age of value for Magnetic Heading", "Age of Barometric Vertical Rate", "Age of Geometric Vertical Rate", "Age of the Ground Vector", "Age of the Track Angle Rate", "Age of the Target Identification", "Age of the Target Status", "Age of the Meteorological data", "Age of Roll Angle", "Age of ACAS Resolution", "Age of Surface Capabilities" };
            string[] dataAgesUnits = new string[] { "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s" };
            string dataAges = MultipleDouble(dataAgesInfo, dataAgesName, dataAgesUnits);
            return dataAges;
        }

        private string GetAircraftOperationalStatus(int row)
        {
            string[] opstatusData = lista[row].GetOperationalStatus();
            string opstatus = MultipleString(opstatusData);
            return opstatus;
        }
        private string GetAirborneVector(int row)
        {
            string[] airborneVectorInfo = lista[row].GetAirborneVector();
            string airborneVector;
            if (airborneVectorInfo[0] == "NaN")
            {
                airborneVector = "Not Available";
            }
            else
            {
                string trackangle = airborneVectorInfo[1];
                while (trackangle.Length > 5)
                {
                    trackangle=trackangle.Remove(trackangle.Length-1);
                }
                airborneVector = "GS: " + airborneVectorInfo[0] + "knts, T.A: " + trackangle + "°";
            }
            return airborneVector;
        }
        private string GetMetInformation(int row)
        {
            string[] meteoInfo = lista[row].GetMetInformation();
            string[] meteoName = new string[] { "Wind Speed", "Wind Direction", "Temperature", "Turbulence" };
            string[] meteoUnits = new string[] { "knot", "°", "°C", "" };
            string meteo = MultipleDouble(meteoInfo, meteoName, meteoUnits);
            return meteo;
        }
        private string GetTargetStatus(int row)
        {
            string[] targetstatusInfo = lista[row].GetTargetStatus();
            targetstatusInfo[2] = "Priority Status: " + targetstatusInfo[2];
            targetstatusInfo[3] = "Surveillance Status: " + targetstatusInfo[3];
            string targetstatus;
            if (targetstatusInfo[0] != "N/A")
            {
                targetstatus = MultipleString(targetstatusInfo);
            }
            else
                targetstatus = "N/A";
            return targetstatus;
        }
        private string GetSurfaceCapabilities(int row)
        {
            string[] surfaceData = lista[row].GetSurfaceCapabilities();
            string surface = MultipleString(surfaceData);
            return surface;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            string value = Convert.ToString(dataGridView1.CurrentCell.Value);
            for (int i=0;i<dataGridView1.RowCount-1;i++)
            {
                string val = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
                string val2 = Convert.ToString(dataGridView1.Rows[i].Cells[21].Value);
                string val3 = Convert.ToString(dataGridView1.Rows[i].Cells[27].Value);
                string val4 = Convert.ToString(dataGridView1.Rows[i].Cells[38].Value);
                string val5 = Convert.ToString(dataGridView1.Rows[i].Cells[39].Value);
                string val6 = Convert.ToString(dataGridView1.Rows[i].Cells[44].Value);

                if (val != "N/A"&& i!=row)
                    {
                        dataGridView1.Rows[i].Cells[6].Value = "Click to expand";
                    }
                if (val2 != "N/A" && i != row)
                {
                    dataGridView1.Rows[i].Cells[21].Value = "Click to expand";
                }
                if (val3 != "N/A" && i != row)
                {
                    dataGridView1.Rows[i].Cells[27].Value = "Click to expand";
                }
                if (val4 != "N/A" && i != row)
                {
                    dataGridView1.Rows[i].Cells[38].Value = "Click to expand";
                }
                if (val5 != "N/A" && i != row)
                {
                    dataGridView1.Rows[i].Cells[39].Value = "Click to expand";
                }
                if (val6 != "N/A" && i != row)
                {
                    dataGridView1.Rows[i].Cells[44].Value = "Click to expand";
                }

            }

            if (column == 6 && value != "N/A")
            {
                if (value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = GetTargetReportDescriptor(row);
                
            }
            if (column == 21 && value != "N/A")
            {
                if (value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = GetQualityIndicators(row);
                
            }
            if (column == 27 && value != "N/A")
            {
                if (value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = GetTargetStatus(row);
                
            }
            if (column == 38 && value != "N/A")
            {
                if (value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = GetAircraftOperationalStatus(row);
                
            }
            if (column == 39 && value != "N/A")
            {
                if (value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = GetSurfaceCapabilities(row);

            }
            if (column == 44 && value != "N/A")
            {
                if (value != "Click to expand")
                {
                    dataGridView1.CurrentCell.Value = "Click to expand";
                }
                else
                    dataGridView1.CurrentCell.Value = GetDataAges(row);
                
            }

            //dataGridView1.AutoResizeRow(row, DataGridViewAutoSizeRowMode.AllCells);
            //dataGridView1.Rows[row].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[column].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[column].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }
        //private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    int column = e.ColumnIndex;
        //    string value = Convert.ToString(dataGridView1.CurrentCell.Value);
        //    if (column == 6 || column == 21 || column == 27 || column == 38 || column == 44)
        //    {
        //        if (value != "N/A")
        //        {
        //            dataGridView1.CurrentCell.Value = "Click to expand";
        //        }
                

        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {

            string s;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    s = row.Cells[4].Value.ToString();
                    if (s.Equals(textBox1.Text) || textBox1.Text == "")
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

        private void btnMap_Click(object sender, EventArgs e)
        {
            //le paso al form map el fligths con coordenadas
            //Map map = new Map();
            //map.SetFlights(listaflights);
            //map.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
