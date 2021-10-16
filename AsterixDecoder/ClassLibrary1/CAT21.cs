using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class CAT21
    {
        //Initialization
        byte[] arraystring;
        List<byte> data;
        int length;

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
        string rangeExceeded;//Airspeed
        int targetAddress;
        TimeSpan timeofMessageReceptionPosition;
        string FSIPositionHighPrecision;
        string FSIVelocityHighPrecision;
        TimeSpan timeofMessageReceptionPositionHighPrecision;
        TimeSpan timeofMessageReceptionVelocity;
        TimeSpan timeofMessageReceptionVelocityHighPrecision;



        int[] GeometricHeight = new int[3];
        int[] QualityIndicators = new int[3];
        int[] MOPSVersion = new int[3];
        int[] Mode3ACode = new int[3];
        int[] RollAngle = new int[3];
        int[] FlightLevel = new int[3];

        int[] MagneticHeading = new int[3];
        int[] TargetStatus = new int[3];
        int[] BarometricVerticalRate = new int[3];
        int[] GeometricVerticalRate = new int[3];
        int[] AirborneGroundVector = new int[3];
        int[] TrackAngleRate = new int[3];
        int[] TimeofReportTransmission = new int[3];

        int[] TargetIdentification = new int[3];
        int[] EmitterCategory = new int[3];
        int[] MetInformation = new int[3];
        int[] SelectedAltitude = new int[3];
        int[] FinalStateSelectedAltitude = new int[3];
        int[] TrajectoryIntent = new int[3];
        int[] ServiceManagement = new int[3];

        int[] AircraftOperationalStatus = new int[3];
        int[] SurfaceCapabilitiesandCharacteristics = new int[3];
        int[] MessageAmplitude = new int[3];
        int[] ModeSMBData = new int[3];
        int[] ACASResolutionAdvisoryReport = new int[3];
        int[] ReceiverID = new int[3];
        int[] DataAges = new int[3];

        int[] ReservedExpansionField = new int[3];
        int[] SpecialPurposeField = new int[3];
        


        public CAT21(byte[] arraystring)
        {
            this.arraystring = arraystring;
            this.length = -1;
            this.data = new List<byte>();
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
            this.latitudeWGS84= double.NaN;
            this.longitudeWGS84= double.NaN;

            this.latitudeWGS84high=double.NaN;
            this.longitudeWGS84high=double.NaN;

            this.timeofApplicabilityVelocity = new TimeSpan();
            //Airspeed
            this.airspeed=double.NaN;
            this.IMairspeed = "N/A";
            this.trueAirSpeed= double.NaN;
            this.rangeExceeded = "N/A";

            this.targetAddress = -1;
            this.timeofMessageReceptionPosition = new TimeSpan();
            this.FSIPositionHighPrecision="N/A";
            this.timeofMessageReceptionPositionHighPrecision= new TimeSpan();
            this.timeofMessageReceptionVelocity=new TimeSpan();
            this.FSIVelocityHighPrecision = "N/A";
            this.timeofMessageReceptionVelocityHighPrecision=new TimeSpan();
            


            data.RemoveAt(0);
            data.RemoveAt(0);
            data.RemoveAt(0);
            byte[] FSPECNew = GetFSPEC();

            this.SetDataItems();
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
        public int HexToDec(string hexValue)
        {
            int intValue = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            return intValue;
        }

        public string HextoBin(string hexValue)
        {
            string binValue= "";
            binValue = Convert.ToString(Convert.ToInt32(hexValue, 16), 2);
            return binValue;
        }

        public byte[] GetFSPEC() //Obtiene el FSPEC y lo separa del array mensaje
        {
            int moreFSPEC = 1;
            byte lastBitCheck = 1;
            List<byte> FSPEC = new List<byte>();
            while (moreFSPEC == 1)
            {
                
                if ((data[0] & lastBitCheck)!=0)
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
            for (int i=0; i<length; i++)
            {
                dataItem[i] = this.data[0];
                data.RemoveAt(0);
            }
            return dataItem;
        }

        public byte[] GetVariableLengthItem()
        {
            int moreByte = 1;
            List<byte> dataItem = new List<byte>();
            dataItem.Add(this.data[0]);
            data.RemoveAt(0);
            byte lastBitCheck = 1;
            while (moreByte==1)
            {
                if ((data[0] & lastBitCheck)!= 0)
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

        public void SetDataSourceIdentifier(byte[] dataItem)
        {
            this.systemIdentificationCode = dataItem[1];
            this.systemAreaCode = dataItem[0];
        }
        public void SetDataItems()
        {
            BitArray boolFSPEC = new BitArray(this.FSPEC);
            if (FSPEC.Length>=1)
            {
                if (boolFSPEC[0]==true) //Data Source Identifier
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetDataSourceIdentifier(dataItem);
                }
                if (boolFSPEC[1] == true) //Target Report
                {
                    byte[] dataItem = GetVariableLengthItem();
                    SetTargetReport(dataItem);

                }
                if (boolFSPEC[2] == true) //Track Number
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetTrackNumber(dataItem);
                }
                if (boolFSPEC[3] == true) //Service Identification
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetServiceIdentification(dataItem);
                }
                if (boolFSPEC[4] == true) //Time of Applicability for Position
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfApplicabilityPosition(dataItem);
                }
                if (boolFSPEC[5] == true) //Position WGS84 
                {
                    byte[] dataItem = GetFixedLengthItem(6);
                    SetPositionWGS84(dataItem);
                }
                if (boolFSPEC[6] == true) //Position WGS84 High Resolution
                {
                    byte[] dataItem = GetFixedLengthItem(8);
                    SetPositionWGS84HighResolution(dataItem);
                }
            }
            if (FSPEC.Length >= 2)
            {
                if (boolFSPEC[8] == true) //Time of Applicability for Velocity
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfApplicabilityVelocity(dataItem);
                }
                if (boolFSPEC[9] == true) //Air Speed
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetAirSpeed(dataItem);

                }
                if (boolFSPEC[10] == true) //True Air Speed
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetTrueAirSpeed(dataItem);
                }
                if (boolFSPEC[11] == true) //TargetAdress
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTargetAdress(dataItem);
                }
                if (boolFSPEC[12] == true) //Time of message reception Position
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfMessageReceptionPosition(dataItem);
                }
                if (boolFSPEC[13] == true) //Time of message reception Position High Precision
                {
                    byte[] dataItem = GetFixedLengthItem(4);
                    SetTimeOfMessageReceptionPositionHighPrecision(dataItem);
                }
                if (boolFSPEC[14] == true) //Time of message reception Velocity
                {
                    byte[] dataItem = GetFixedLengthItem(3);
                    SetTimeOfMessageReceptionVelocity(dataItem);

                }
            }
            if (FSPEC.Length >= 3)
            {
                if (boolFSPEC[16] == true) //Time of message reception Velocity High Resolution
                {
                    byte[] dataItem = GetFixedLengthItem(4);
                    SetTimeOfMessageReceptionVelocityHighResolution(dataItem);
                }
                if (boolFSPEC[17] == true) //Geometric Height
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetGeometricHeight(dataItem);
                }
                if (boolFSPEC[18] == true) //Quality Indicators
                {
                    byte[] dataItem = GetVariableLengthItem();
                    SetQualityIndicators(dataItem);
                }
                //if (boolFSPEC[19] == true) //MOPS Version
                //{
                //    byte[] dataItem = GetFixedLengthItem(1);
                //    SetMOPSVersion(dataItem);
                //}
                //if (boolFSPEC[20] == true) //Mode 3/A Code
                //{
                //    byte[] dataItem = GetFixedLengthItem(2);
                //    SetMode3ACode(dataItem);
                //}
                //if (boolFSPEC[21] == true) //Roll Angle
                //{
                //    byte[] dataItem = GetFixedLengthItem(2);
                //    SetRollAngle(dataItem);
                //}
                //if (boolFSPEC[22] == true) //Flight Level
                //{
                //    byte[] dataItem = GetFixedLengthItem(2);
                //    SetFlightLevel(dataItem);
                //}
            }
        }

        private void SetQualityIndicators(byte[] dataItem)//Aixo no se com fer-ho
        {
            int len = dataItem.Length;
            if (len>=1)
            {
                byte nucpmask = 30;

                int nucr = dataItem[0] >> 5;
                int nucp = ((dataItem[0] & nucpmask) >> 1);
            }
            //if (len >= 2)
            //{ 
            //}
            //if (len >= 3)
            //{

            //}
            //if (len >= 4)
            //{

            //}
        }

        private void SetGeometricHeight(byte[] dataItem)//Hay que hacer el twos complement pero no entiendo como se hace
        {
            double resolution = 6.25; //In ft
            
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

            for (int i=1; i<len;i++)
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
                this.rangeExceeded = "Value exceeds defined range";
            }
            else if (RE == 0)
            {
                this.rangeExceeded = "Value in defined range";
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

        private void SetPositionWGS84HighResolution(byte[] dataItem)//Twos complement no se hacerlo
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


            bool latnegative = false;
            bool longinegative = false;
            if (lat[0] > 127)
                latnegative = true;
            if (longi[0] > 127)
                longinegative = true;
            double latitude = lat[0] * Math.Pow(2, 24) +lat[1] * 65536 + lat[2] * 256 + lat[3];
            Console.WriteLine("Latitude real: " + lat[0]);
            Console.WriteLine("Latitude complement: " + ~lat[0]);
            double longitude = longi[0]* Math.Pow(2, 24) + longi[1] * 65536 + longi[2] * 256 + longi[3];
            double resolution = 180 / Math.Pow(2, 30);
            if (latnegative)
                latitude = latitude - Math.Pow(2, 32);
            if (longinegative)
                longitude = longitude - Math.Pow(2, 32);
            this.latitudeWGS84high = latitude * resolution;
            this.longitudeWGS84high = longitude * resolution;
        }

        private void SetPositionWGS84(byte[] dataItem)//Twos complement no se hacerlo
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

            double latitude;
            double longitude;         
            latitude = lat[0] * 65536 + lat[1] * 256 + lat[2];
            longitude = longi[0] * 65536 + longi[1] * 256 + longi[2];

            Console.WriteLine("Latitude real: " + lat[0]);
            Console.WriteLine("Latitude complement: "+ ~lat[0]);
            
            double resolution =180 / Math.Pow(2, 23);
            if ((latitude * resolution)>90)
                this.latitudeWGS84 = (latitude * resolution) - 180;
            else
                this.latitudeWGS84 = (latitude * resolution);
            if ((longitude*resolution)>180)
                this.longitudeWGS84 = (longitude * resolution)-360;
            else
                this.longitudeWGS84 = (longitude * resolution);

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
            this.trackNumber = (int)ComputeBytes(dataItem,resolution);
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
                switch (atp)
                {
                    case 0:
                        this.atp = "24-BIT ICAO address";
                        break;
                    case 1:
                        this.atp = "Duplicate address";
                        break;
                    case 2:
                        this.atp = "Surface vehicle address";
                        break;
                    case 3:
                        this.atp = "Anonymous address";
                        break;
                    case 4:
                        this.atp = "Reserved for future use";
                        break;
                    case 5:
                        this.atp = "Reserved for future use";
                        break;
                    case 6:
                        this.atp = "Reserved for future use";
                        break;
                    case 7:
                        this.atp = "Reserved for future use";
                        break;
                }
                switch (arc)
                {
                    case 0:
                        this.arc = "25 ft";
                        break;
                    case 1:
                        this.arc = "100 ft";
                        break;
                    case 2:
                        this.arc = "Unknown";
                        break;
                    case 3:
                        this.arc = "Invalid";
                        break;
                }
                switch (rc)
                {
                    case 0:
                        this.rc = "Default";
                        break;
                    case 1:
                        this.rc = "Range Check passed, CPR Validation pending";
                        break;
                }
                switch (rab)
                {
                    case 0:
                        this.rab = "Report from target transponder";
                        break;
                    case 1:
                        this.rab = "Report from field monitor(fixed transponder)";
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
                        this.tst = "Default";
                        break;
                    case 1:
                        this.tst = "Test Target";
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
                        this.cl = "Report Valid";
                        break;
                    case 1:
                        this.cl = "Report suspect";
                        break;
                    case 2:
                        this.cl = "No information";
                        break;
                    case 3:
                        this.cl = "Reserved for future use";
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

                switch (ipc)
                {
                    case 0:
                        this.ipc = "Default(see note)";
                        break;
                    case 1:
                        this.ipc = "Independent Position Check failed";
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
                        this.rcf = "Default";
                        break;
                    case 1:
                        this.rcf = "Range Check failed";
                        break;
                }
            }

        }

        private double ComputeBytes(byte[] dataItem, double resolution)
        {
            double value = 0;
            int len = dataItem.Length;
            for (int i=0; i<len; i++)
            {
                value = value + dataItem[i] * Math.Pow(2, 8*(len - i-1));
            }
            value = value * resolution;
            return value;
        }
    }

}
