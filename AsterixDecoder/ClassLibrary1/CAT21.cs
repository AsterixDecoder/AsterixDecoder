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
        int[] sourceIdentifier = new int[2];
        
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
            this.sourceIdentifier[0] = HexToDec(arraystring[10]);
            this.sourceIdentifier[1] = HexToDec(arraystring[11]);   
        }
        
        public string[] getArray()
        {
            return this.arraystring;
        }

        public int[] getSourceID()
        {
            return this.sourceIdentifier;
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
    }
}
