using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public class CAT21
    {
        //Initialization
        byte[] arraystring;
        List<byte> data;
        int length;
        int category;

        //Field Especification
        byte[] FSPEC;

        //Data items
        int systemIdentificationCode;
        int systemAreaCode;
        int trackNumber;
        int serviceIdentification;
        string atp;//Target Report Descriptor
        string arc;
        string rc;
        string rab;
        string dcr;
        string gbs;
        string sim;
        string tst;
        string saa;
        string cl;
        string ipc;
        string nogo;
        string cpr;
        string ldpj;
        string rcf;//Target Report Descriptor
        TimeSpan timeofApplicabilityPosition;
        double latitudeWGS84;//WGS-84 Positions
        double longitudeWGS84;
        double latitudeWGS84high;
        double longitudeWGS84high;//WGS-84 Positions


        TimeSpan timeofApplicabilityVelocity;
        double airspeed;//Airspeed
        string IMairspeed;
        double trueAirSpeed;
        string reAirspeed;//Airspeed
        
        int targetAddress;
        TimeSpan timeofMessageReceptionPosition;
        string FSIPositionHighPrecision;
        string FSIVelocityHighPrecision;
        TimeSpan timeofMessageReceptionPositionHighPrecision;
        TimeSpan timeofMessageReceptionVelocity;
        TimeSpan timeofMessageReceptionVelocityHighPrecision;



        double geometricHeight;

        string mopsVNS;
        string mopsVN;
        string mopsLTT;
        //Quality Indicators
        int nucr;
        int nucp;
        int nicbaro;
        int sil;
        int nacp;
        int silSupplement;
        int sda;
        int gva;
        int pic;
        string m3ACode;

        double rollAngle;
        double flightLevel;

        double magneticHeading;
        string icf;
        string lnav;
        string ps;
        string ss;
        
        double barometricVerticalRate;
        string reBVR;//BarometricVerticalRange
        double geometricVerticalRate;
        string reGVR;

        string reAirborneGroundVector;
        double groundSpeed;
        double trackAngle;
        double trackAngleRate;
        TimeSpan timeOfReportTransmission;

        string targetIdentification;
        string emitterCategory;

        //Met Information
        string[] metInformation;
        double windspeed;
        double windDirection;
        double temperature;
        double turbulence;

        double serviceManagement;
        string trajectoryIntent;
        //SelectedAltitude
        string sas;
        string source;
        double selectedAltitude;
        double finalStateSelectedAltitude;
        string mv;
        string ah;
        string am;

        string aircraftOperationalStatus;
        // aircraftOperationalStatus  parameters
        string ra;
        string tc;
        string ts;
        string arv;
        string cdtia;
        string notticas;
        string sa;

        double surfaceCapabilitiesandCharacteristics;
        //surfacecapaparameters
        string poa;
        string cdtis;
        string b2low;
        string ras;
        string ident;
        string widthv1;
        string lengthv1;

        double messageAmplitude;
        double receiverID;

        string acasResolution;
        string modeSMbData;
        //Data Ages
        string aos;
        string trd;
        string m3a;
        string qi;
        string ti;
        string mam;
        string gh;
        string fl;
        string isa;
        string fsa;
        string asage;
        string tas;
        string mh;
        string bvr;
        string gvr;
        string gv;
        string tar;
        string ti2;
        string tsage;
        string met;
        string roa;
        string ara;
        string scc;

        public CAT21(byte[] arraystring)
        {
            //if int:-1  string:notava
            this.arraystring = arraystring;
            this.length = -1;
            this.data = new List<byte>();
            this.category = 21;
            SetData();
            this.systemIdentificationCode = -1;
            this.systemAreaCode = -1;

            //Target Report Descriptor
            atp = "Not Available";
            arc = "Not Available";
            rc = "Not Available";
            rab = "Not Available";
            dcr = "Not Available";
            gbs = "Not Available";
            sim = "Not Available";
            tst = "Not Available";
            saa = "Not Available";
            cl = "Not Available";
            ipc = "Not Available";
            nogo = "Not Available";
            cpr = "Not Available";
            ldpj = "Not Available";
            rcf = "Not Available";

            this.trackNumber = -1;
            this.serviceIdentification = -1;

            this.timeofApplicabilityPosition = new TimeSpan();
            //Position WGS84
            this.latitudeWGS84 = double.NaN;
            this.longitudeWGS84 = double.NaN;

            this.latitudeWGS84high = double.NaN;
            this.longitudeWGS84high = double.NaN;

            this.timeofApplicabilityVelocity = new TimeSpan();
            //Airspeed
            this.airspeed = double.NaN;
            this.IMairspeed = "N/A";
            this.trueAirSpeed = double.NaN;
            this.reAirspeed = "N/A";

            this.targetAddress = -1;
            this.timeofMessageReceptionPosition = new TimeSpan();
            this.FSIPositionHighPrecision = "N/A";
            this.timeofMessageReceptionPositionHighPrecision = new TimeSpan();
            this.timeofMessageReceptionVelocity = new TimeSpan();
            this.FSIVelocityHighPrecision = "N/A";
            this.timeofMessageReceptionVelocityHighPrecision = new TimeSpan();
            this.geometricHeight = double.NaN;

            //Quality Indicators
            this.nucr=-1;
            this.nucp=-1;
            this.nicbaro=-1;
            this.sil=-1;
            this.nacp=-1;
            this.silSupplement=-1;
            this.sda=-1;
            this.gva = -1;
            this.pic = -1;
           
            this.mopsVNS = "N/A";
            this.mopsVN = "N/A";
            this.mopsLTT = "N/A";
            this.m3ACode = "N/A";

            this.rollAngle= double.NaN;
            this.flightLevel = double.NaN;

            this.magneticHeading = double.NaN;
            this.icf= "N/A";
            this.lnav="N/A";
            this.ps= "N/A";
            this.ss="N/A"; 
            this.barometricVerticalRate = double.NaN;
            this.reBVR = "N/A";
            this.geometricVerticalRate = double.NaN;
            this.reGVR= "N/A";

            this.reAirborneGroundVector = "N/A";
            this.groundSpeed = double.NaN;
            this.trackAngle = double.NaN;
            this.trackAngleRate = double.NaN;

            this.timeOfReportTransmission = new TimeSpan();

            this.targetIdentification = "N/A";
            this.emitterCategory = "N/A";
            this.metInformation = new string[] {"N/A","N/A","N/A","N/A"};
            //metinformation parameters
            this.windspeed = double.NaN;
            this.turbulence=double.NaN;
            this.temperature=double.NaN;
            this.windDirection=double.NaN;
            this.sas = "N/A";
            this.source = "N/A";
            this.selectedAltitude = double.NaN;
            this.finalStateSelectedAltitude = double.NaN;
            ///finalaltittude parameteres
            this.mv= "N/A";
            this.ah= "N/A";
            this.am= "N/A";
            this.serviceManagement = double.NaN;
            this.trajectoryIntent = "N/A";


            this.aircraftOperationalStatus = "N/A";
            this.ra = "N/A";
            this.tc = "N/A";
            this.ts = "N/A";
            this.arv = "N/A";
            this.cdtia = "N/A";
            this.notticas = "N/A";
            this.sa = "N/A";
            this.surfaceCapabilitiesandCharacteristics = double.NaN;
            this.poa = "N/A";
            this.cdtis= "N/A";
            this.b2low= "N/A";
            this.ras= "N/A";
            this.ident= "N/A";
            this.widthv1="N/A";
            this.lengthv1="N/A";
            this.messageAmplitude = double.NaN;
            this.modeSMbData = "N/A";
            this.acasResolution = "N/A";
            this.receiverID = double.NaN;
            this.aos="N/A";
            this.trd ="N/A";
            this.m3a="N/A";
            this.qi = "N/A";
            this.ti="N/A";
            this.mam="N/A";
            this.gh="N/A";
            this.fl="N/A";
            this.isa="N/A";
            this.fsa="N/A";
            this.asage="N/A";
            this.tas="N/A";
            this.mh="N/A";
            this.bvr="N/A";
            this.gvr="N/A";
            this.gv="N/A";
            this.tar="N/A";
            this.ti2="N/A";
            this.tsage="N/A";
            this.met="N/A";
            this.roa="N/A";
            this.ara="N/A";
            this.scc="N/A";



            data.RemoveAt(0);
            data.RemoveAt(0);
            data.RemoveAt(0);
            byte[] FSPECNew = GetFSPEC();

            this.SetDataItems();
        }

        public int GetCategory()
        {
            return this.category;
        }
        public byte[] GetArray()
        {
            return this.arraystring;
        }

        public int GetSystemAreaCode()
        {
            return this.systemAreaCode;
        }

        public int GetSystemIdentificationCode()
        {
            return this.systemIdentificationCode;
        }

        public int GetTrackNumber()
        {
            return this.trackNumber;
        }

        public double GetLatitudeWGS84()
        {
            return this.latitudeWGS84;
        }

        public double GetLongitudeWGS84()
        {
            return this.longitudeWGS84;
        }

        public double GetLatitudeWGS84High()
        {
            return this.latitudeWGS84high;
        }

        public double GetLongitudeWGS84High()
        {
            return this.longitudeWGS84high;
        }
        public double GetAirspeed()
        {
            return this.airspeed;
        }
        public double GetTrueAirspeed()
        {
            return this.trueAirSpeed;
        }
        public byte[] GetFieldEspec()
        {
            return this.FSPEC;
        }
        public int GetTargetAddress()
        {
            return this.targetAddress;
        }
        public double GetGeometricHeight()
        {
            return this.geometricHeight;
        }
        public double GetRollAngle()
        {
            return this.rollAngle;
        }
        public double GetFlightLevel()
        {
            return this.flightLevel;
        }
        public double GetMagneticHeading()
        {
            return this.magneticHeading;
        }
        public string[] GetTargetStatus()
        {
            string[] data = new string[] { this.icf, this.lnav, this.ps, this.ss };
            return data;
        }

        public double GetBarometricVerticalRate()
        {
            return this.barometricVerticalRate;
        }
        public double GetGeometricVerticalRate()
        {
            return this.geometricVerticalRate;
        }
        public string[] GetAirborneVector()
        {
            string[] data = {Convert.ToString(this.groundSpeed), Convert.ToString(this.trackAngle) };
            return data;
        }
        public double GetTrackAngleRate()
        {
            return this.trackAngleRate;
        }
        public TimeSpan GetTimeOfReportTransmission()
        {
            return this.timeOfReportTransmission;
        }

        public TimeSpan GetTimeOfApplicabilityPosition()
        {
            return this.timeofApplicabilityPosition;
        }
        public TimeSpan GetTimeOfApplicabilityVelocity()
        {
            return this.timeofApplicabilityVelocity;
        }
        public TimeSpan GetTimeOfMessagePosition()
        {
            return this.timeofMessageReceptionPosition;
        }
        public TimeSpan GetTimeOfMessagePositionHigh()
        {
            return this.timeofMessageReceptionPositionHighPrecision;
        }
        public TimeSpan GetTimeOfMessageVelocity()
        {
            return this.timeofMessageReceptionVelocity;
        }
        public TimeSpan GetTimeOfMessageVelocityHigh()
        {
            return this.timeofMessageReceptionVelocityHighPrecision;
        }
        public int GetServiceIdentification()
        {
            return this.serviceIdentification;
        }
        public string GetMOPSVersion()
        {
            return this.mopsVN;
        }
        public string GetMode3ACode()
        {
            return this.m3ACode;
        }
        public string GetTargetIdentification()
        {
            return this.targetIdentification;
        }
        public int[] GetQualityIndicators()
        {
            int[] data = new int[] {this.nucr,this.nucp,this.nicbaro,this.sil,this.nacp,this.silSupplement,this.sda,this.gva,this.pic };
            return data;
        }
        public string GetEmitterCategory()
        {
            return this.emitterCategory;
        }
        public string[] GetMetInformation()
        {
            return this.metInformation;
        }

        public double GetSelectedAltitude()
        {
            return this.selectedAltitude;
        }
        public double GetFinalStateSelectedAltitude()
        {
            return this.finalStateSelectedAltitude;
        }
        public double GetServiceManagement()
        {
            return this.serviceManagement;
        }
        public string GetTrajectoryIntent()
        {
            return this.trajectoryIntent;
        }
        public double GetReceiverID()
        {
            return this.receiverID;
        }
        public double GetMessageAmplitude()
        {
            return this.messageAmplitude;
        }

        public string GetModeSMBData()
        {
            return this.modeSMbData;
        }
        public string GetAcasResolution()
        {
            return this.acasResolution;
        }
        public string[] GetOperationalStatus()
        {
            string[] operationalstatus = new string[7];
            operationalstatus[0] = this.ra;
            operationalstatus[1] = this.tc;
            operationalstatus[2] = this.ts;
            operationalstatus[3] = this.arv;
            operationalstatus[4] = this.cdtia;
            operationalstatus[5] = this.notticas;
            operationalstatus[6] = this.sa;
            return operationalstatus;
        }

        public string[] GetSurfaceCapabilities()
        {
            string[] data = new string[7];
            data[0] = this.poa;
            data[1] = this.cdtis;
            data[2] = this.b2low;
            data[3] = this.ras;
            data[4] = this.ident;
            data[5] = this.lengthv1;
            data[6] = this.widthv1;

            return data;
        }
        public string[] GetDataAges()
        {
            string[] data = new string[23];
            data[0] = this.aos;
            data[1] = this.trd;
            data[2] = this.m3a;
            data[3] = this.qi;
            data[4] = this.ti;
            data[5] = this.mam;
            data[6] = this.gh;
            data[7] = this.fl;
            data[8] = this.isa;
            data[9] = this.fsa;
            data[10] = this.asage;
            data[11] = this.tas;
            data[12] = this.mh;
            data[13] = this.bvr;
            data[14] = this.gvr;
            data[15] = this.gv;
            data[16] = this.tar;
            data[17] = this.ti2;
            data[18] = this.tsage;
            data[19] = this.met;
            data[20] = this.roa;
            data[21] = this.ara;
            data[22] = this.scc;
            

            return data;
        }
        public string[] GetTargetReportDescriptor()
        {
            string[] data = new string[15];
            data[0] = this.atp;
            data[1] = this.arc;
            data[2] = this.rc;
            data[3] = this.rab;
            data[4] = this.dcr;
            data[5] = this.gbs;
            data[6] = this.sim;
            data[7] = this.tst;
            data[8] = this.saa;
            data[9] = this.cl;
            data[10] = this.ipc;
            data[11] = this.nogo;
            data[12] = this.cpr;
            data[13] = this.ldpj;
            data[14] = this.rcf;

            return data;
        }
        public TimeSpan GetTime()
        {
            TimeSpan time = new TimeSpan();
            int result = TimeSpan.Compare(this.timeofApplicabilityPosition, TimeSpan.Zero);
            if (result==1)
            {
                time = timeofApplicabilityPosition;
            }
            else if (result == 0)
            {
                time = timeofMessageReceptionPosition;
            }
            return time;
               
        }
        public int HexToDec(string hexValue)
        {
            int intValue = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            return intValue;
        }

        public string HextoBin(string hexValue)
        {
            string binValue = "";
            binValue = Convert.ToString(Convert.ToInt32(hexValue, 16), 2);
            return binValue;
        }

        public byte[] GetFSPEC() 
        {
            int moreFSPEC = 1;
            byte lastBitCheck = 1;
            List<byte> FSPEC = new List<byte>();
            while (moreFSPEC == 1)
            {

                if ((data[0] & lastBitCheck) != 0)
                {
                    FSPEC.Add(data[0]);
                    data.RemoveAt(0);

                }
                else
                {
                    FSPEC.Add(data[0]);
                    data.RemoveAt(0);
                    moreFSPEC = 0;
                }
            }
            byte[] fieldEspec = FSPEC.ToArray();
            this.FSPEC = fieldEspec;
            return fieldEspec;

        }

        public void SetData()
        {
            for (int i = 0; i < this.arraystring.Length; i++)
            {
                data.Add(this.arraystring[i]);
            }
        }
        public byte[] GetFixedLengthItem(int length)
        {
            byte[] dataItem = new byte[length];
            for (int i = 0; i < length; i++)
            {
                if (this.data.Count>0)
                {
                    dataItem[i] = this.data[0];
                    data.RemoveAt(0);
                }
                     
            }
            return dataItem;
        }

        public byte[] GetVariableLengthItem()
        {
            int moreByte = 1;
            List<byte> dataItem = new List<byte>();
            //dataItem.Add(this.data[0]);
            //data.RemoveAt(0);
            byte lastBitCheck = 1;
            while (moreByte == 1)
            {
                if ((data[0] & lastBitCheck) != 0)
                {
                    dataItem.Add(this.data[0]);
                    data.RemoveAt(0);
                }
                else
                {
                    dataItem.Add(this.data[0]);
                    data.RemoveAt(0);
                    moreByte = 0;
                }
            }
            return dataItem.ToArray();
        }


        public void SetDataItems()
        {
            BitArray boolFSPEC = new BitArray(this.FSPEC);
            if (FSPEC.Length >= 1)
            {
                if (boolFSPEC[7] == true) //Data Source Identifier
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetDataSourceIdentifier(dataItem);
                }
                if (boolFSPEC[6] == true) //Target Report
                {
                    byte[] dataItem = GetVariableLengthItem();
                    SetTargetReport(dataItem);
                }
                if (boolFSPEC[5] == true) //Track Number
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetTrackNumber(dataItem);
                }
                if (boolFSPEC[4] == true) //Service Identification
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetServiceIdentification(dataItem);
                }
                if (boolFSPEC[3] == true) //Time of Applicability for Position
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfApplicabilityPosition(dataItem);
                }
                if (boolFSPEC[2] == true) //Position WGS84 
                {
                    byte[] dataItem = GetFixedLengthItem(6);
                    SetPositionWGS84(dataItem);
                }
                if (boolFSPEC[1] == true) //Position WGS84 High Resolution
                {
                    byte[] dataItem = GetFixedLengthItem(8);
                    SetPositionWGS84HighResolution(dataItem);
                }
            }
            if (FSPEC.Length >= 2)
            {
                if (boolFSPEC[15] == true) //Time of Applicability for Velocity
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfApplicabilityVelocity(dataItem);
                }
                if (boolFSPEC[14] == true) //Air Speed
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetAirSpeed(dataItem);
                }
                if (boolFSPEC[13] == true) //True Air Speed
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetTrueAirSpeed(dataItem);
                }
                if (boolFSPEC[12] == true) //TargetAdress
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTargetAdress(dataItem);
                }
                if (boolFSPEC[11] == true) //Time of message reception Position
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfMessageReceptionPosition(dataItem);
                }
                if (boolFSPEC[10] == true) //Time of message reception Position High Precision
                {
                    byte[] dataItem = GetFixedLengthItem(4);
                    SetTimeOfMessageReceptionPositionHighPrecision(dataItem);
                }
                if (boolFSPEC[9] == true) //Time of message reception Velocity
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfMessageReceptionVelocity(dataItem);

                }
            }
            if (FSPEC.Length >= 3)
            {
                if (boolFSPEC[23] == true) //Time of message reception Velocity High Resolution
                {
                    byte[] dataItem = GetFixedLengthItem(4);
                    SetTimeOfMessageReceptionVelocityHighResolution(dataItem);
                }
                if (boolFSPEC[22] == true) //Geometric Height
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetGeometricHeight(dataItem);
                }
                if (boolFSPEC[21] == true) //Quality Indicators
                {
                    byte[] dataItem = GetVariableLengthItem();
                    SetQualityIndicators(dataItem);
                }
                if (boolFSPEC[20] == true) //MOPS Version
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetMOPSVersion(dataItem);
                }
                if (boolFSPEC[19] == true) //Mode 3/A Code
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetMode3ACode(dataItem);
                }
                if (boolFSPEC[18] == true) //Roll Angle
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetRollAngle(dataItem);
                }
                if (boolFSPEC[17] == true) //Flight Level
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetFlightLevel(dataItem);
                }
            }
            if (FSPEC.Length >= 4)
            {
                if (boolFSPEC[31] == true) //Magnetic heading
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetMagneticHeading(dataItem);
                }
                if (boolFSPEC[30] == true) //Target Status
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetTargetStatus(dataItem);
                }
                if (boolFSPEC[29] == true) //Barometric Vertical Rate
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetBarometricVerticalRate(dataItem);
                }
                if (boolFSPEC[28] == true) //Geometric Vertical Rate
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetGeometricVerticalRate(dataItem);
                }
                if (boolFSPEC[27] == true) //Airborne Ground Vector
                {
                    byte[] dataItem = GetFixedLengthItem(4);
                    SetAirborneGroundVector(dataItem);
                }
                if (boolFSPEC[26] == true) //Track Angle Rate
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetTrackAngleRate(dataItem);
                }
                if (boolFSPEC[25] == true) //Time of Report Transmission
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfReportTransmission(dataItem);
                }
            }

            if (FSPEC.Length >= 5)
            {
                if (boolFSPEC[39] == true) //Target Identification
                {
                    byte[] dataItem = GetFixedLengthItem(6);
                    SetTargetIdentification(dataItem);
                }
                if (boolFSPEC[38] == true) //Emitter Category
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetEmitterCategory(dataItem);
                }
                if (boolFSPEC[37] == true) //Met Information
                {
                    byte[] dataItem1 = GetFixedLengthItem(1);
                    byte WDMask = 64;
                    byte TMPMask = 32;
                    byte TRBMAsk = 16;
                    int ws = dataItem1[0] >> 7;
                    int wd = (dataItem1[0] & WDMask) >> 6;
                    int tmp = (dataItem1[0] & TMPMask) >> 5;
                    int trb = (dataItem1[0] & TRBMAsk) >> 4;
                    int suma = ws*2 + wd*2 + tmp*2 + trb;
                    byte[] dataItem2 = GetFixedLengthItem(suma);
                    int n = 0;
                    byte[] dataItem = new byte[suma+1];
                    dataItem[0] = dataItem1[0];
                    while (n < suma)
                    {
                         dataItem[n+1]=dataItem2[n];
                    }
                    
                    SetMetInformation(dataItem,ws,wd,tmp,trb);
                }

                if (boolFSPEC[36] == true) //Selected Altitude
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetSelectedAltitude(dataItem);
                }
                if (boolFSPEC[35] == true) //Final State Selected Altitude
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetFinalStateSelectedAltitude(dataItem);
                }
                if (boolFSPEC[34] == true) //Trajectory Intent 
                {
                    byte[] dataItem = GetVariableLengthItem();
                    SetTrajectoryIntent(dataItem);
                }
                if (boolFSPEC[33] == true) //Service Management
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetServiceManagement(dataItem);

                }
            }

            if (FSPEC.Length >= 6)
            {
                if (boolFSPEC[47] == true) //Aircraft Operational Status
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetAircraftOperationalStatus(dataItem);
                }
                if (boolFSPEC[46] == true) //Surface Capabilities
                {
                    byte[] dataItem = GetVariableLengthItem();
                    SetsurfaceCapabilitiesandCharacteristics(dataItem);
                }
                if (boolFSPEC[45] == true) //Message amplitude
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetMessageAmplitude(dataItem);
                }
                if (boolFSPEC[44] == true) //Mode S MB Data (No hay que hacerlo)
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetModeSMBData(dataItem);
                }
                if (boolFSPEC[43] == true) //ACAS Resolution
                {
                    byte[] dataItem = GetFixedLengthItem(7);
                    SetACASResolution(dataItem);
                }
                if (boolFSPEC[42] == true) //Receiver ID
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetReceiverID(dataItem);
                }
                if (boolFSPEC[41] == true) //DataAges
                {
                    int i = 0;
                    List<byte> dataItem = new List<byte>
                    {
                        GetFixedLengthItem(1)[0]
                    };
                    if ((dataItem[i] & 1) == 1)
                    {
                        dataItem.Add(GetFixedLengthItem(1)[0]);
                        i++;
                    }
                    if ((dataItem[i] & 1) == 1 && dataItem.Count==(i+1))
                    {
                        dataItem.Add(GetFixedLengthItem(1)[0]);
                        i++;
                    }
                    if ((dataItem[i] & 1) == 1 && dataItem.Count==(i+1))
                    {
                        dataItem.Add(GetFixedLengthItem(1)[0]);
                        i++;
                    }
                    if ((dataItem[i] & 1) == 1 && dataItem.Count == (i + 1))
                    {
                        dataItem.Add(GetFixedLengthItem(1)[0]);
                    }
                    SetDataAges(dataItem);
                }
            }
        }



        public void SetDataSourceIdentifier(byte[] dataItem)
        {
            this.systemIdentificationCode = dataItem[1];
            this.systemAreaCode = dataItem[0];
        }
        private void SetGeometricHeight(byte[] dataItem)
        {
            double C2GeometricHeight = ConvertTwosComplementByteToDouble(dataItem);
            double resolution = 6.25; //In ft
            this.geometricHeight = C2GeometricHeight * resolution;
        }

        private void SetTimeOfMessageReceptionVelocityHighResolution(byte[] dataItem)
        {
            int len = dataItem.Length;
            byte mask = 63;
            int FSI = dataItem[0] >> 6;
            byte firstbyte = (byte)(dataItem[0] & mask);
            byte[] data = new byte[len];
            data[0] = firstbyte;

            for (int i = 1; i < len; i++)
            {
                data[i] = dataItem[i];
            }

            double resolution = Math.Pow(2, -30);//seconds
            double seconds = ComputeBytes(data, resolution);
            this.timeofMessageReceptionVelocityHighPrecision = TimeSpan.FromSeconds(seconds);


            switch (FSI)
            {
                case 0:
                    this.FSIVelocityHighPrecision = "TOMRp whole seconds=(I021/075) Whole seconds";
                    break;
                case 1:
                    this.FSIVelocityHighPrecision = "TOMRp whole seconds = (I021/075) Whole seconds+1";
                    break;
                case 2:
                    this.FSIVelocityHighPrecision = "TOMRp whole seconds = (I021/075) Whole seconds-1";
                    break;
                case 3:
                    this.FSIVelocityHighPrecision = "Reserved";
                    break;
            }
        }

        private void SetTimeOfMessageReceptionVelocity(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double seconds = ComputeBytes(dataItem, resolution);
            this.timeofMessageReceptionVelocity = TimeSpan.FromSeconds(seconds);
        }

        private void SetTimeOfMessageReceptionPositionHighPrecision(byte[] dataItem)
        {
            int len = dataItem.Length;
            byte mask = 63;
            int FSI = dataItem[0] >> 6;
            byte firstbyte = (byte)(dataItem[0] & mask);
            byte[] data = new byte[len];
            data[0] = firstbyte;

            for (int i = 1; i < len; i++)
            {
                data[i] = dataItem[i];
            }

            double resolution = Math.Pow(2, -30);//seconds
            double seconds = ComputeBytes(data, resolution);
            this.timeofMessageReceptionPositionHighPrecision = TimeSpan.FromSeconds(seconds);


            switch (FSI)
            {
                case 0:
                    this.FSIPositionHighPrecision = "TOMRp whole seconds=(I021/073) Whole seconds";
                    break;
                case 1:
                    this.FSIPositionHighPrecision = "TOMRp whole seconds = (I021/075) Whole seconds+1";
                    break;
                case 2:
                    this.FSIPositionHighPrecision = "TOMRp whole seconds = (I021/075) Whole seconds-1";
                    break;
                case 3:
                    this.FSIPositionHighPrecision = "Reserved";
                    break;
            }
        }

        private void SetTimeOfMessageReceptionPosition(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double seconds = ComputeBytes(dataItem, resolution);
            this.timeofMessageReceptionPosition = TimeSpan.FromSeconds(seconds);
        }

        private void SetTargetAdress(byte[] dataItem)
        {
            double resolution = 1;
            this.targetAddress = (int)ComputeBytes(dataItem, resolution);
        }

        private void SetTrueAirSpeed(byte[] dataItem)
        {
            double resolution = 1;
            byte mask = 127;
            int RE = ((dataItem[0]) >> 7);
            byte firstbyte = (byte)(dataItem[0] & mask);
            byte[] airspeed = { firstbyte, dataItem[1] };

            if (RE == 1)
            {
                this.reAirspeed = "Value exceeds defined range";
            }
            else if (RE == 0)
            {
                this.reAirspeed = "Value in defined range";
            }
            this.trueAirSpeed = ComputeBytes(airspeed, resolution);
        }

        private void SetAirSpeed(byte[] dataItem)
        {
            double resolution = 1;
            byte mask = 127;
            int IM = ((dataItem[0]) >> 7);
            byte firstbyte = (byte)(dataItem[0] & mask);
            byte[] airspeed = { firstbyte, dataItem[1] };


            if (IM == 1)
            {
                resolution = 0.001;
                this.IMairspeed = "MACH";
            }
            else if (IM == 0)
            {
                resolution = (2 ^ -14);
                this.IMairspeed = "IAS";
            }
            this.airspeed = ComputeBytes(airspeed, resolution);
        }

        private void SetPositionWGS84HighResolution(byte[] dataItem)
        {
            byte[] lat = new byte[4];
            byte[] longi = new byte[4];

            lat[0] = dataItem[0];
            lat[1] = dataItem[1];
            lat[2] = dataItem[2];
            lat[3] = dataItem[3];
            longi[0] = dataItem[4];
            longi[1] = dataItem[5];
            longi[2] = dataItem[6];
            longi[3] = dataItem[7];
            double latitude= ConvertTwosComplementByteToDouble(lat);
            double longitude= ConvertTwosComplementByteToDouble(longi);

            double resolution = 180 / Math.Pow(2, 30);
            this.latitudeWGS84high = latitude * resolution;
            this.longitudeWGS84high = longitude * resolution;
        }

        private void SetPositionWGS84(byte[] dataItem)
        {
            byte[] lat = new byte[3];
            byte[] longi = new byte[3];
            byte mask = 127;
            byte noSign = (byte)(dataItem[0] & mask);

            lat[0] = dataItem[0];
            lat[1] = dataItem[1];
            lat[2] = dataItem[2];
            longi[0] = dataItem[3];
            longi[1] = dataItem[4];
            longi[2] = dataItem[5];

            double latitude = ConvertTwosComplementByteToDouble(lat);
            double longitude = ConvertTwosComplementByteToDouble(longi);

            double resolution = 180 / Math.Pow(2, 23);
            this.latitudeWGS84 = latitude * resolution;
            this.longitudeWGS84 = longitude * resolution;
        }

        private void SetTimeOfApplicabilityPosition(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double time = ComputeBytes(dataItem, resolution);
            this.timeofApplicabilityPosition = TimeSpan.FromSeconds(time);
        }
        private void SetTimeOfApplicabilityVelocity(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double time = ComputeBytes(dataItem, resolution);
            this.timeofApplicabilityPosition = TimeSpan.FromSeconds(time);
        }

        private void SetServiceIdentification(byte[] dataItem)
        {
            this.serviceIdentification = dataItem[0];
        }

        private void SetTrackNumber(byte[] dataItem)
        {
            double resolution = 1;
            this.trackNumber = (int)ComputeBytes(dataItem, resolution);
        }

        private void SetTargetReport(byte[] dataItem)
        {
            if (dataItem.Length >= 1)
            {
                byte atpMask = 224;

                byte arcMask = 24;
                byte rcMask = 4;
                byte rabMask = 2;

                int atp = ((dataItem[0] & atpMask) >> 5);

                int arc = ((dataItem[0] & arcMask) >> 3);
                int rc = ((dataItem[0] & rcMask) >> 2);
                int rab = ((dataItem[0] & rabMask) >> 1);
                this.atp = "Address Type: ";
                this.arc = "Altitude Reporting Capability: ";
                this.rc = "Range Check: ";
                this.rab = "Report Type: ";
                switch (atp)
                {
                    
                    case 0:
                        this.atp+= "24-BIT ICAO address";
                        break;
                    case 1:
                        this.atp+= "Duplicate address";
                        break;
                    case 2:
                        this.atp+= "Surface vehicle address";
                        break;
                    case 3:
                        this.atp+= "Anonymous address";
                        break;
                    case 4:
                        this.atp+= "Reserved for future use";
                        break;
                    case 5:
                        this.atp+= "Reserved for future use";
                        break;
                    case 6:
                        this.atp+= "Reserved for future use";
                        break;
                    case 7:
                        this.atp+= "Reserved for future use";
                        break;
                }
                switch (arc)
                {
                    case 0:
                        this.arc+= "25 ft";
                        break;
                    case 1:
                        this.arc+= "100 ft";
                        break;
                    case 2:
                        this.arc+= "Unknown";
                        break;
                    case 3:
                        this.arc+= "Invalid";
                        break;
                }
                switch (rc)
                {
                    case 0:
                        this.rc+= "Default";
                        break;
                    case 1:
                        this.rc+= "Range Check passed, CPR Validation pending";
                        break;
                }
                switch (rab)
                {
                    case 0:
                        this.rab+= "Report from target transponder";
                        break;
                    case 1:
                        this.rab+= "Report from field monitor(fixed transponder)";
                        break;
                }
            }

            if (dataItem.Length >= 2)
            {
                byte dcrMask = 128;
                byte gbsMask = 64;
                byte simMask = 32;
                byte tstMask = 16;
                byte saaMask = 8;
                byte clMask = 6;

                int dcr = ((dataItem[1] & dcrMask) >> 7);
                int gbs = ((dataItem[1] & gbsMask) >> 6);
                int sim = ((dataItem[1] & simMask) >> 5);
                int tst = ((dataItem[1] & tstMask) >> 4);
                int saa = ((dataItem[1] & saaMask) >> 3);
                int cl = ((dataItem[1] & clMask) >> 1);
                this.tst = "Test Target: ";
                this.cl = "Confidence Level: ";
                switch (dcr)
                {
                    case 0:
                        this.dcr = "No differential correction(ADS-B)";
                        break;
                    case 1:
                        this.dcr = "Differential correction(ADS-B)";
                        break;
                }
                switch (gbs)
                {
                    case 0:
                        this.gbs = "Ground Bit not set";
                        break;
                    case 1:
                        this.gbs = "Ground bit set";
                        break;
                }
                switch (sim)
                {
                    case 0:
                        this.sim = "Actual target report";
                        break;
                    case 1:
                        this.sim = "Simulated target report";
                        break;
                }
                switch (tst)
                {
                    case 0:
                        this.tst+= "Default";
                        break;
                    case 1:
                        this.tst+= "Test Target";
                        break;
                }
                switch (saa)
                {
                    case 0:
                        this.saa = "Equipment capable to provide Selected Altitude";
                        break;
                    case 1:
                        this.saa = "Equipment not capable to provide Selected Altitude";
                        break;
                }

                switch (cl)
                {
                    case 0:
                        this.cl+= "Report Valid";
                        break;
                    case 1:
                        this.cl+= "Report suspect";
                        break;
                    case 2:
                        this.cl+= "No information";
                        break;
                    case 3:
                        this.cl+= "Reserved for future use";
                        break;
                }
            }
            if (dataItem.Length >= 3)
            {
                byte ipcMask = 32;
                byte nogoMask = 16;
                byte cprMask = 8;
                byte ldpjMask = 4;
                byte rcfMask = 2;
                int ipc = ((dataItem[2] & ipcMask) >> 5);
                int nogo = ((dataItem[2] & nogoMask) >> 4);
                int cpr = ((dataItem[2] & cprMask) >> 3);
                int ldpj = ((dataItem[2] & ldpjMask) >> 2);
                int rcf = ((dataItem[2] & rcfMask) >> 1);

                this.ipc = "Independent Position Check: ";
                this.rcf = "Range Check: ";

                switch (ipc)
                {
                    case 0:
                        this.ipc+= "Default";
                        break;
                    case 1:
                        this.ipc+= "Independent Position Check failed";
                        break;
                }
                switch (nogo)
                {
                    case 0:
                        this.nogo = "NOGO-bit not set";
                        break;
                    case 1:
                        this.nogo = "NOGO-bit set";
                        break;
                }
                switch (cpr)
                {
                    case 0:
                        this.cpr = "CPR Validation correct";
                        break;
                    case 1:
                        this.cpr = "CPR Validation failed";
                        break;
                }
                switch (ldpj)
                {
                    case 0:
                        this.ldpj = "LDPJ not detected";
                        break;
                    case 1:
                        this.ldpj = "LDPJ detected";
                        break;
                }
                switch (rcf)
                {
                    case 0:
                        this.rcf+= "Default";
                        break;
                    case 1:
                        this.rcf+= "Range Check failed";
                        break;
                }
            }

        }
        private void SetQualityIndicators(byte[] dataItem)
        {
            int len = dataItem.Length;
            if (len >= 1)
            {
                byte nucpmask = 30;

                this.nucr = dataItem[0] >> 5;
                this.nucp = ((dataItem[0] & nucpmask) >> 1);
            }
            if (len >= 2)
            {
                byte silmask = 96;
                byte nacpmask = 30;
                this.nicbaro = dataItem[1] >> 7;
                this.sil = (dataItem[1] & silmask) >> 5;
                this.nacp = (dataItem[1] & nacpmask) >> 1;
            }
            if (len >= 3)
            {
                byte sdamask = 24;
                byte gvamask = 6;

                this.silSupplement = dataItem[2] >> 5;
                this.sda = (dataItem[2] & sdamask) >> 3;
                this.gva = (dataItem[2] & gvamask) >> 1;

            }
            if (len >= 4)
            {
                this.pic = dataItem[3] >> 4;

            }
        }
        private void SetMOPSVersion(byte[] dataItem)
        {
            byte vnsMask = 64;
            byte vnMask = 56;
            byte lttMask = 7;
            int vns = (dataItem[0] & vnsMask) >> 6;
            int vn = (dataItem[0] & vnMask) >> 3;
            int ltt = dataItem[0] & lttMask;

            switch (vns)
            {
                case 0:
                    this.mopsVNS = "The MOPS Version is supported by the GS";
                    break;
                case 1:
                    this.mopsVNS = "The MOPS Version is not supported by the GS";
                    break;

            }
            switch (vn)
            {
                case 0:
                    this.mopsVN = "ED102/DO-260";
                    break;
                case 1:
                    this.mopsVN = "DO-260A";
                    break;
                case 2:
                    this.mopsVN = "ED102A/DO-260B";
                    break;

            }

            switch (ltt)
            {
                case 0:
                    this.mopsLTT = "Other";
                    break;
                case 1:
                    this.mopsLTT = "UAT";
                    break;
                case 2:
                    this.mopsLTT = "1090 ES";
                    break;
                case 3:
                    this.mopsLTT = "VDL 4";
                    break;
                default:
                    this.mopsLTT = "Not assigned";
                    break;
            }
        }
        private void SetMode3ACode(byte[] dataItem)
        {
            int firstByte = (byte)(dataItem[0]);
            int B4mask=1;
            int B21mask=192;
            int Cmask=56;
            int Dmask=7;
            int A = (byte)(firstByte >> 1);
            byte B4 = (byte)((firstByte & B4mask) << 2);
            byte B21 = (byte)((dataItem[1] & B21mask) >> 6);
            int B = (int)(B4 + B21);
            int C = (int)((dataItem[1] & Cmask) >> 3);
            int D = (int)(dataItem[1] & Dmask);

            this.m3ACode = Convert.ToString(A * 1000 + B * 100 + C * 10 + D);
        }
        private void SetRollAngle(byte[] dataItem)
        {
            double resolution = 0.01;//degrees
            this.rollAngle = ConvertTwosComplementByteToDouble(dataItem)*resolution;
        }
        private void SetFlightLevel(byte[] dataItem)
        {
            double resolution = (1.0 / 4.0);
            this.flightLevel = ConvertTwosComplementByteToDouble(dataItem)*resolution;
        }
        private void SetMagneticHeading(byte[] dataItem)
        {
            double resolution = (360 / Math.Pow(2,16));
            this.magneticHeading = ComputeBytes(dataItem, resolution);
        }

        private void SetTargetStatus(byte[] dataItem)
        {

            byte lnavMask = 64;
            byte psMask = 28;
            byte ssMask = 3;

            int icf = dataItem[0] >> 7;

            int lnav = (dataItem[0] & lnavMask) >> 6;
            int ps = (dataItem[0] & psMask) >> 2;
            int ss = dataItem[0] & ssMask;

            switch (icf)
            {
                case 0:
                    this.icf = "No intent change active";
                    break;
                case 1:
                    this.icf = "Intent change flag raised ";
                    break;
            }
            switch (lnav)
            {
                case 0:
                    this.lnav = "LNAV Mode engaged";
                    break;
                case 1:
                    this.lnav = "LNAV Mode not engaged";
                    break;
            }
            switch (ps)
            {
                case 0:
                    this.ps = "No emergency / not reported";
                    break;
                case 1:
                    this.ps = "General emergency";
                    break;
                case 2:
                    this.ps = "Lifeguard / medical emergency";
                    break;
                case 3:
                    this.ps = "Minimum fuel";
                    break;
                case 4:
                    this.ps = "No communications";
                    break;
                case 5:
                    this.ps = "Unlawful interference";
                    break;
                case 6:
                    this.ps = "“Downed” Aircraft ";
                    break;
                case 7:
                    this.ps = "N/A";
                    break;
            }
            switch (ss)
            {
                case 0:
                    this.ss = "No condition reported";
                    break;
                case 1:
                    this.ss = "Permanent Alert";
                    break;
                case 2:
                    this.ss = "Temporary Alert";
                    break;
                case 3:
                    this.ss = "SPI set";
                    break;
            }
        }

        private void SetBarometricVerticalRate(byte[] dataItem)
        {
            double resolution = 6.25;//feet/min
            int len = 15;
            byte mask = 127;
            int RE = ((dataItem[0]) >> 7);
            byte firstbyte = (byte)(dataItem[0] & mask);
            byte[] barometric = { firstbyte, dataItem[1] };

            if (RE == 1)
            {
                this.reBVR = "Value exceeds defined range";
            }
            else if (RE == 0)
            {
                this.reBVR = "Value in defined range";
            }
            this.barometricVerticalRate = ConvertTwosComplementGeneralByteToDouble(barometric,len,resolution);
        }
        private void SetGeometricVerticalRate(byte[] dataItem)
        {
            double resolution = 6.25;//feet/min
            int len = 15;
            byte mask = 127;
            int RE = ((dataItem[0]) >> 7);
            byte firstbyte = (byte)(dataItem[0] & mask);
            byte[] geometric = { firstbyte, dataItem[1] };

            if (RE == 1)
            {
                this.reGVR = "Value exceeds defined range";
            }
            else if (RE == 0)
            {
                this.reGVR = "Value in defined range";
            }
            this.geometricVerticalRate = ConvertTwosComplementGeneralByteToDouble(geometric,len,resolution);
        }
        private void SetAirborneGroundVector(byte[] dataItem)
        {
            double resolutionSpeed = 0.22;
            double resolutionAngle = 360 / Math.Pow(2, 16);
            byte mask = 127;
            int RE = dataItem[0] >> 7;
            byte firstbyte = (byte)(dataItem[0] & mask);
            byte[] groundspeed= { firstbyte, dataItem[1] };
            byte[] trackangle = { dataItem[2], dataItem[3] };

            if (RE == 1)
            {
                this.reAirborneGroundVector = "Value exceeds defined range";
            }
            else if (RE == 0)
            {
                this.reAirborneGroundVector = "Value in defined range";
            }
            this.groundSpeed = ComputeBytes(groundspeed, resolutionSpeed);
            this.trackAngle= ComputeBytes(trackangle, resolutionAngle);
        }

        private void SetTrackAngleRate(byte[] dataItem)
        {
            double resolution = 1.0 / 32.0;
            int len = 10;
            this.trackAngleRate=ConvertTwosComplementGeneralByteToDouble(dataItem,len,resolution);
        }
        private void SetTimeOfReportTransmission(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double seconds = ConvertTwosComplementByteToDouble(dataItem)*resolution;
            this.timeOfReportTransmission = TimeSpan.FromSeconds(seconds);
        }

        private void SetTargetIdentification(byte[] dataItem)
        {
            byte char1 = (byte)((dataItem[0] & 252) >> 2);
            byte char2 = (byte)(((dataItem[1] & 240) >> 4) + ((dataItem[0] & 3) << 4));
            byte char3 = (byte)(((dataItem[2] & 192) >> 6) + ((dataItem[1] & 15) << 2));
            byte char4 = (byte)((dataItem[2] & 63));
            byte char5 = (byte)((dataItem[3] & 252) >> 2);
            byte char6 = (byte)(((dataItem[4] & 240) >> 4) + ((dataItem[3] & 3) << 4));
            byte char7 = (byte)(((dataItem[5] & 192) >> 6) + ((dataItem[4] & 15) << 2));
            byte char8 = (byte)((dataItem[5] & 63));
            
            byte[] chars = { char1, char2, char3, char4, char5, char6, char7, char8 };
            Dictionary<byte, char> targetID = new Dictionary<byte, char>
            {
                {0,' '},{1,'A'},{2,'B'}, {3,'C'},{4,'D'},{5,'E'},{6,'F'},{7,'G'},{8,'H'},{9,'I'},{10,'J'},
                {11,'K'},{12,'L'},{13,'M'},{14,'N'},{15,'O'},{16,'P'},{17,'Q'},{18,'R'},{19,'S'},{20,'T'},
                {21,'U'},{22,'V'},{23,'W'},{24,'X'},{25,'Y'},{26,'Z'},{27,'*'},{28,'*'},{29,'*'},{30,'*'},{31,'*'},
                {32,' '},{33,'*'},{34,'*'},{35,'*'},{36,'*'},{37,'*'},{38,'*'},{39,'*'},{40,'*'},{41,'*'},{42,'*'},{43,'*'},
                {44,'*'},{45,'*'},{46,'*'},{47,'*'},
                {48,'0'},{49,'1'},{50,'2'},{51,'3'},{52,'4'},{53,'5'},{54,'6'},{55,'7'},{56,'8'},
                {57,'9'},{58,'*'},{59,'*'},{60,'*'},{61,'*'},{62,'*'},{63,'*'},
            };
            int i = 0;
            string id = "";
            while (i < chars.Length)
            {
                id += targetID[chars[i]];
                i++;
            }
            this.targetIdentification = id;

        }
        private void SetEmitterCategory(byte[] dataItem)
        {
           
            int ECAT = dataItem[0];


            switch (ECAT)
            {
                case 0:
                    this.emitterCategory = "No ADS-B Emitter Category Information";
                    break;
                case 1:
                    this.emitterCategory = "Light aircraft";
                    break;
                case 2:
                    this.emitterCategory = "Small aircraft";
                    break;
                case 3:
                    this.emitterCategory = "Medium aircraft";
                    break;
                case 4:
                    this.emitterCategory = "High Vortex Large";
                    break;
                case 5:
                    this.emitterCategory = "Heavy aircraft";
                    break;
                case 6:
                    this.emitterCategory = "Highly manoeuvrable (5g acceleration capability) and high speed(> 400 knotscruise)";
                    break;
                case 7:
                    this.emitterCategory = "Reserved";
                    break;
                case 8:
                    this.emitterCategory = "Reserved";
                    break;
                case 9:
                    this.emitterCategory = "Reserved";
                    break;
                case 10:
                    this.emitterCategory = "Rotocraft";
                    break;
                case 11:
                    this.emitterCategory = "Glider / Sailplane";
                    break;
                case 12:
                    this.emitterCategory = "Lighter-than-air";
                    break;
                case 13:
                    this.emitterCategory = "Unmanned aerial vehicle";
                    break;
                case 14:
                    this.emitterCategory = "Space / Transatmospheric vehicle";
                    break;

                case 15:
                    this.emitterCategory = "Ultralight / Handglider / Paraglider";
                    break;

                case 16:
                    this.emitterCategory = "Parachutist / Skydiver";
                    break;

                case 17:
                    this.emitterCategory = "Reserved";
                    break;

                case 18:
                    this.emitterCategory = "Reserved";
                    break;

                case 19:
                    this.emitterCategory = "Reserved";
                    break;

                case 20:
                    this.emitterCategory = "Surface emergency vehicle";
                    break;

                case 21:
                    this.emitterCategory = "Surface service vehicle";
                    break;

                case 22:
                    this.emitterCategory = "Fixed ground or tethered obstruction";
                    break;

                case 23:
                    this.emitterCategory = "Cluster obstacle";
                    break;

                case 24:
                    this.emitterCategory = "Line obstacle";
                    break;

            }

        }
        private void SetMetInformation(byte[] dataItem, int ws, int wd, int tmp, int trb)
        {

            int index = 0;
            if (ws == 1)
            {
                double resolucion = 1;
               
                byte[] windspeedbyte = { dataItem[index+1], dataItem[index+2] };
                this.windspeed = ComputeBytes(windspeedbyte, resolucion);
                index = index + 2;
            }
            if (wd == 1)
            {
                double resolucion = 1;

                byte[] windsDirectionbyte = { dataItem[index+1], dataItem[index + 2] };
                this.windDirection = ComputeBytes(windsDirectionbyte, resolucion);
                index = index + 2;
            }
            if (tmp == 1)
            {
                double resolution = 0.25;

                byte[] windsDirectionbyte = { dataItem[index + 1], dataItem[index + 2] };
                this.temperature = ConvertTwosComplementGeneralByteToDouble(windsDirectionbyte, 16, resolution);
                index = index + 2;
            }
            if (trb == 1)
            {
                double resolution = 1;
               
                byte[] turbulencebyte = { (dataItem[index + 1]) } ;
                this.turbulence = ComputeBytes(turbulencebyte, resolution);
            }

            this.metInformation[0] = Convert.ToString(this.windspeed);
            this.metInformation[1] = Convert.ToString(this.windDirection);
            this.metInformation[2] = Convert.ToString(this.temperature);
            this.metInformation[3] = Convert.ToString(this.turbulence);

        }
        private void SetSelectedAltitude(byte[] dataItem)
        {
            double resolution = 25;//ft
            int valueSAS = dataItem[0] >> 7;
            int sourceMask = 96;
            int valueSource = (dataItem[0] & sourceMask) >> 5;
            byte firstbyte = (byte)(dataItem[0] & 31);
            byte[] altitude = { firstbyte, dataItem[1]};
            this.selectedAltitude = ConvertTwosComplementGeneralByteToDouble(altitude, 13, resolution);

            switch (valueSAS)
            {
                case 0:
                    this.sas = "No source information provided";
                    break;
                case 1:
                    this.sas = "Source information provided";
                    break;
            }
            switch (valueSource)
            {
                case 0:
                    this.source = "Unknown";
                    break;
                case 1:
                    this.source = "Aircraft Altitude";
                    break;
                case 2:
                    this.source = "MCP/FCU Selected Altitude";
                    break;
                case 3:
                    this.source = "FMS Selected Altitude";
                    break;
            }

        }

        private void SetFinalStateSelectedAltitude(byte[] dataItem)
        {

            byte AHMAsk = 64;
            byte AMMask = 32;

            
            int Valuemv = dataItem[1] >> 7;
            int Valueah = (dataItem[1] & AHMAsk) >> 6;
            int Valueam = (dataItem[1] & AMMask) >> 5;
            switch (Valuemv)
            {
                case 0:
                    this.mv = "Not active or unknown";
                    break;
                case 1:
                    this.mv = "Active";
                    break;
            }
            switch (Valueah)
            {
                case 0:
                    this.ah = "Not active or unknown";
                    break;
                case 1:
                    this.ah = "Active";
                    break;
            }
            switch (Valueam)
            {
                case 0:
                    this.am = "Not active or unknown";
                    break;
                case 1:
                    this.am = "Active";
                    break;
            }

            double resolution = 25;//ft
            byte secondbyte = (byte)(dataItem[1] & 31);
            byte[] altitude = { dataItem[0], secondbyte };
            this.finalStateSelectedAltitude = ConvertTwosComplementGeneralByteToDouble(altitude, 13, resolution);

        }
        private void SetTrajectoryIntent(byte[] dataItem)
        {
            byte tisMask = 128;
            byte tidMask = 64;

            int tis = ((tisMask & dataItem[0]) >> 7);
            int tid = ((tidMask & dataItem[0]) >> 6);
        }


        private void SetServiceManagement(byte[] dataItem)
        {
            double resolution = 0.5;//sec
            double service = ComputeBytes(dataItem, resolution);
            if (service >= 127.5)
            {
                this.serviceManagement = 127.5;
            }
            else
                this.serviceManagement = service;
            
        }
        private void SetAircraftOperationalStatus(byte[] dataItem)
        {

            byte TCMask = 96;
            byte TSMask = 16;
            byte ARVMask = 8;
            byte CDTIAMask = 4;
            byte notTICASMask = 2;
            byte SAMask = 1;

            int RA = dataItem[0] >> 7;
            int TC = (dataItem[0] & TCMask) >> 5;
            int TS = (dataItem[0] & TSMask) >> 4;
            int ARV = (dataItem[0] & ARVMask) >> 3;
            int CDTIA = (dataItem[0] & CDTIAMask) >> 2;
            int notTICAS = (dataItem[0] & notTICASMask) >> 1;
            int SA = (dataItem[0] & SAMask);

            switch (RA)
            {
                case 0:
                    this.ra = "TCAS II or ACAS RA not active";
                    break;
                case 1:
                    this.ra = "TCAS RA active";
                    break;


            }
            switch (TC)
            {
                case 0:
                    this.tc = "No capability for Trajectory Change Reports ";
                    break;
                case 1:
                    this.tc = "Support for TC+0 reports only ";
                    break;
                case 2:
                    this.tc = "Support for multiple TC reports";
                    break;
                case 3:
                    this.tc = "Target Trajectory Change Report Capability: Reserved";
                    break;


            }

            switch (TS)
            {
                case 0:
                    this.ts = "No capability to support Target State Report";
                    break;
                case 1:
                    this.ts = "Capable of supporting target State Reports ";
                    break;


            }
            switch (ARV)
            {
                case 0:
                    this.arv = "No capability to generate ARV-reports";
                    break;
                case 1:
                    this.arv = "Capable of generate ARV-reports  ";
                    break;


            }
            switch (CDTIA)
            {
                case 0:
                    this.cdtia = "CDTI not operational";
                    break;
                case 1:
                    this.cdtia = "CDTI operational";
                    break;


            }
            switch (notTICAS)
            {
                case 0:
                    this.notticas = "TCAS operational ";
                    break;
                case 1:
                    this.notticas = "TCAS not operational";
                    break;


            }
            switch (SA)
            {
                case 0:
                    this.sa = "Antenna Diversity ";
                    break;
                case 1:
                    this.sa = "Single Antenna only ";
                    break;


            }

        }
        private void SetsurfaceCapabilitiesandCharacteristics(byte[] dataItem)
        {
            byte POAMask = 32;
            byte CDTISMask = 16;
            byte B2lowMask = 8;
            byte RASMask = 4;
            byte IDENTMask = 2;



            int poavalue = (dataItem[0] & POAMask) >> 5;
            int cdtisvalue = (dataItem[0] & CDTISMask) >> 4;
            int b2lowvalue = (dataItem[0] & B2lowMask) >> 3;
            int rasvalue = (dataItem[0] & RASMask) >> 2;
            int identvalue = (dataItem[0] & IDENTMask) >> 1;


            switch (poavalue)
            {
                case 0:
                    this.poa = "Position transmitted is not ADS-B position reference point";
                    break;
                case 1:
                    this.poa = "Position transmitted is the ADS-B position reference point";
                    break;
            }
            switch (cdtisvalue)
            {
                case 0:
                    this.cdtis = "CDTI not operational";
                    break;
                case 1:
                    this.cdtis = "CDTI operational ";
                    break;
            }
            switch (b2lowvalue)
            {
                case 0:
                    this.b2low = "Class B2 transmit power ≥ 70 Watts ";
                    break;
                case 1:
                    this.b2low = "Class B2 transmit power < 70 Watts ";
                    break;
            }
            switch (rasvalue)
            {
                case 0:
                    this.ras = "Aircraft not receiving ATC-services ";
                    break;
                case 1:
                    this.ras = "Aircraft receiving ATC services";
                    break;
            }
            switch (identvalue)
            {
                case 0:
                    this.ident = "IDENT switch not active";
                    break;
                case 1:
                    this.ident = "IDENT switch active ";
                    break;
            }

            if (dataItem.Length >= 2)
            {
                byte LplusWMask = 15;
                byte[] LplusWValue = { (byte)(dataItem[1] & LplusWMask) };
                double LplusW  = ComputeBytes(LplusWValue, 1);

                switch (LplusW)
                {
                    case 0:
                        this.widthv1 = "Width < 11.5";
                        this.lengthv1 = "Length < 15";
                        break;
                    case 1:
                        this.widthv1 = "Width < 23";
                        this.lengthv1 = "Length < 15";
                        break;
                    case 2:
                        this.widthv1 = "Width < 28.5";
                        this.lengthv1 = "Length < 25 ";
                        break;
                    case 3:
                        this.widthv1 = "Width < 34";
                        this.lengthv1 = "Length < 25 ";
                        break;
                    case 4:
                        this.widthv1 = "Width < 33";
                        this.lengthv1 = "Length < 35 ";
                        break;
                    case 5:
                        this.widthv1 = "Width < 38";
                        this.lengthv1 = "Length < 35 ";
                        break;
                    case 6:
                        this.widthv1 = "Width < 39.5";
                        this.lengthv1 = "Length < 45 ";
                        break;
                    case 7:
                        this.widthv1 = "Width < 45";
                        this.lengthv1 = "Length < 45 ";
                        break;
                    case 8:
                        this.widthv1 = "Width <45";
                        this.lengthv1 = "Length < 55 ";
                        break;
                    case 9:
                        this.widthv1 = "Width < 52";
                        this.lengthv1 = "Length < 55 ";
                        break;
                    case 10:
                        this.widthv1 = "Width <59.5";
                        this.lengthv1 = "Length < 65 ";
                        break;
                    case 11:
                        this.widthv1 = "Width < 67";
                        this.lengthv1 = "Length < 65 ";
                        break;
                }

            }
        }
        
        private void SetMessageAmplitude(byte[] dataItem)
        {
            double resolution = 1;//dBm
            this.messageAmplitude = ConvertTwosComplementByteToDouble(dataItem) * resolution;
            
        }
       
        private void SetReceiverID(byte[] dataItem)
        {
            double resolution = 1;//sec
            this.receiverID = ComputeBytes(dataItem, resolution);
        }

        private void SetDataAges(List<byte> dataItem)
        {
            byte[] fieldE = dataItem.ToArray();
            BitArray boolFSPEC = new BitArray(fieldE);
            double resolution = 0.1;
            if (fieldE.Length >= 1)
            {
                if (boolFSPEC[7] == true) 
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.aos=Convert.ToString(ComputeBytes(data,resolution));
                }
                if (boolFSPEC[6] == true) 
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.trd = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[5] == true) 
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.m3a = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[4] == true) 
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.qi = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[3] == true) 
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.ti = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[2] == true) 
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.mam = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[1] == true) 
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.gh = Convert.ToString(ComputeBytes(data, resolution));
                }
            }
            if (fieldE.Length >= 2)
            {
                if (boolFSPEC[7] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.fl = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[6] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.isa = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[5] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.fsa = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[4] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.asage = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[3] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.tas = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[2] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.mh = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[1] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.bvr = Convert.ToString(ComputeBytes(data, resolution));
                }
            }
            if (fieldE.Length >= 3)
            {
                if (boolFSPEC[7] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.gvr = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[6] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.gv = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[5] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.tar = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[4] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.ti2 = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[3] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.tsage = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[2] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.met = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[1] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.roa = Convert.ToString(ComputeBytes(data, resolution));
                }
            }
            if (fieldE.Length >= 4)
            {
                if (boolFSPEC[7] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.ara = Convert.ToString(ComputeBytes(data, resolution));
                }
                if (boolFSPEC[6] == true)
                {
                    byte[] data = GetFixedLengthItem(1);
                    this.scc = Convert.ToString(ComputeBytes(data, resolution));
                }

            }
        }

        private void SetACASResolution(byte[] dataItem)
        {
            this.acasResolution = "Not Available";
        }

        private void SetModeSMBData(byte[] dataItem)
        {
            this.modeSMbData = "Not Available";
        }
        private double ComputeBytes(byte[] dataItem, double resolution)
        {
            double value = 0;
            int len = dataItem.Length;
            for (int i = 0; i < len; i++)
            {
                value = value + dataItem[i] * Math.Pow(2, 8 * (len - i - 1));
            }
            value = value * resolution;
            return value;
        }

        private double ConvertTwosComplementByteToDouble(byte[] ByteVect)
        {

            double ValueDec =double.NaN;
            int len = ByteVect.Length;
            if ((ByteVect[0] & 0x80) == 0)  
            {
                ValueDec = ComputeBytes(ByteVect, 1); 
            }
            else 
            {
                for (int i = 0; i < len; i++)
                {
                    ByteVect[i] = (byte)~(ByteVect[i]);
                }
                ValueDec = ComputeBytes(ByteVect, 1) ;
                ValueDec = (ValueDec+1)*-1;
                
            }
            return ValueDec;
        }

        private double ConvertTwosComplementGeneralByteToDouble(byte[] ByteVect, int bits, double res)
        {
            int length= ByteVect.Length;
            int exp = Convert.ToInt32((bits - (length - 1) * 8) - 1);
            int mask = Convert.ToInt32(Math.Pow(2, exp));
            double ValueDec;
            if ((ByteVect[0] & mask) == 0)
            {
                ValueDec = ComputeBytes(ByteVect, 1);
            }
            else
            {
                double value=ComputeBytes(ByteVect, 1);
                ValueDec = (Math.Pow(2, bits) - value) * -1;
            }
            return ValueDec*res;
        }
    }

}
