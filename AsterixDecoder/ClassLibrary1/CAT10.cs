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
        int[] D00_DataSource=new int[2];
        int D01_MessageType;
        int D02_TargetReportDescriptorTYP;
        bool[] D02_TargerReportDescriptorBOOLS = new bool[5];
        int[] D03_TimeOfDate = new int[3]; // [h,min,sec]
        double[] D04_PositionWS64 = new double[2];
        double[] D05_PolarCoor = new double[2];
        int[] D06_CartCoor = new int[2];
        double[] D08_PolarSpeed = new double[2];
        double[] D09_CartSpeed = new double[2];
        int D10_TrackNum;
        int[] D11_TrackStatus = new int[10];//CNF,TRE,CST,MAH,TCC,STH,TOM,DOU,MRS,GHO
        int[] D12_Mode3_a = new int[7]; //V,G,L,A,B,C,D
        int[] D13_TargetAddress = new int[3];//valor de cada byte
        int D17_VFI;
        double[] D18_FLBinary = new double[3];
        double D19_MeasuredHeight;
        double[] D20_TargerSizeOrientation=new double[3];
        int[] D21_SystemStatus = new int[5];
        int[] D22_PreProgrammedMessage = new int[2];
        double[] D24_StandardDeviationOfPosition = new double[3];
        double[] D25_Presence = new double[3];
        int D26_AmplitudeOfPrimaryPlot;
        double[] D27_CalculatedAcceleration = new double[2];
        






        public CAT10(byte[] arraystring)
        {
            int len = arraystring.Length;
            this.arraystring = new byte[len]; ///mirar si se iguala el tamaño automaticamente
            this.arraystring = arraystring;
            BitArray bufferBit1 = new BitArray(0);
            BitArray bufferBit2 = new BitArray(0);
            byte[] buffer1 = new byte[1];
            byte[] buffer2 = new byte[2];
            byte[] buffer3 = new byte[3];
            byte[] buffer4 = new byte[4];
            bool[] bufferBool2 = new bool[2];
            bool[] bufferBool3 = new bool[3];
            bool[] bufferBool6 = new bool[6];
            bool[] bufferBool7 = new bool[7];
            int[] temp = new int[1];
            bool tempBool;
            int tempInt;

            for (int i = 0; i < 4; i++)
            {
                buffer4[i] = arraystring[i + 3];
            }
            
            
            EspcCamp = new BitArray(buffer4);
            int cont = 7;
            for(int i = 0; i < EspcCamp.Length; i++)
            {
                if (EspcCamp[i] == true)
                {
                    switch (i)
                    {
                        case 0:
                            D00_DataSource[0] = arraystring[cont];
                            D00_DataSource[1] = arraystring[cont+1];
                            cont++;
                            cont++;
                            break;
                        case 1:
                            D01_MessageType = arraystring[cont];
                            cont++;
                            break;
                        case 2:
                            buffer1[0] = arraystring[cont];
                            cont++;
                            bufferBit1 = new BitArray(buffer1);
                            bufferBool3[2] = bufferBit1[7];
                            bufferBool3[1] = bufferBit1[6];
                            bufferBool3[0] = bufferBit1[5];
                            bufferBit2 = new BitArray(bufferBool3 );
                            bufferBit2.CopyTo(buffer1,0);
                            D02_TargetReportDescriptorTYP = buffer1[0];
                            D02_TargerReportDescriptorBOOLS[0] = bufferBit1[0];
                            D02_TargerReportDescriptorBOOLS[1] = bufferBit1[1];
                            D02_TargerReportDescriptorBOOLS[2] = bufferBit1[2];
                            D02_TargerReportDescriptorBOOLS[3] = bufferBit1[3];
                            D02_TargerReportDescriptorBOOLS[4] = bufferBit1[4];
                            break;
                        case 3:
                            
                            for (int j = 0; j < 4; j++)
                            {
                                buffer3[j] = arraystring[j + cont];
                            }
                            bufferBit1 = new BitArray(buffer3);
                            bufferBit1.CopyTo(D03_TimeOfDate, 2);
                            D03_TimeOfDate[2] = D03_TimeOfDate[2] / 128;
                            D03_TimeOfDate[0] = D03_TimeOfDate[2] / 3600;
                            D03_TimeOfDate[2] = D03_TimeOfDate[2] % 3600;
                            D03_TimeOfDate[1] = D03_TimeOfDate[2] / 60;
                            D03_TimeOfDate[2] = D03_TimeOfDate[2] % 60;
                            cont = cont + 3;
                            break;
                        case 4:// Esto esta mal y hay que preguntar                           
                            
                            for(int j = 0; j < 2; j++)
                            {
                                buffer4[0] = arraystring[cont+j*4];
                                buffer4[1] = arraystring[cont + 1 + j * 4];
                                buffer4[2] = arraystring[cont + 2 + j * 4];
                                buffer4[3] = arraystring[cont + 3 + j * 4];
                                bufferBit1 = new BitArray(buffer4);
                                bufferBit1.CopyTo(temp, 0);
                                D04_PositionWS64[j] = temp[0] *180/ (Math.Pow(2,31));
                            }
                            cont = cont + 8;
                            
                            break;
                        case 5:
                        
                            for (int j = 0; j < 2; j++)
                            {
                                buffer2[0] = arraystring[cont + j * 2];
                                buffer2[1] = arraystring[cont + 1 + j * 2];
                                bufferBit1 = new BitArray(buffer2);
                                bufferBit1.CopyTo(temp, 0);
                                D05_PolarCoor[j] = temp[0] * 360 / (Math.Pow(2, 16));
                            }
                            cont = cont + 4;
                            break;
                        case 6:
                            for (int j = 0; j < 2; j++)
                            {
                                buffer2[0] = arraystring[cont + j * 2];
                                buffer2[1] = arraystring[cont + 1 + j * 2];
                                bufferBit1 = new BitArray(buffer2);
                                bufferBit1.CopyTo(temp, 0);
                                D06_CartCoor[j] = temp[0];
                            }
                            cont = cont + 4;
                            break;
                        case 8:
                            for (int j = 0; j < 2; j++)
                            {
                                buffer2[0] = arraystring[cont + j * 2];
                                buffer2[1] = arraystring[cont + 1 + j * 2];
                                bufferBit1 = new BitArray(buffer2);
                                bufferBit1.CopyTo(temp, 0);
                                if(j==0)
                                    D08_PolarSpeed[j]=temp[0]/Math.Pow(2,14);
                                else
                                    D08_PolarSpeed[j] = temp[0]*360/Math.Pow(2,16);
                            }
                            cont = cont + 4;
                            break;
                        case 9:
                            for (int j = 0; j < 2; j++)
                            {
                                buffer2[0] = arraystring[cont + j * 2];
                                buffer2[1] = arraystring[cont + 1 + j * 2];
                                bufferBit1 = new BitArray(buffer2);
                                bufferBit1.CopyTo(temp, 0);
                                D09_CartSpeed[j] = temp[0] *0.25;

                            }
                            cont = cont + 4;
                            break;
                        case 10:
                            buffer2[0] = arraystring[cont ];
                            buffer2[1] = arraystring[cont + 1 ];
                            bufferBit1 = new BitArray(buffer2);
                            bufferBit1.CopyTo(temp, 0);
                            D10_TrackNum = temp[0];
                            cont = cont + 2;
                            break;
                        case 11:
                            tempBool = true;
                            tempInt = 0;
                            while (tempBool)
                            {
                                buffer1[0] = arraystring[cont];
                                bufferBit1 = new BitArray(buffer1);
                                switch (tempInt)
                                {
                                    case 0:
                                        D11_TrackStatus[0]=bufferBit1[7]?1:0;
                                        D11_TrackStatus[1] = bufferBit1[6] ? 1 : 0;
                                        bufferBool2[1] = bufferBit1[5];
                                        bufferBool2[0] = bufferBit1[4];
                                        bufferBit2 = new BitArray(bufferBool2);
                                        bufferBit2.CopyTo(buffer1, 0);
                                        D11_TrackStatus[2] = buffer1[0];
                                        D11_TrackStatus[3] = bufferBit1[3] ? 1 : 0;
                                        D11_TrackStatus[4] = bufferBit1[2] ? 1 : 0;
                                        D11_TrackStatus[5] = bufferBit1[1] ? 1 : 0;
                                        if (bufferBit1[0]) tempInt++;
                                        else tempBool = false;
                                        break;
                                    case 1:
                                        bufferBool2[1] = bufferBit1[7];
                                        bufferBool2[0] = bufferBit1[6];
                                        bufferBit2 = new BitArray(bufferBool2);
                                        bufferBit2.CopyTo(buffer1, 0);
                                        D11_TrackStatus[6] = buffer1[0];

                                        bufferBool3[2] = bufferBit1[5];
                                        bufferBool3[1] = bufferBit1[4];
                                        bufferBool3[0] = bufferBit1[3];
                                        bufferBit2 = new BitArray(bufferBool2);
                                        bufferBit2.CopyTo(buffer1, 0);
                                        D11_TrackStatus[7] = buffer1[0];

                                        bufferBool2[1] = bufferBit1[2];
                                        bufferBool2[0] = bufferBit1[1];
                                        bufferBit2 = new BitArray(bufferBool2);
                                        bufferBit2.CopyTo(buffer1, 0);
                                        D11_TrackStatus[8] = buffer1[0];

                                        if (bufferBit1[0]) tempInt++;
                                        else tempBool = false;

                                        break;
                                    case 2:
                                        D11_TrackStatus[9] = bufferBit1[7] ? 1 : 0;
                                        tempBool = false;
                                        break;

                                }
                                cont++;
                                

                            }

                            break;

                        case 12:
                            buffer2[0] = arraystring[cont];
                            buffer2[1] = arraystring[cont+1];
                            bufferBit1 = new BitArray(buffer2);
                            D12_Mode3_a[0] = bufferBit1[15]?1:0;
                            D12_Mode3_a[1] = bufferBit1[14] ? 1 : 0;
                            D12_Mode3_a[2] = bufferBit1[13] ? 1 : 0;
                            for(int j = 0; j < 4; j++) {
                                bufferBool3[2] = bufferBit1[11 - j * 3];
                                bufferBool3[1] = bufferBit1[11 - j * 3-1];
                                bufferBool3[0] = bufferBit1[11 - j * 3-2];
                                bufferBit2 = new BitArray(bufferBool3);
                                bufferBit2.CopyTo(buffer1,0);
                                D12_Mode3_a[3 + j] = buffer1[0];
                            }
                            cont = cont + 2;
                            break;
                        case 13://Se lee asi?
                            for (int j = 0; j < 3; j++)
                            {
                                buffer1[0] = arraystring[j + cont];
                                D13_TargetAddress[j] = buffer1[0];
                            }
                            break;
                        case 14://Como se lee?

                            break;
                        case 16: //tampoco se como se lee los bits de MSB
                            break;
                        case 17:
                            buffer1[0] = arraystring[cont];
                            D17_VFI = buffer1[0];
                            break;
                        case 18:
                            buffer2[0] = arraystring[cont];
                            buffer2[1] = arraystring[cont+1];
                            bufferBit1 = new BitArray(buffer2);
                            D18_FLBinary[0] = bufferBit1[15] ? 1 : 0;
                            D18_FLBinary[1] = bufferBit1[14] ? 1 : 0;
                            for (int j = 0; j < 6; j++) {
                                bufferBool6[j] = bufferBit1[13 - j];
                                    }
                            bufferBit2 = new BitArray(bufferBool6);
                            bufferBit2.CopyTo(buffer2,0);
                            bufferBit1 = new BitArray(buffer2);
                            bufferBit1.CopyTo(temp, 0);
                            D18_FLBinary[2] = temp[0] * 0.25;
                            cont= 2 + cont;
                            break;
                        case 19:
                            buffer2[0] = arraystring[cont];
                            buffer2[1] = arraystring[cont + 1];
                            bufferBit1 = new BitArray(buffer2);
                            bufferBit1.CopyTo(temp, 0);
                            D19_MeasuredHeight = temp[0] * 6.25;
                            cont= cont + 2;
                            break;
                        case 20:
                            tempBool = true;
                            tempInt = 0;
                            while (tempBool) {
                                buffer1[0] = arraystring[cont];
                                bufferBit1 = new BitArray(buffer1);
                                tempBool = bufferBit1[0];
                                if(bufferBit1[0])  cont++ ;
                                for (int j = 0; j < 7; j++)
                                {
                                    bufferBool7[j] = bufferBit1[7 - j];
                                }
                                bufferBit1 = new BitArray(bufferBool7);
                                bufferBit1.CopyTo(temp, 0);
                                switch (tempInt)
                                {
                                    case 1: 
                                    case 3:
                                        D20_TargerSizeOrientation[tempInt] = temp[0];
                                        break;
                                    case 2:
                                        D20_TargerSizeOrientation[tempInt] = temp[0] * 2.81;
                                        break;
                                }
                                tempInt++;
                            }
                            cont++;
                            break;
                        case 21:
                            buffer1[0] = arraystring[cont];
                            bufferBit1 = new BitArray(buffer1);
                            bufferBool2[1] = bufferBit1[7];
                            bufferBool2[0] = bufferBit1[6];
                            bufferBit2 = new BitArray(bufferBool2);
                            bufferBit2.CopyTo(temp, 0);
                            D21_SystemStatus[0] = temp[0];
                            for (int j = 1; i < 5; i++)
                            {
                                D21_SystemStatus[j] = bufferBit1[6-j] ? 1 : 0;
                            }
                            cont++;
                            break;
                            
                        case 22:
                            buffer1[0] = arraystring[cont];
                            bufferBit1 = new BitArray(buffer1);
                            D22_PreProgrammedMessage[0] = bufferBit1[7] ? 1 : 0;
                            for (int j = 0; i < 6; i++)
                            {
                                bufferBool7[j] = bufferBit1[j];
                            }
                            bufferBit1 = new BitArray(bufferBool7);
                            bufferBit1.CopyTo(temp, 0);
                            D22_PreProgrammedMessage[1] = temp[0];
                            cont++;
                            break;
                        case 24:
                            for (int j = 0; j < 2; j++)
                            {
                                buffer1[0] = arraystring[cont + j];
                                bufferBit1 = new BitArray(buffer1);
                                bufferBit1.CopyTo(temp, 0);
                                D24_StandardDeviationOfPosition[j] = temp[0] * 0.25;
                            }
                            buffer2[1] = arraystring[cont + 2];
                            buffer2[0] = arraystring[cont + 3];
                            bufferBit1 = new BitArray(buffer2);
                            bufferBit1.CopyTo(temp, 0);
                            D24_StandardDeviationOfPosition[2] = temp[0] * 0.25;
                            cont = cont + 4;
                            break;
                        case 25:
                            for (int j = 0; j < 3; j++)
                            {
                                buffer1[0] = arraystring[cont + j];
                                bufferBit1 = new BitArray(buffer1);
                                bufferBit1.CopyTo(temp, 0);
                                switch (j)
                                {
                                    case 0:
                                    case 1:
                                        D25_Presence[j] = temp[0];
                                        break;
                                    case 2:
                                        D25_Presence[j] = temp[0]*0.15;
                                        break;
                                }
                                
                            }
                            cont = cont + 3;
                            break;
                        case 26:
                            buffer1[0] = arraystring[cont];
                            bufferBit1 = new BitArray(buffer1);
                            bufferBit1.CopyTo(temp, 0);
                            D26_AmplitudeOfPrimaryPlot = temp[0];
                            cont++;
                            break;
                        case 27:
                            for (int j = 0; j < 2; j++)
                            {
                                buffer1[0] = arraystring[cont + j];
                                bufferBit1 = new BitArray(buffer1);
                                bufferBit1.CopyTo(temp, 0);
                                D27_CalculatedAcceleration[j] = temp[0] * 0.25;
                            }
                            break;
                    }
                        
                }
            }
            
                

            
            
             
        }

        




}
}
