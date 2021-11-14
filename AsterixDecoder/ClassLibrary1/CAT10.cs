using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace ClassLibrary
{
   
    public class CAT10
    {

        byte[] arraystring = new byte[200];
        int Long;
        BitArray EspcCamp;
        int[] D00_DataSource=new int[2];
        int D01_MessageType;

        int[] D02_TargetReportDescriptor = new int[11];
        int[] D03_TimeOfDate = new int[4]; // [h,min,sec]
        double[] D04_PositionWS64 = new double[2];
        double[] D05_PolarCoor = new double[2];
        int[] D06_CartCoor = new int[2];
        double[] D08_PolarSpeed = new double[2];
        double[] D09_CartSpeed = new double[2];
        int D10_TrackNum;
        int[] D11_TrackStatus = new int[10];//CNF,TRE,CST,MAH,TCC,STH,TOM,DOU,MRS,GHO
        int[] D12_Mode3_a = new int[7]; //V,G,L,A,B,C,D
        int[] D13_TargetAddress = new int[3];//valor de cada byte
        int[] D16_Mode_S = new int[2];
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
            bool[] bufferBool4 = new bool[4];
            bool[] bufferBool6 = new bool[6];
            bool[] bufferBool7 = new bool[7];
            int[] temp = new int[1];
            bool tempBool=true;
            int tempInt;

            int cont = 3;

            while(tempBool)
            {
                buffer1[0] = arraystring[cont];
                bufferBit1 = new BitArray(buffer1);
                tempBool = bufferBit1[0];
                cont++;
            }
            switch (cont - 4)
            {
                case 0:
                    buffer1[0] = arraystring[cont - 1];
                    bufferBit1 = new BitArray(buffer1);
                    bufferBit2 = new BitArray(buffer1);
                    for (int i = 0; i < 8; i++)
                        bufferBit2[i] = bufferBit1[7 - i];
                    EspcCamp = bufferBit2;
                    break;
                case 1:
                    buffer2[0] = arraystring[cont - 2];
                    buffer2[1] = arraystring[cont - 1];
                    bufferBit1 = new BitArray(buffer2);
                    bufferBit2 = new BitArray(buffer2);
                    for (int j = 0; j < 2; j++)
                    {
                        for (int i = 0; i < 8; i++)
                            bufferBit2[i + 8 * j] = bufferBit1[8 * (j + 1) - 1 - i];
                    }
                    EspcCamp = bufferBit2;
                    break;
                case 2:
                    buffer3[0] = arraystring[cont - 3];
                    buffer3[1] = arraystring[cont - 2];
                    buffer3[2] = arraystring[cont - 1];
                    bufferBit1 = new BitArray(buffer4);
                    bufferBit2 = new BitArray(buffer4);
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < 8; i++)
                            bufferBit2[i + 8 * j] = bufferBit1[8 * (j + 1) - 1 - i];
                    }
                    EspcCamp = bufferBit2;
                    break;
                case 3:
                    buffer4[0] = arraystring[cont - 4];
                    buffer4[1] = arraystring[cont - 3];
                    buffer4[2] = arraystring[cont - 2];
                    buffer4[3] = arraystring[cont - 1];
                    bufferBit1 = new BitArray(buffer4);
                    bufferBit2 = new BitArray(buffer4);
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < 8; i++)
                            bufferBit2[i+8*j] = bufferBit1[8*(j+1)-1 - i];
                    }
                    EspcCamp = bufferBit2;
                    break;

            }
            

            
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


                            tempBool = true;
                            tempInt = 0;
                            while (tempBool)
                            {
                                buffer1[0] = arraystring[cont];

                                bufferBit1 = new BitArray(buffer1);
                                switch (tempInt)//TYP,DCR,CHN,GBS,CRT,SIM,TST,RAB,LOP,TOT,SPI
                                {
                                    case 0:
                                        bufferBool3[2] = bufferBit1[7];
                                        bufferBool3[1] = bufferBit1[6];
                                        bufferBool3[0] = bufferBit1[5];
                                        bufferBit2 = new BitArray(bufferBool3);
                                        bufferBit2.CopyTo(buffer1, 0);
                                        D02_TargetReportDescriptor[0] = buffer1[0];

                                        D02_TargetReportDescriptor[1] = bufferBit1[4] ? 1 : 0;
                                        D02_TargetReportDescriptor[2] = bufferBit1[3] ? 1 : 0;
                                        D02_TargetReportDescriptor[3] = bufferBit1[2] ? 1 : 0;
                                        D02_TargetReportDescriptor[4] = bufferBit1[1] ? 1 : 0;
                                        if (bufferBit1[0]) tempInt++;
                                        else tempBool = false;
                                        cont++;
                                        break;
                                    case 1:
                                        D02_TargetReportDescriptor[5] = bufferBit1[7] ? 1 : 0;
                                        D02_TargetReportDescriptor[6] = bufferBit1[6] ? 1 : 0;
                                        D02_TargetReportDescriptor[7] = bufferBit1[5] ? 1 : 0;

                                        bufferBool2[1] = bufferBit1[4];
                                        bufferBool2[0] = bufferBit1[3];
                                        bufferBit2 = new BitArray(bufferBool2);
                                        bufferBit2.CopyTo(buffer1, 0);
                                        D02_TargetReportDescriptor[8] = buffer1[0];


                                        bufferBool2[1] = bufferBit1[2];
                                        bufferBool2[0] = bufferBit1[1];
                                        bufferBit2 = new BitArray(bufferBool2);
                                        bufferBit2.CopyTo(buffer1, 0);
                                        D02_TargetReportDescriptor[9] = buffer1[0];


                                        if (bufferBit1[0]) tempInt++;
                                        else tempBool = false;
                                        cont++;
                                        break;
                                    case 2:
                                        D02_TargetReportDescriptor[10] = bufferBit1[7] ? 1 : 0;
                                        tempBool = false;
                                        cont++;
                                        break;

                                }
                                
                            }
                                break;
                            
                        case 3:
                            
                            for (int j = 0; j < 3; j++)
                            {
                                buffer3[2-j] = arraystring[j + cont];
                            }
                            bufferBit1 = new BitArray(buffer3);
                            bufferBit1.CopyTo(D03_TimeOfDate, 2);
                            D03_TimeOfDate[3] = D03_TimeOfDate[2] % 128*1000/128;
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
                                buffer4[3] = arraystring[cont+j*4];
                                buffer4[2] = arraystring[cont + 1 + j * 4];
                                buffer4[1] = arraystring[cont + 2 + j * 4];
                                buffer4[0] = arraystring[cont + 3 + j * 4];
                                bufferBit1 = new BitArray(buffer4);
                                bufferBit1.CopyTo(temp, 0);
                                D04_PositionWS64[j] = temp[0] *180/ (Math.Pow(2,31));
                            }
                            cont = cont + 8;
                            
                            break;
                        case 5:

                                buffer2[1] = arraystring[cont ];
                                buffer2[0] = arraystring[cont + 1];
                                bufferBit1 = new BitArray(buffer2);
                                bufferBit1.CopyTo(temp, 0);
                                D05_PolarCoor[0] = temp[0];

                                buffer2[1] = arraystring[cont +  2];
                                buffer2[0] = arraystring[cont + 3];
                                bufferBit1 = new BitArray(buffer2);
                                bufferBit1.CopyTo(temp, 0);
                                D05_PolarCoor[1] = temp[0] * 360 / (Math.Pow(2, 16));
                            
                            cont = cont + 4;
                            break;
                        case 6://////////////////////////////////////////////////////////////////////////
                            for (int j = 0; j < 2; j++)
                            {
                                buffer2[1] = arraystring[cont + j * 2];
                                buffer2[0] = arraystring[cont + 1 + j * 2];
                                bufferBit1 = new BitArray(buffer2);
                                if (bufferBit1[15])
                                {
                                    for (int z = 0; z < 16; z++)
                                        bufferBit1[z] = bufferBit1[z] ? false : true;
                                    bufferBit1.Not();
                                }
                                bufferBit1.CopyTo(temp, 0);
                                D06_CartCoor[j] = temp[0];
                            }
                            cont = cont + 4;
                            break;
                        case 8:
                            for (int j = 0; j < 2; j++)
                            {
                                buffer2[1] = arraystring[cont + j * 2];
                                buffer2[0] = arraystring[cont + 1 + j * 2];
                                bufferBit1 = new BitArray(buffer2);
                                bufferBit1.CopyTo(temp, 0);
                                if(j==0)
                                    D08_PolarSpeed[j]=temp[0]*0.22* 0.514;
                                else
                                    D08_PolarSpeed[j] = temp[0]*360/Math.Pow(2,16);
                            }
                            cont = cont + 4;
                            break;
                        case 9:
                            for (int j = 0; j < 2; j++)
                            {
                                buffer2[1] = arraystring[cont + j * 2];
                                buffer2[0] = arraystring[cont + 1 + j * 2];
                                bufferBit1 = new BitArray(buffer2);
                                if (bufferBit1[15])
                                {
                                    for (int z = 0; z < 16; z++)
                                        bufferBit1[z] = bufferBit1[z] ? false : true;
                                    bufferBit1.Not();
                                }
                                bufferBit1.CopyTo(temp, 0);
                                D09_CartSpeed[j] = temp[0] *0.25;

                            }
                            cont = cont + 4;
                            break;
                        case 10:
                            buffer2[1] = arraystring[cont ];
                            buffer2[0] = arraystring[cont + 1 ];
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
                                        bufferBit2 = new BitArray(bufferBool3);
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
                            cont = cont + 3;
                            break;
                        case 14://Dijo que no habia que hacer

                            break;
                        case 16:
                            cont = cont + 8;
                            buffer1[0] = arraystring[cont];
                            bufferBit1 = new BitArray(buffer1);
                            for (int j = 0; j < 2; j++)
                            {
                                for (int z = 0; z < 4; z++)
                                    bufferBool4[z] = bufferBit1[z + j * 4];
                                bufferBit2 = new BitArray(bufferBool4);
                                bufferBit2.CopyTo(D16_Mode_S, j);

                            }
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
                                    bufferBool7[j] = bufferBit1[j+1];
                                }
                                bufferBit1 = new BitArray(bufferBool7);
                                bufferBit1.CopyTo(temp, 0);
                                switch (tempInt)
                                {
                                    case 0: 
                                    case 2:
                                        D20_TargerSizeOrientation[tempInt] = temp[0];
                                        break;
                                    case 1:
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
                                if (bufferBit1[7])
                                {
                                    for (int z = 0; z < 8; z++)
                                        bufferBit1[z] = bufferBit1[z] ? false : true;
                                    bufferBit1.Not();
                                }
                                bufferBit1.CopyTo(temp, 0);
                                D27_CalculatedAcceleration[j] = temp[0] * 0.25;
                            }
                            break;
                    }
                        
                }
            }
            
                

            
            
             
        }
        public string[] GetValues(int n)
        {
            string[] row = new string[n];
            for (int i = 0; i < n; i++)
            {
                row[i] = "No Data";
            }

            if (true)
            {
                for (int i = 0; i < EspcCamp.Length; i++)
                {
                    if (EspcCamp[i])
                    {
                        switch (i)
                        {
                            case 0:
                                row[2+i] = D00_DataSource[0].ToString();
                                row[3+i] = D00_DataSource[1].ToString();
                                break;
                            case 1:
                                switch (D01_MessageType)
                                {
                                    case 1:
                                        row[3+i] = "Target Report";
                                        break;
                                    case 2:
                                        row[3+i] = "Start of Update Cycle";
                                        break;
                                    case 3:
                                        row[3+i] = "Periodic Status Message";
                                        break;
                                    case 4:
                                        row[3+i] = "Event-triggered Status Message";
                                        break;
                                }
                                break;
                            case 2:
                                row[3 + i] = "Click to Expand";

                                break;
                            case 3:
                                row[3+i]=D03_TimeOfDate[0].ToString()+":"+D03_TimeOfDate[1].ToString() + ":"+D03_TimeOfDate[2].ToString() + ":"+D03_TimeOfDate[3].ToString();
                                break;
                            case 4:
                                //row[3+i]=
                                break;
                            case 5:
                                row[3 + i] = "R = " + D05_PolarCoor[0].ToString() + "m θ = " + D05_PolarCoor[1].ToString()+ "°";
                                break;
                            case 6:
                                row[3 + i] = "X = " + D06_CartCoor[0].ToString() + "m Y = " + D06_CartCoor[1].ToString() + "m";
                                break;
                            case 8:
                                row[2 + i] = "GS = " + D08_PolarSpeed[0].ToString() + "m/s θ = " + D08_PolarSpeed[1].ToString() + "°";
                                break;
                            case 9:
                                row[2 + i] = "Vx = " + D09_CartSpeed[0].ToString() + "m/s Vy = " + D09_CartSpeed[1].ToString()+"m/s";
                                break;
                            case 10:
                                row[2 + i] = D10_TrackNum.ToString() ;
                                break;
                            case 11://///////////////////////////////////////////////////Expand
                                row[2 + i] = "Click to Expand";
                                break;
                            case 12://///////////////////////////////////////////////////Expand
                                row[2 + i] = "Click to Expand";
                                break;
                            case 13:
                                row[2 + i] = D13_TargetAddress[0] .ToString()+ D13_TargetAddress[1] + D13_TargetAddress[2];
                                break;
                            case 14:
                                //No hay que hacer 
                                break;
                            case 16:
                                row[1 + i] = "BDS1: " + D16_Mode_S[0] + " BDS2: " + D16_Mode_S[1];
                                break;
                            case 17:
                                switch (D17_VFI)
                                {
                                    case 0:
                                        row[1 + i] = "Unknown";
                                        break;
                                    case 1:
                                        row[1 + i] = "ATC equipment maintenance";
                                        break;
                                    case 2:
                                        row[1 + i] = "Airport maintenance";
                                        break;
                                    case 3:
                                        row[1 + i] = "Fire";
                                        break;
                                    case 4:
                                        row[1 + i] = "Bird scarer";
                                        break;
                                    case 5:
                                        row[1 + i] = "Snow plough";
                                        break;
                                    case 6:
                                        row[1 + i] = "Runway sweeper";
                                        break;
                                    case 7:
                                        row[1 + i] = "Emergency";
                                        break;
                                    case 8:
                                        row[1 + i] = "Police";
                                        break;
                                    case 9:
                                        row[1 + i] = "Bus";
                                        break;
                                    case 10:
                                        row[1 + i] = "Tug (push/tow)";
                                        break;
                                    case 11:
                                        row[1 + i] = "Grass cutter";
                                        break;
                                    case 12:
                                        row[1 + i] = "Fuel";
                                        break;
                                    case 13:
                                        row[1 + i] = "Baggage";
                                        break;
                                    case 14:
                                        row[1 + i] = "Catering";
                                        break;
                                    case 15:
                                        row[1 + i] = "Aircraft maintenance";
                                        break;
                                    case 16:
                                        row[1 + i] = "Flyco (follow me)";
                                        break;
                                }

                                break;
                            case 18:
                                if (D18_FLBinary[0] == 0)
                                    row[1 + i] = "Code validated";
                                else row[1+i]= "Code not validated";
                                if (D18_FLBinary[1] == 0)
                                    row[1 + i] = row[1 + i]+ " - Code validated - " + D18_FLBinary[2];
                                else row[1 + i] = row[1 + i]+" - Garbled code - "+D18_FLBinary[2];
                                break;
                            case 19:
                                row[i + 1] = D19_MeasuredHeight.ToString();
                                break;
                            case 20:
                                row[i + 1] = "Size: " + D20_TargerSizeOrientation[0] + " Orientation: " + D20_TargerSizeOrientation[1] + " Width: " + D20_TargerSizeOrientation[2];
                                break;
                            case 21:////////////////////////////////////Expand
                                row[i + 1] = "Click to Expand";
                                break;
                            case 22:
                                row[1 + i] = D22_PreProgrammedMessage[0] == 0 ? "Default - " : "In Trouble - ";
                                switch (D22_PreProgrammedMessage[1])
                                {
                                    case 1:
                                        row[1 + i] = row[1 + i] + "Towing aircraft";
                                        break;
                                    case 2:
                                        row[1 + i] = row[1 + i] + "“Follow me” operation";
                                        break;
                                    case 3:
                                        row[1 + i] = row[1 + i] + "Runway check";
                                        break;
                                    case 4:
                                        row[1 + i] = row[1 + i] + "Emergency operation (fire, medical…)";
                                        break;
                                    case 5:
                                        row[1 + i] = row[1 + i] + "Work in progress (maintenance, birds scarer, sweepers…)";
                                        break;
                                }
                                break;
                            case 24:
                                row[i] = "σx = " + D24_StandardDeviationOfPosition[0] + " σy = " + D24_StandardDeviationOfPosition[1] + " σxy = " + D24_StandardDeviationOfPosition[2];
                                break;
                            case 25:
                                row[i] = "Rep = " + D25_Presence[0] + " DRHO = " + D25_Presence[1] + " DTHETA = " + D25_Presence[2];
                                break;
                            case 26:
                                row[i] = "Pam = " + D26_AmplitudeOfPrimaryPlot;
                                break;
                            case 27:
                                row[i] = "Ax = " + D27_CalculatedAcceleration[0] + " Ay = " + D27_CalculatedAcceleration[1];
                                break;
                        }
                    }
                }
            }
            else
            {
                row = null;
            }
            return row;
        }

        public string GetTargetDescriptor()
        {
            string row="";
            string nl = Environment.NewLine;

            switch (D02_TargetReportDescriptor[0])
            {
                case 0:
                    row = "SSR multilateration";
                    break;
                case 1:
                    row = "Mode S multilateration";
                    break;
                case 2:
                    row = "ADS-B";
                    break;
                case 3:
                    row = "PSR";
                    break;
                case 4:
                    row = "Magnetic Loop System";
                    break;
                case 5:
                    row = "HF multilateration";
                    break;
                case 6:
                    row = "Not defined";
                    break;
                case 7:
                    row = "Other types";
                    break;
            }



            if (D02_TargetReportDescriptor[1] == 0)
                row = row + nl+"No differential correction (ADS-B)";
            else
                row = row + nl+"Differential correction (ADS-B)";

            if (D02_TargetReportDescriptor[2] == 0)
                row = row + nl+"Chain 1";
            else
                row = row + nl+"Chain 2";

            if (D02_TargetReportDescriptor[3] == 0)
                row = row + nl+"Transponder Ground bit not set";
            else
                row = row + nl+"Transponder Ground bit set";

            if (D02_TargetReportDescriptor[4] == 0)
                row = row + nl+"No Corrupted reply in multilateration";
            else
                row = row + nl+"Corrupted replies in multilateration";

            if (D02_TargetReportDescriptor[5] == 0)
                row = row + nl+"Actual target report";
            else
                row = row + nl+"Simulated target report";

            if (D02_TargetReportDescriptor[6] == 0)
                row = row + nl+"Default";
            else
                row = row + nl+"Test Target";

            if (D02_TargetReportDescriptor[7] == 0)
                row = row + nl+"Report from target transponder";
            else
                row = row + nl+"Report from field monitor (fixed transponder)";

            switch (D02_TargetReportDescriptor[8])
            {
                case 0:
                    row = row+nl+"Undetermined";
                    break;
                case 1:
                    row = row+nl+"Loop start";
                    break;
                case 2:
                    row = row+nl+"Loop finish";
                    break;
            }
            switch (D02_TargetReportDescriptor[9])
            {
                case 0:
                    row = row + nl +"Undetermined";
                    break;
                case 1:
                    row = row + nl +"Aircraft";
                    break;
                case 2:
                    row = row + nl +"Ground vehicle";
                    break;
                case 3:
                    row = row + nl +"Helicopter";
                    break;
            }
            if (D02_TargetReportDescriptor[10] == 0)
                row = row + nl+"Absence of SPI";
            else
                row = row + nl+"Special Position Identification";
            return row;
        }
        public string GetTrackStatus()
        {
            string row = "";
            string nl = Environment.NewLine;

            if (D11_TrackStatus[0] == 0)
                row = row + "Confirmed track";
            else
                row = row + "Track in initialisation phase";

            if (D11_TrackStatus[1] == 0)
                row = row + nl + "Default";
            else
                row = row + nl + "Last report for a track";
            switch (D11_TrackStatus[2])
            {
                case 0:
                    row = row + nl + "No extrapolation";
                    break;
                case 1:
                    row = row + nl + "Predictable extrapolation due to sensor refresh period (see NOTE)";
                    break;
                case 2:
                    row = row + nl + "Predictable extrapolation in masked area";
                    break;
                case 3:
                    row = row + nl + "Extrapolation due to unpredictable absence of detection";
                    break;
            }

            if (D11_TrackStatus[3] == 0)
                row = row + nl + "Default";
            else
                row = row + nl + "Horizontal manoeuvre";

            if (D11_TrackStatus[4] == 0)
                row = row + nl + "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied.";
            else
                row = row + nl + "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates.";

            if (D11_TrackStatus[5] == 0)
                row = row + nl + "Measured position";
            else
                row = row + nl + "Smoothed position";

            switch (D11_TrackStatus[6])
            {
                case 0:
                    row = row + nl + "Unknown type of movement";
                    break;
                case 1:
                    row = row + nl + "Taking-off";
                    break;
                case 2:
                    row = row + nl + "Landing";
                    break;
                case 3:
                    row = row + nl + "Other types of movement";
                    break;
            }




            switch (D11_TrackStatus[7])
            {
                case 0:
                    row = row + nl + "No doubt";
                    break;
                case 1:
                    row = row + nl + "Doubtful correlation (undetermined reason)";
                    break;
                case 2:
                    row = row + nl + "Doubtful correlation in clutter";
                    break;
                case 3:
                    row = row + nl + "Loss of accuracy";
                    break;
                case 4:
                    row = row + nl + "Loss of accuracy in clutter";
                    break;
                case 5:
                    row = row + nl + "Unstable track";
                    break;
                case 6:
                    row = row + nl + "Previously coasted";
                    break;

            }
            switch (D11_TrackStatus[8])
            {
                case 0:
                    row = row + nl + "Merge or split indication undetermined";
                    break;
                case 1:
                    row = row + nl + "Track merged by association to plot";
                    break;
                case 2:
                    row = row + nl + "Track merged by non-association to plot";
                    break;
                case 3:
                    row = row + nl + "Split track";
                    break;
            }


            if (D11_TrackStatus[9] == 0)
                row = row + nl + "Default";
            else
                row = row + nl + "Ghost track";
            return row;
        }



    }
}
