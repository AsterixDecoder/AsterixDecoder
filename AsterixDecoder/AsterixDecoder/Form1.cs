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
            byte[] CAT21 = lista[0].GetArray();
            //for (int i = 0; i < CAT21.Length; i++)
            //{
            //    Console.WriteLine(CAT21[i]);
            //}
            //Console.WriteLine(lista[0].GetCategory());
            byte[] fieldEspec = lista[0].GetFieldEspec();
            Console.WriteLine("Longitud Field Espec: " + fieldEspec.Length);
            //for (int j = 0; j < CAT21.Length; j++)
            //{
            //    Console.WriteLine(CAT21[j]);
            //}


        }
    }
}
