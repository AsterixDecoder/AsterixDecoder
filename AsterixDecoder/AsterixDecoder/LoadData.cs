using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        //Tabla21 GridForm = new Tabla21();
        AsterixFile asterixFile;
        List<CAT21> lista;
        string name;

        public LoadData()
        {
            InitializeComponent();
           
        }
        public string SendFileName()
        {
            return name;
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Se crean las opciones que comentaba
            openFileDialog1.InitialDirectory = "C:\\Users\\marcx\\Documents\\GitHub\\AsterixDecoder\\AsterixDecoder\\ClassLibrary";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.ast";
            openFileDialog1.FilterIndex = 4;
            openFileDialog1.RestoreDirectory = true;

            //el ShowDialog() muestra el explorador de archivos para que elijas tu archivo. 
            //Cuando le das click a "Aceptar" se devuelve DialogResult.OK 
            //y si das click a "Cancelar" se devuelve una DialogResult.Cancel
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Si fue un OK, entonces suponemos que hay un archivo. Intentamos abrirlo
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        this.name = openFileDialog1.FileName;

                        name = Path.GetFileName(name);
                        //GridForm.SetFileName(name);
                        //this.Hide();
                        //GridForm.Show();


                        //Console.WriteLine(name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo leer el achivo del disco. Error original: " + ex.Message);
                }
            }
        }
    }
}
