using ClassLibrary;
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
using System.Runtime.InteropServices;

namespace AsterixDecoder
{
    public partial class Menu : Form
    {

        AsterixFile asterixFile;
        List<CAT21> cat21;
        List<CAT10> cat10;
        string filename;
        List<Flight> listaflights = new List<Flight>();
        public Menu()
        {
            InitializeComponent();
        }
        public void SetFileName(string name)
        {
            this.filename = name;
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            //if (activeForm != null)
            //{
            //   activeForm.Close();
            //} 
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock=DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            

        }

        private void LoadFileButton_Click(object sender, EventArgs e)
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
                        this.filename = openFileDialog1.FileName;
                        filename = Path.GetFileName(filename);
                        progressBar1.Visible = true;
                        progressBar1.Minimum = 0;
                        progressBar1.Step = 1;
                        asterixFile = new AsterixFile(this.filename,progressBar1);

                        cat21 = asterixFile.getListCAT21();
                        cat10 = asterixFile.getListCAT10();
                        listaflights = asterixFile.getFlights();


                        //for (int i = 0; i < 1000; i++) // ojo que cuadre 1000 con el de Tabla10
                        //{
                        //    //Añado class flight para googleearth
                        //    Flight flight = new Flight(Convert.ToString(cat21[i].GetTargetIdentification()));//no se si i es el id cambialo porfa
                        //    Coordinates coordinates = new Coordinates(cat21[i].GetLatitudeWGS84(), cat21[i].GetLongitudeWGS84());
                        //    flight.SetcoordinatesCAT21(coordinates);
                        //    listaflights.Add(flight);
                        //}

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo leer el achivo del disco. Error original: " + ex.Message);
                }

            }
            //openChildForm(new LoadData());
        }

        //private void CAT10button_Click(object sender, EventArgs e)
        //{
        //    CAT10button.Enabled = false;
        //    openChildForm(new Tabla10(this.cat10));
            
        //    CAT10button.Enabled = true;
        //}

        //private void CAT21Button_Click(object sender, EventArgs e)
        //{
        //    CAT21Button.Enabled = false;
        //    openChildForm(new Tabla21(this.cat21));
        //    CAT21Button.Enabled = true;
        //    SubTablaMenu.Visible = true;
            
        //}

        private void MapViewButton_Click(object sender, EventArgs e)
        {
            MapViewButton.Enabled = false;
            openChildForm(new Map(listaflights));
            MapViewButton.Enabled=true;
        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinmimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panelName_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SubTablaMenu.Visible = false;
            openChildForm(new Tabla21(this.cat21));
        }

        private void SubTablaMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubTablaMenu.Visible = false;
            openChildForm(new Tabla10(cat10));
           

        }
    }
}
