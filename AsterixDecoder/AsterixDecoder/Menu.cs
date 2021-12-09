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
        List<CAT21> cat21= new List<CAT21>();
        List<CAT10> cat10= new List<CAT10>();
        string filename;
        List<Flight> listaflights = new List<Flight>();
        int numFiles=0;
        List<string> filenames = new List<string>();
        public Menu()
        {
            InitializeComponent();
            label1.Text = "Welcome to Asterix Decoder by Group10!" + '\n' + '\n' + "This application allows to decode packets of categories 10 and 21" + '\n' + "and view them on a map with many useful options." + '\n' + '\n' + "To start just load an Asterix file, which can be one of the files included" + '\n' + "in the project. Then you can take a look at the information tables"+'\n'+"or go directly to the map view, to simulate the flight.";
            lblLoad.Text = "No Files Loaded";
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
            childForm.Show();
            childForm.BringToFront();


        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Se crean las opciones que comentaba
            openFileDialog1.InitialDirectory = "C:\\Users\\marcx\\Documents\\GitHub\\AsterixDecoder\\AsterixDecoder\\ClassLibrary";
            openFileDialog1.Filter = "Asterix Files (*.ast*)|*.ast";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            //el ShowDialog() muestra el explorador de archivos para que elijas tu archivo. 
            //Cuando le das click a "Aceptar" se devuelve DialogResult.OK 
            //y si das click a "Cancelar" se devuelve una DialogResult.Cancel
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                /*try
                {*/
                    //Si fue un OK, entonces suponemos que hay un archivo. Intentamos abrirlo
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        this.filename = openFileDialog1.FileName;
                        filename = Path.GetFileName(filename);
                        if (filenames.Count==0)
                        {
                        filenames.Add(filename);
                        progressBar1.BringToFront();
                        progressBar1.Visible = true;
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 0;
                        progressBar1.Step = 1;
                        asterixFile = new AsterixFile(this.filename, progressBar1);
                        numFiles++;
                        lblLoad.Text = "Files Loaded: " + filename;
                        cat21 = asterixFile.getListCAT21();
                        cat10 = asterixFile.getListCAT10();
                        listaflights = asterixFile.getFlights();
                        label3.Visible = true;
                        ClearAll.Visible = true;
                        ClearAll.Enabled = true;
                    }
                        else 
                        {
                        int found = 0;
                        for (int i = 0; i < filenames.Count; i++)
                        {
                            if (filenames[i] == filename)
                            {
                                found = found+1;
                            }
                            
                        }
                        if (found == 1)
                        {
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;
                            string message = "This file was already uploaded";
                            string caption = "Error";
                            result = MessageBox.Show(message, caption, buttons);
                        }
                        if (found==0)
                        {
                            filenames.Add(filename);
                            progressBar1.BringToFront();
                            progressBar1.Visible = true;
                            progressBar1.Minimum = 0;
                            progressBar1.Value = 0;
                            progressBar1.Step = 1;
                            asterixFile.leer(progressBar1, filename);
                            numFiles++;
                            lblLoad.Text = lblLoad.Text + '\n' + filename;
                            panelFiles.Size = new Size(543, 67);
                            cat21 = asterixFile.getListCAT21();
                            cat10 = asterixFile.getListCAT10();
                            listaflights = asterixFile.getFlights();
                        }

                        }
                        
                   
                    }

                /*}
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo leer el achivo del disco. Error original: " + ex.Message);
                }*/

            }
            //openChildForm(new LoadData());
        }
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


        private void SubTablaMenu_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnTable_Click(object sender, EventArgs e)
        {
            SubTablaMenu.Visible = true;
        }

        private void btnCAT10_Click(object sender, EventArgs e)
        {
            btnCAT10.Enabled = false;
            if (cat10.Count==0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                string message = "There are no packets of Cat 10";
                string caption = "Error";
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                progressBar1.BringToFront();
                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = cat10.Count;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                openChildForm(new Tabla10(cat10,progressBar1));
                progressBar1.Visible = false;
            }
            
            btnCAT10.Enabled = true;
            SubTablaMenu.Visible = true;

        }

        private void btnCAT21_Click(object sender, EventArgs e)
        {

            btnCAT21.Enabled = false;
            if (cat21.Count == 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                string message = "There are no packets of Cat 21";
                string caption = "Error";
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                progressBar1.BringToFront();
                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = cat21.Count;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                openChildForm(new Tabla21(this.cat21, progressBar1));
                progressBar1.Visible = false;
            }
            btnCAT21.Enabled = true;
            SubTablaMenu.Visible = true;
        }

        private void LoadFileButton_MouseHover(object sender, EventArgs e)
        {
            lblLoad.Visible = true;
            panelFiles.Visible = true;
            //Environment.NewLine
        }

        private void LoadFileButton_MouseLeave(object sender, EventArgs e)
        {
            lblLoad.Visible = false;
            panelFiles.Visible = false;
        }


        private void ClearAll_Click(object sender, EventArgs e)
        {
            this.cat21 = new List<CAT21>();
            this.cat10 = new List<CAT10>();
            this.listaflights = new List<Flight>();
            this.numFiles = 0;
            this.filenames = new List<string>();
            lblLoad.Text = "No Files Loaded";
            panelFiles.Size = new Size(543, 57);
            label3.Visible = false;
            ClearAll.Visible = false;
            ClearAll.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.cat21 = new List<CAT21>();
            this.cat10 = new List<CAT10>();
            this.listaflights = new List<Flight>();
            this.numFiles = 0;
            this.filenames = new List<string>();
            lblLoad.Text = "No Files Loaded";
            panelFiles.Size = new Size(543, 57);
            label3.Visible = false;
            ClearAll.Visible = false;
            ClearAll.Enabled = false;
        }
    }
}
