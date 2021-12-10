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
        ProgressBar progessBar;
        DataTable dataTable = new DataTable();
        string filename;

        public Tabla21(List<CAT21> lista, ProgressBar p)
        {
            InitializeComponent();
            this.lista = lista;
            this.progessBar = p;

        }
        public void SetFileName(string name)
        {
            this.filename = name;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            textBox1.Visible = false;
            int length = lista.Count;

            dataTable.Columns.Add("Number");
            dataTable.Columns.Add("Category");
            dataTable.Columns.Add("SAC");
            dataTable.Columns.Add("SIC");
            dataTable.Columns.Add("Target Identification");
            dataTable.Columns.Add("Track Number");
            dataTable.Columns.Add("Target Report Descriptor");
            dataTable.Columns.Add("Service Identification");
            dataTable.Columns.Add("Time of Report Transmission");
            dataTable.Columns.Add("Position in WGS-84 Coordinates");
            dataTable.Columns.Add("Position in WGS-84 Coordinates High Resolution");
            dataTable.Columns.Add("Air Speed");
            dataTable.Columns.Add("True Airspeed");
            dataTable.Columns.Add("Target Adress");
            dataTable.Columns.Add("Time of Applicability Position");
            dataTable.Columns.Add("Time of Applicability Velocity");
            dataTable.Columns.Add("Time of Message Reception Position");
            dataTable.Columns.Add("Time of Message Reception Position High Res");
            dataTable.Columns.Add("Time of Message Reception Velocity");
            dataTable.Columns.Add("Time of Message Reception Velocity High Res");
            dataTable.Columns.Add("Geometric Height");
            dataTable.Columns.Add("Quality Indicators");
            dataTable.Columns.Add("MOPS Version");
            dataTable.Columns.Add("Mode 3A Code");
            dataTable.Columns.Add("Roll Angle");
            dataTable.Columns.Add("Flight Level");
            dataTable.Columns.Add("Magentic Heading");
            dataTable.Columns.Add("Target Status");
            dataTable.Columns.Add("Barometric Vertical Rate");
            dataTable.Columns.Add("Geometric Vertical Rate");
            dataTable.Columns.Add("Airborne Ground Vector");
            dataTable.Columns.Add("Track Angle Rate");
            dataTable.Columns.Add("Emitter Category");
            dataTable.Columns.Add("Met Information");
            dataTable.Columns.Add("Selected Altitude");
            dataTable.Columns.Add("Final State Selected Altitude");
            dataTable.Columns.Add("Trajectory Intent");
            dataTable.Columns.Add("Service Management");
            dataTable.Columns.Add("Aircraft Operational Status");
            dataTable.Columns.Add("Surface Capabilities and Characteristics");
            dataTable.Columns.Add("Message Amplitude");
            dataTable.Columns.Add("Mode S MB Data");
            dataTable.Columns.Add("ACAS Resolution");
            dataTable.Columns.Add("Receiver ID");
            dataTable.Columns.Add("Data Ages");

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < length; i++)
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
                dataTable.Rows.Add(row);
                progessBar.PerformStep();

            }
            DataView dataView = new DataView(dataTable);
            dataGridView1.DataSource = dataView;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[9].AutoSizeMode= DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[30].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[32].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Visible = true;
            textBox1.Visible = true;
            //progressBar1.Visible = false;
            Loading.Visible = true;
            Loading.Text = "All flights loaded";
            watch.Stop();
            long milliSec = watch.ElapsedMilliseconds / (1000);
            Console.WriteLine(milliSec);
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = "";
            string caption = "";
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            string value = Convert.ToString(dataGridView1.CurrentCell.Value);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            

            if (column == 6 && value != "N/A")
            {
                message = GetTargetReportDescriptor(row);
                caption = "Target Report Descriptor";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 21 && value != "N/A")
            {
                message =GetQualityIndicators(row);
                caption = "Quality Indicators";
                result = MessageBox.Show(message, caption, buttons);

            }
            if (column == 27 && value != "N/A")
            {
                message= GetTargetStatus(row);
                caption = "Target Status";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 38 && value != "N/A")
            {
                message = GetAircraftOperationalStatus(row);
                caption = "Aircraft Operational Status";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 39 && value != "N/A")
            {
                message = GetSurfaceCapabilities(row);
                caption = "Surface Capabilities";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 44 && value != "N/A")
            {
                message = GetDataAges(row);
                caption = "Data Ages";
                result = MessageBox.Show(message, caption, buttons);
            }
        }


        private void Search_Click(object sender, EventArgs e)
        {
            DataTable dataTable2 = new DataTable();
            string id;
            int i = 0;
            int length = lista.Count;
            dataGridView2.Visible = false;
            
            dataTable2.Columns.Add("Number");
            dataTable2.Columns.Add("Category");
            dataTable2.Columns.Add("SAC");
            dataTable2.Columns.Add("SIC");
            dataTable2.Columns.Add("Target Identification");
            dataTable2.Columns.Add("Track Number");
            dataTable2.Columns.Add("Target Report Descriptor");
            dataTable2.Columns.Add("Service Identification");
            dataTable2.Columns.Add("Time of Report Transmission");
            dataTable2.Columns.Add("Position in WGS-84 Coordinates");
            dataTable2.Columns.Add("Position in WGS-84 Coordinates High Resolution");
            dataTable2.Columns.Add("Air Speed");
            dataTable2.Columns.Add("True Airspeed");
            dataTable2.Columns.Add("Target Adress");
            dataTable2.Columns.Add("Time of Applicability Position");
            dataTable2.Columns.Add("Time of Applicability Velocity");
            dataTable2.Columns.Add("Time of Message Reception Position");
            dataTable2.Columns.Add("Time of Message Reception Position High Res");
            dataTable2.Columns.Add("Time of Message Reception Velocity");
            dataTable2.Columns.Add("Time of Message Reception Velocity High Res");
            dataTable2.Columns.Add("Geometric Height");
            dataTable2.Columns.Add("Quality Indicators");
            dataTable2.Columns.Add("MOPS Version");
            dataTable2.Columns.Add("Mode 3A Code");
            dataTable2.Columns.Add("Roll Angle");
            dataTable2.Columns.Add("Flight Level");
            dataTable2.Columns.Add("Magentic Heading");
            dataTable2.Columns.Add("Target Status");
            dataTable2.Columns.Add("Barometric Vertical Rate");
            dataTable2.Columns.Add("Geometric Vertical Rate");
            dataTable2.Columns.Add("Airborne Ground Vector");
            dataTable2.Columns.Add("Track Angle Rate");
            dataTable2.Columns.Add("Emitter Category");
            dataTable2.Columns.Add("Met Information");
            dataTable2.Columns.Add("Selected Altitude");
            dataTable2.Columns.Add("Final State Selected Altitude");
            dataTable2.Columns.Add("Trajectory Intent");
            dataTable2.Columns.Add("Service Management");
            dataTable2.Columns.Add("Aircraft Operational Status");
            dataTable2.Columns.Add("Surface Capabilities and Characteristics");
            dataTable2.Columns.Add("Message Amplitude");
            dataTable2.Columns.Add("Mode S MB Data");
            dataTable2.Columns.Add("ACAS Resolution");
            dataTable2.Columns.Add("Receiver ID");
            dataTable2.Columns.Add("Data Ages");
            while (i < dataGridView1.RowCount - 1)
            {
                CAT21 cat21 = lista[i];
                id = lista[i].GetTargetIdentification();
                int len= id.Length-1;
                while (id[len].Equals(' ') && len>0)
                {
                    id = id.Remove(len);
                    len = len - 1;
                }
                //id = id.Remove(7);
                //id = dataGridView1.Rows[i].Cells[12].Value.ToString();
                if (id==textBox1.Text)
                {
                    cat21 = lista[i];
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
                    dataTable2.Rows.Add(row);
                }
                i++;
            }
            DataView dataView2 = new DataView(dataTable2);
            dataGridView2.DataSource = dataView2;
            dataGridView2.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[30].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.Columns[32].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView2.RowHeadersVisible = false;
            if (dataGridView2.Rows.Count>1)
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                string message = "There are no flights with this ID";
                string caption = "Error";
                result = MessageBox.Show(message, caption, buttons);
            }


            dataGridView2.ReadOnly = true;

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = "";
            string caption = "";
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            string value = Convert.ToString(dataGridView1.CurrentCell.Value);
            int index = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value.ToString());
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            if (column == 6 && value != "N/A")
            {
                message = GetTargetReportDescriptor(index);
                caption = "Target Report Descriptor";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 21 && value != "N/A")
            {
                message = GetQualityIndicators(index);
                caption = "Quality Indicators";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 27 && value != "N/A")
            {
                message = GetTargetStatus(index);
                caption = "Target Status";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 38 && value != "N/A")
            {
                message = GetAircraftOperationalStatus(index);
                caption = "Aircraft Operational Status";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 39 && value != "N/A")
            {
                message = GetSurfaceCapabilities(index);
                caption = "Surface Capabilities";
                result = MessageBox.Show(message, caption, buttons);
            }
            if (column == 44 && value != "N/A")
            {
                message = GetDataAges(index);
                caption = "Data Ages";
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void ViewAll_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
        }
    }
}
