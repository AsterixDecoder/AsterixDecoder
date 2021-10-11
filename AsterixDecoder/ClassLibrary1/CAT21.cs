using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class CAT21
    {

        string[] arraystring = new string[200];
        int[] sourceIdentifier = new int[2];
        int[] fieldEspec = new int[56];
        //string[] DataItem=;
        

        public CAT21(string[] arraystring)
        {
            int len = arraystring.Length;
            this.arraystring = new string[len]; ///mirar si se iguala el tamaño automaticamente
            this.arraystring = arraystring;
            setFieldEspec();
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

        public void setFieldEspec()
        {
            int m = 0;
            for (int i = 3; i <= 9; i++)
            {
                string binValue=HextoBin(arraystring[i]);
                string padding="0";
                if (binValue.Length < 8)
                {
                    int zeroPadding = 8 - binValue.Length;
                    for (int k=1; k < zeroPadding; k++)
                    {
                        padding = padding + "0";
                    }
                    binValue = padding + binValue;
                }
                for (int j=0; j < 8; j++)
                {
                    string binString = Convert.ToString(binValue[j]);
                    fieldEspec[m]=Convert.ToInt32(binString);
                    //Console.WriteLine(fieldEspec[m]);
                    m = m + 1;
                }
            }
          
        }
    }
}
