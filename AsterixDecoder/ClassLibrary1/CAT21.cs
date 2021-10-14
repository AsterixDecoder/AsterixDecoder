using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class CAT21
    {
        //Initialization
        string[] arraystring;
        List<string> data=new List<string>();
        int cat;
        int length;

        //Field Especification
        List<string> FSPEC;
        int[] fieldEspec;

        //Data items
        int[] DataSourceIdentification = new int[2];
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
        
        //string[] DataItem=;


        public CAT21(string[] arraystring)
        {
            this.arraystring = arraystring;
           
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
            this.fieldEspec= setFieldEspec(this.FSPEC);

            this.setDataItems(this.fieldEspec, arraystring);
            //this.sourceIdentifier[0] = HexToDec(arraystring[10]);
            //this.sourceIdentifier[1] = HexToDec(arraystring[11]);
            //for (int n = 0; n < arraystring.Length; n++)
            //{
            //    Console.WriteLine(arraystring[n]);
            //}
        }

        public string[] getArray()
        {
            return this.arraystring;
        }

        public int[] getSourceID()
        {
            return this.DataSourceIdentification;
        }

        public int getCategory()
        {
            return this.cat;
        }

        public int[] getFieldEspec()
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
        public int[] setFieldEspec(List<string> FSPEC)
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


        public void setDataItems(int[] fieldEspec, string[] arraystring)
        {
            if (fieldEspec[0] == 1)
            {
                this.DataSourceIdentification[0] = HexToDec(arraystring[10]);
                this.DataSourceIdentification[1] = HexToDec(arraystring[11]);
                //Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaa");
                //Console.WriteLine(this.DataSourceIdentification[0]+"," +this.DataSourceIdentification[1]);
            }
            else 
            {
                this.DataSourceIdentification = null; //////Mirar si se hace asi el null
            }

            List<string> copydata = new List<string>();
            int ones=0;
            if (fieldEspec[1] == 1)
            {



                for (int n = 0; n < arraystring.Length; n++)
                {
                    copydata.Add(arraystring[n]);
                }
                int k = 0;
                //Console.WriteLine(fieldEspec.Length);
                while (k < (3 + fieldEspec.Length / 8 + 2))
                //field espec esta en bits por ejemplo 56 si los bytes es /8 y 3 son los 3 primeros bytes y 2 los de dataidentif
                {
                    copydata.RemoveAt(0);
                    k++;
                }
                Console.WriteLine("aqui1");
                //for (int n = 0; n < copydata.Count; n++)
                //{
                //    Console.WriteLine(copydata[n]);
                //}

                ////AHORA DATACOPY tiene de target report para adelante
                int moreTRD = 1;
                //int ones = 0;
                List<string> FSPEC = new List<string>();
                while (moreTRD == 1)
                {
                    string binValue = HextoBin(copydata[0]);
                    int len = binValue.Length;
                    string lastBit = Convert.ToString(binValue[len - 1]);
                    int lastBitCheck = Convert.ToInt32(lastBit);
                    if (lastBitCheck == 1)
                    {
                        FSPEC.Add(binValue);
                        copydata.RemoveAt(0);
                        ones++;
                    }
                    else
                    {
                        FSPEC.Add(binValue);
                        copydata.RemoveAt(0);
                        moreTRD = 0;
                    }

                }
                Console.WriteLine("aqui2");
                //for (int n = 0; n < copydata.Count; n++)
                //{
                Console.WriteLine(ones);
                //}
                //for (int n = 0; n < copydata2.Count; n++)
                //{
                //    Console.WriteLine(copydata2[n]);
                //}
                //for (int j = 0; j <= ones; j++)
                //{
                //     this.TargetReportDescriptor[j] = HexToDec(copydata[j]);
                //}

            }
            else
            {
                this.TargetReportDescriptor = null; //////Mirar si se hace asi el null
            }
            if (fieldEspec[2] == 1)
            {

                ////FALTA PROCESAR LOS HEXA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!MIRAR ICAO
                this.TrackNumber[0] = HexToDec(copydata[0]);
                this.TrackNumber[1] = HexToDec(copydata[1]);
                //for (int j = 0; j < copydata.Count; j++)
                //{
                //    Console.WriteLine(copydata[j]);
                //}
                //Console.WriteLine("aqui3track");
                //Console.WriteLine(arraystring[3 + fieldEspec.Length / 8 + 2 + ones + 1+1]);
                //Console.WriteLine(arraystring[3 + fieldEspec.Length / 8 + 2 + ones + 1+1+1]);
                Console.WriteLine(copydata[0]);
                Console.WriteLine(copydata[1]);
            }
            else
            {
                this.DataSourceIdentification = null; //////Mirar si se hace asi el null
            }
        }
    }
}
