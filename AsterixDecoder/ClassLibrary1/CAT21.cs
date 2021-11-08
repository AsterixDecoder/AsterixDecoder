﻿using System;
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
        int m3ACode;

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
        string metInformation;
        double serviceManagement;
        string trajectoryIntent;
        //SelectedAltitude
        string sas;
        string source;
        double selectedAltitude;
        //FinalStateSelectedAltitude

        //int[] TimeofReportTransmission = new int[3];

        // int[] TargetIdentification = new int[3];
        //int[] EmitterCategory = new int[3];
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
            //if int:-1  string:notava
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
            this.m3ACode = -1;

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
            this.metInformation = "N/A";
            this.sas = "N/A";
            this.source = "N/A";
            this.selectedAltitude = double.NaN;
            this.serviceManagement = double.NaN;
            this.trajectoryIntent = "N/A";





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

        public double GetBarometricVerticalRate()
        {
            return this.barometricVerticalRate;
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

        public byte[] GetFSPEC() //Obtiene el FSPEC y lo separa del array mensaje
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
                if (boolFSPEC[19] == true) //MOPS Version
                {
                    byte[] dataItem = GetFixedLengthItem(1);
                    SetMOPSVersion(dataItem);
                }
                if (boolFSPEC[20] == true) //Mode 3/A Code
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
                if (boolFSPEC[37] == true) //
                {
                    byte[] dataItem = GetVariableLengthItem();
                    SetMetInformation(dataItem);
                }

                if (boolFSPEC[36] == true) //
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetSelectedAltitude(dataItem);
                }
                if (boolFSPEC[35] == true) //
                {
                    byte[] dataItem = GetFixedLengthItem(2);
                    SetFinalStateSelectedAltitude(dataItem);
                }
                if (boolFSPEC[34] == true) //
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


            //if (FSPEC.Length >= 6)
            //{
            //    if (boolFSPEC[15] == true) //Time of Applicability for Velocity
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTimeOfApplicabilityVelocity(dataItem);
            //    }
            //    if (boolFSPEC[14] == true) //Air Speed
            //    {
            //        byte[] dataItem = GetFixedLengthItem(2);
            //        SetAirSpeed(dataItem);
            //    }
            //    if (boolFSPEC[13] == true) //True Air Speed
            //    {
            //        byte[] dataItem = GetFixedLengthItem(2);
            //        SetTrueAirSpeed(dataItem);
            //    }
            //    if (boolFSPEC[12] == true) //TargetAdress
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTargetAdress(dataItem);
            //    }
            //    if (boolFSPEC[11] == true) //Time of message reception Position
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTimeOfMessageReceptionPosition(dataItem);
            //    }
            //    if (boolFSPEC[10] == true) //Time of message reception Position High Precision
            //    {
            //        byte[] dataItem = GetFixedLengthItem(4);
            //        SetTimeOfMessageReceptionPositionHighPrecision(dataItem);
            //    }
            //    if (boolFSPEC[9] == true) //Time of message reception Velocity
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTimeOfMessageReceptionVelocity(dataItem);

            //    }
            //}
            //if (FSPEC.Length >= 7)
            //{
            //    if (boolFSPEC[15] == true) //Time of Applicability for Velocity
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTimeOfApplicabilityVelocity(dataItem);
            //    }
            //    if (boolFSPEC[14] == true) //Air Speed
            //    {
            //        byte[] dataItem = GetFixedLengthItem(2);
            //        SetAirSpeed(dataItem);
            //    }
            //    if (boolFSPEC[13] == true) //True Air Speed
            //    {
            //        byte[] dataItem = GetFixedLengthItem(2);
            //        SetTrueAirSpeed(dataItem);
            //    }
            //    if (boolFSPEC[12] == true) //TargetAdress
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTargetAdress(dataItem);
            //    }
            //    if (boolFSPEC[11] == true) //Time of message reception Position
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTimeOfMessageReceptionPosition(dataItem);
            //    }
            //    if (boolFSPEC[10] == true) //Time of message reception Position High Precision
            //    {
            //        byte[] dataItem = GetFixedLengthItem(4);
            //        SetTimeOfMessageReceptionPositionHighPrecision(dataItem);
            //    }
            //    if (boolFSPEC[9] == true) //Time of message reception Velocity
            //    {
            //        byte[] dataItem = GetFixedLengthItem(3);
            //        SetTimeOfMessageReceptionVelocity(dataItem);

            //    }
            //}
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
            this.latitudeWGS84high = latitude * resolution;
            this.longitudeWGS84high = longitude * resolution;
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
                    this.mopsVN = "ED102/DO-260[Ref.8]";
                    break;
                case 1:
                    this.mopsVN = "DO-260A[Ref.9]";
                    break;
                case 2:
                    this.mopsVN = "ED102A/DO-260B[Ref.11]";
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

            this.m3ACode = A * 1000 + B * 100 + C * 10 + D;
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
            this.barometricVerticalRate = ConvertTwosComplementByteToDouble(barometric)*resolution;
        }
        private void SetGeometricVerticalRate(byte[] dataItem)
        {
            double resolution = 6.25;//feet/min
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
            this.geometricVerticalRate = ConvertTwosComplementByteToDouble(geometric) * resolution;
        }
        private void SetAirborneGroundVector(byte[] dataItem)
        {
            double resolutionSpeed = Math.Pow(2,-14);
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
            this.trackAngleRate=ConvertTwosComplementByteToDouble(dataItem) * resolution;
        }
        private void SetTimeOfReportTransmission(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double seconds = ConvertTwosComplementByteToDouble(dataItem)*resolution;
            this.timeOfReportTransmission = TimeSpan.FromSeconds(seconds);
        }

        private void SetTargetIdentification(byte[] dataItem)
        {
           //Mirar tabla e ir poniendo los valores
        }
        private void SetEmitterCategory(byte[] dataItem)
        {
           
            int ECAT = dataItem[0]>>7;


            switch (ECAT)
            {
                case 0:
                    this.emitterCategory = "No ADS-B Emitter Category Information";
                    break;
                case 1:
                    this.emitterCategory = "light aircraft <= 15500 lbs";
                    break;
                case 2:
                    this.emitterCategory = "15500 lbs < small aircraft <75000 lbs  ";
                    break;
                case 3:
                    this.emitterCategory = "75000 lbs < medium a/c < 300000 lbs  ";
                    break;
                case 4:
                    this.emitterCategory = "High Vortex Large";
                    break;
                case 5:
                    this.emitterCategory = "300000 lbs <= heavy aircraft ";
                    break;
                case 6:
                    this.emitterCategory = "highly manoeuvrable (5g acceleration capability) and high speed(> 400 knotscruise)  ";
                    break;
                case 7:
                    this.emitterCategory = "reserved  ";
                    break;
                case 8:
                    this.emitterCategory = "reserved  ";
                    break;
                case 9:
                    this.emitterCategory = "reserved  ";
                    break;
                case 10:
                    this.emitterCategory = "rotocraft ";
                    break;
                case 11:
                    this.emitterCategory = " glider / sailplane  ";
                    break;
                case 12:
                    this.emitterCategory = "ighter-than-air  ";
                    break;
                case 13:
                    this.emitterCategory = "= unmanned aerial vehicle  ";
                    break;
                case 14:
                    this.emitterCategory = "=  space / transatmospheric vehicle   ";
                    break;

                case 15:
                    this.emitterCategory = "ultralight / handglider / paraglider ";
                    break;

                case 16:
                    this.emitterCategory = "=  parachutist / skydiver   ";
                    break;

                case 17:
                    this.emitterCategory = "=reserved  ";
                    break;

                case 18:
                    this.emitterCategory = "reserved  ";
                    break;

                case 19:
                    this.emitterCategory = "reserved  ";
                    break;

                case 20:
                    this.emitterCategory = "surface emergency vehicle ";
                    break;

                case 21:
                    this.emitterCategory = "surface service vehicle   ";
                    break;

                case 22:
                    this.emitterCategory = " fixed ground or tethered obstruction   ";
                    break;

                case 23:
                    this.emitterCategory = " cluster obstacle  ";
                    break;

                case 24:
                    this.emitterCategory = "line obstacle  ";
                    break;

               


            }



        }
        private void SetMetInformation(byte[] dataItem)
        {
            //Coger funcion parecida y adaptarla
        }
        private void SetSelectedAltitude(byte[] dataItem)
        {
            int valueSAS=dataItem[1] >> 7;
            int sourceMask = 96;
            int valueSource = (dataItem[1] & sourceMask) >> 5;

            switch(valueSAS)
            {
                case 0:
                    this.sas = "No source information provided";
                    break;
                case 1:
                    this.sas = "Source information provided";
                    break;
            }
            switch(valueSource)
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

        }
        private void SetTrajectoryIntent(byte[] dataItem)
        {

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
                Console.WriteLine("negative"+ValueDec);
            }
            return ValueDec;
        }
    }

}
