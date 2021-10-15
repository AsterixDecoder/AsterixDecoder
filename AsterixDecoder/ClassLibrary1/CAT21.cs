using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class CAT21
    {
        //Initialization
        string[] arraystring;
        List<string> data;
        int cat;
        int length;

        //Field Especification
        List<string> FSPEC;
        int[] fieldEspec;

        //Data items
        int[] DataSourceIdentification = new int[2];
        int systemIdentificationCode;
        int systemAreaCode;
        int[] TargetReportDescriptor;
        int[] TrackNumber = new int[2];
        int ServiceIdentification;
        int[] TimeofApplicabilityforPosition = new int[3];
        int[] PositioninWGS84coordinates = new int[6];
        int[] PositioninWGS84coordinateshighres = new int[8];

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
        


        public CAT21(string[] arraystring)
        {
            this.arraystring = arraystring;
            this.data = null;
           
            for (int i=0; i < this.arraystring.Length; i++)
            {
                this.data.Add(arraystring[i]);
            }

            this.cat = HexToDec(data[0]);
            this.length = HexToDec(data[2]);
            data.RemoveAt(0);
            data.RemoveAt(0);
            data.RemoveAt(0);
            this.FSPEC = GetFSPEC(data);
            this.fieldEspec= SetFieldEspec(this.FSPEC);

            this.SetDataItems();
            //this.sourceIdentifier[0] = HexToDec(arraystring[10]);
            //this.sourceIdentifier[1] = HexToDec(arraystring[11]);
            //for (int n = 0; n < arraystring.Length; n++)
            //{
            //    Console.WriteLine(arraystring[n]);
            //}
        }

        public string[] GetArray()
        {
            return this.arraystring;
        }

        public int[] GetSourceID()
        {
            return this.DataSourceIdentification;
        }

        public int GetCategory()
        {
            return this.cat;
        }

        public int[] GetFieldEspec()
        {
            return this.fieldEspec;
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

        public List<string> GetFSPEC(List<string> data) //Obtiene el FSPEC y lo separa del array mensaje
        {

            int moreFSPEC = 1;
            int i=0;
            List<string> FSPEC = new List<string>();
            while (moreFSPEC == 1)
            {
                string binValue =HextoBin(data[0]);
                int len = binValue.Length;
                string lastBit = Convert.ToString(binValue[len - 1]);
                int lastBitCheck = Convert.ToInt32(lastBit);
                if (lastBitCheck==1)
                {
                    FSPEC.Add(binValue);
                    data.RemoveAt(0);
                    i++;
                }
                else
                {
                    FSPEC.Add(binValue);
                    data.RemoveAt(0);
                    moreFSPEC = 0;
                }
                //for (int j = 0; j < FSPEC.Count; j++)
                //{
                  //  Console.WriteLine(FSPEC[j]);
               // }

            }
            return FSPEC;

        }
        public int[] SetFieldEspec(List<string> FSPEC)
        {
            int m = 0;
            int len = FSPEC.Count;
            int[] fieldEspec = new int[len * 8];
            for (int i = 0; i < len; i++)
            {
                string binValue = FSPEC[i];
                string padding = "0";
                if (binValue.Length < 8)
                {
                    int zeroPadding = 8 - binValue.Length;
                    for (int k = 1; k < zeroPadding; k++)
                    {
                        padding = padding + "0";
                    }
                    binValue = padding + binValue;
                }
                for (int j = 0; j < 8; j++)
                {
                    string binString = Convert.ToString(binValue[j]);
                    fieldEspec[m] = Convert.ToInt32(binString);
                    m = m + 1;
                }
            }
            return fieldEspec;

        }

        public string[] GetFixedLengthItem(int length)
        {
            string[] dataItem = new string[length];
            for (int i=0; i<length; i++)
            {
                dataItem[i] = this.data[0];
                data.RemoveAt(0);
            }
            return dataItem;
        }

        public string[] GetVariableLengthItem() //Hay que pasarlo a byte para que funcione
        {

            List<string> dataItem = new List<string>();
            dataItem.Add(this.data[0]);
            data.RemoveAt(0);
            int i = 0;
            //while (data[i]==1) 
            //{
            //    dataItem.Add(this.data[0]);
            //    data.RemoveAt(0);
            //    i++;
            //}
            return dataItem.ToArray();
        }
        public void SetDataSourceIdentifier(string[] dataItem)
        {
            string[]
        }
        public void SetDataItems()
        {
            List<string> FSPEC = this.FSPEC;
            int[] fieldEspec = this.fieldEspec;
            if (FSPEC.Count>=1)
            {
                if (fieldEspec[0]==1) //Data Source Identifier
                {
                    string[] dataItem = GetFixedLengthItem(2);
                    SetDataSourceIdentifier(dataItem);
                }
                if (fieldEspec[1] == 1)
                {

                }
                if (fieldEspec[2] == 1)
                {

                }
                if (fieldEspec[3] == 1)
                {

                }
                if (fieldEspec[4] == 1)
                {

                }
                if (fieldEspec[5] == 1)
                {

                }
                if (fieldEspec[6] == 1)
                {

                }

            }
            if (FSPEC.Count >= 2)
            {
                if (fieldEspec[9] == 1)
                {

                }
                if (fieldEspec[10] == 1)
                {

                }
                if (fieldEspec[11] == 1)
                {

                }
                if (fieldEspec[12] == 1)
                {

                }
                if (fieldEspec[13] == 1)
                {

                }
                if (fieldEspec[14] == 1)
                {

                }
                if (fieldEspec[15] == 1)
                {

                }
            }
        }
    }

}
