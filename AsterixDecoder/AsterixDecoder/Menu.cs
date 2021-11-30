﻿using ClassLibrary;
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

                        asterixFile = new AsterixFile(this.filename);
                        cat21 = asterixFile.getListCAT21();
                        for (int i = 0; i < 1000; i++) // ojo que cuadre 1000 con el de Tabla10
                        {
                            //Añado class flight para googleearth
                            Flight flight = new Flight(Convert.ToString(cat21[i].GetTargetIdentification()));//no se si i es el id cambialo porfa
                            Coordinates coordinates = new Coordinates(cat21[i].GetLatitudeWGS84(), cat21[i].GetLongitudeWGS84());
                            flight.SetcoordinatesCAT21(coordinates);
                            listaflights.Add(flight);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo leer el achivo del disco. Error original: " + ex.Message);
                }
            }
            //openChildForm(new LoadData());
        }

        private void CAT10button_Click(object sender, EventArgs e)
        {
            openChildForm(new Tabla10());
        }

        private void CAT21Button_Click(object sender, EventArgs e)
        {
            openChildForm(new Tabla21(this.cat21));
        }

        private void MapViewButton_Click(object sender, EventArgs e)
        {
            openChildForm(new Map(listaflights));
        }
    }
}