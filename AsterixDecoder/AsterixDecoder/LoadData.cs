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
    public partial class LoadData : Form
    {

        public static TextBox tb = new TextBox();
        Form1 GridForm = new Form1();
        AsterixFile asterixFile;
        List<CAT21> lista;

        public LoadData()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GridForm.Show();
            asterixFile = new AsterixFile("201002-lebl-080001_adsb.ast");
            lista = asterixFile.getListCAT21();
            int length = lista.Count;

        }
    }
}
