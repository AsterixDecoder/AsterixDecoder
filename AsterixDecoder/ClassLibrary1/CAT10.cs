using System;
using System.Text;
using System.Collections;

namespace ClassLibrary
{
   
    public class CAT10
    {

        byte[] arraystring = new byte[200];
        int Long;
        BitArray EspcCamp;
        int[] DataSource=new int[2];
        int MessageType;
        int TargetReportDescriptorTYP;
        bool[] TargerReportDescriptorBOOLS = new bool[5];
        string Description;
        int[] TimeOfDate = new int[3]; // [h,min,sec]
        double[] PositionWS64 = new double[2];
        int[] PolarCoor = new int[2];
        int[] CartCoor = new int[2];
        int[] PolarSpeed = new int[2];
        int[] CartSpeed = new int[2];






        public CAT10(byte[] arraystring)
        {
            int len = arraystring.Length;
            this.arraystring = new byte[len]; ///mirar si se iguala el tamaño automaticamente
            this.arraystring = arraystring;
            byte[] buffer = new byte[4];
            

            for (int i = 0; i < 4; i++)
            {
                buffer[i] = arraystring[i + 3];
            }
            
            
            EspcCamp = new BitArray(buffer);
            int cont = 7;
            for(int i = 0; i < EspcCamp.Length; i++)
            {
                if (EspcCamp[i] == true)
                {
                    switch (i)
                    {
                        case 0:
                            DataSource[0] = arraystring[cont];
                            DataSource[1] = arraystring[cont+1];
                            cont++;
                            cont++;
                            break;
                        case 1:
                            MessageType = arraystring[cont];
                            cont++;
                            break;
                        case 2:
                            byte[] buffer2 = new byte[1];
                            buffer2[0] = arraystring[cont];
                            cont++;
                            BitArray buffer3 = new BitArray(buffer2);
                            bool[] buffer5={ buffer3[5], buffer3[6], buffer3[7] };
                            BitArray buffer4 = new BitArray(buffer5 );
                            buffer4.CopyTo(buffer2,0);
                            TargetReportDescriptorTYP = buffer2[0];
                            TargerReportDescriptorBOOLS[0] = buffer3[0];
                            TargerReportDescriptorBOOLS[1] = buffer3[1];
                            TargerReportDescriptorBOOLS[2] = buffer3[2];
                            TargerReportDescriptorBOOLS[3] = buffer3[3];
                            TargerReportDescriptorBOOLS[4] = buffer3[4];
                            break;
                        case 3:
                            byte[] buffer6 = new byte[3];
                            for (int j = 0; j < 4; j++)
                            {
                                buffer6[j] = arraystring[j + cont];
                            }
                            buffer3 = new BitArray(buffer6);
                            buffer3.CopyTo(TimeOfDate, 2);
                            TimeOfDate[2] = TimeOfDate[2] / 128;
                            TimeOfDate[0] = TimeOfDate[2] / 3600;
                            TimeOfDate[2] = TimeOfDate[2] % 3600;
                            TimeOfDate[1] = TimeOfDate[2] / 60;
                            TimeOfDate[2] = TimeOfDate[2] % 60;
                            cont = cont + 3;
                            break;
                        case 4:
                            byte[] buffer7 = new byte[4];
                            int[] temp = new int[1];
                            for(int j = 0; j < 2; j++)
                            {
                                buffer7[0] = arraystring[cont+j*4];
                                buffer7[1] = arraystring[cont + 1 + j * 4];
                                buffer7[2] = arraystring[cont + 2 + j * 4];
                                buffer7[3] = arraystring[cont + 3 + j * 4];
                                buffer3 = new BitArray(buffer7);
                                buffer3.CopyTo(temp, 0);
                                PositionWS64[j] = temp[0] *180/ (Math.Pow(2,31));
                            }
                            
                            break;


                    }
                        
                }
            }
            
                //this.EspcCamp = arraystring[3+i]

            
            
             
        }

        




}
}
