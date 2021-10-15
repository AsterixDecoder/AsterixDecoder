using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace AsterixDecoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AsterixFile asterixfile= new AsterixFile("201002-lebl-080001_adsb.ast");
            List<CAT21> lista=asterixfile.getListCAT21();
            CAT21 cat21 = lista[39];
            //for (int i = 0; i < CAT21.Length; i++)
            //{
            //    Console.WriteLine(CAT21[i]);
            //}
            //Console.WriteLine(lista[0].GetCategory());
            byte[] fieldEspec = cat21.GetFieldEspec();
            int systemIC = cat21.GetSystemIdentificationCode();
            int systemAC = cat21.GetSystemAreaCode();
            Console.WriteLine("Longitud Field Espec: " + fieldEspec.Length);
            Console.WriteLine("SAC: " + systemAC);
            Console.WriteLine("SIC: " + systemIC);
            //for (int j = 0; j < CAT21.Length; j++)
            //{
            //    Console.WriteLine(CAT21[j]);
            //}


        }
    }
}
