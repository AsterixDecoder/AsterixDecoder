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

        //Target Report Descriptor
        string atp;
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
        string rcf;

        TimeSpan timeofApplicabilityPosition;

        double latitudeWGS84;
        double longitudeWGS84;

        double latitudeWGS84high;
        double longitudeWGS84high;


        int[] TimeofApplicabilityforVelocity = new int[3];
        int[] AirSpeed = new int[2];
        int[] TrueAirSpeed = new int[3];
        int[] TargetAddress = new int[3];
        int[] TimeofMessageReceptionofPosition = new int[3];
        int[] TimeofMessageReceptionofPositionHighPrecision = new int[3];
        int[] TimeofMessageReceptionofVelocity= new int[3];

        int[] TimeofMessageReceptionofVelocityHighPrecision = new int[3];
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


            //this.cat = HexToDec(data[0]);

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

        public byte[] GetFieldEspec()
        {
            return this.FSPEC;
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
        //public int[] SetFieldEspec(List<string> FSPEC)
        //{
        //    int m = 0;
        //    int len = FSPEC.Count;
        //    int[] fieldEspec = new int[len * 8];
        //    for (int i = 0; i < len; i++)
        //    {
        //        string binValue = FSPEC[i];
        //        string padding = "0";
        //        if (binValue.Length < 8)
        //        {
        //            int zeroPadding = 8 - binValue.Length;
        //            for (int k = 1; k < zeroPadding; k++)
        //            {
        //                padding = padding + "0";
        //            }
        //            binValue = padding + binValue;
        //        }
        //        for (int j = 0; j < 8; j++)
        //        {
        //            string binString = Convert.ToString(binValue[j]);
        //            fieldEspec[m] = Convert.ToInt32(binString);
        //            m = m + 1;
        //        }
        //    }
        //    return fieldEspec;

        //}
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
            double time = dataItem[0] * (65536/128) + dataItem[1]* (256/128) +dataItem[2]*(1/128);
            this.timeofApplicabilityPosition = TimeSpan.FromSeconds(time);
        }

        private void SetServiceIdentification(byte[] dataItem)
        {
            this.serviceIdentification = dataItem[0];
        }

        private void SetTrackNumber(byte[] dataItem)
        {
            this.trackNumber = dataItem[0] * 256 + dataItem[1];
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
    }

}
