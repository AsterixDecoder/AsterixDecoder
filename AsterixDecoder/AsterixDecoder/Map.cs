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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace AsterixDecoder
{
    public partial class Map : Form
    {

        GMarkerGoogle marker;
        List<GMapOverlay> flightsMarkers= new List<GMapOverlay>();
        DataTable dt;
        List<Flight> flights = new List<Flight>();
        int rowSelected = 0;
        double InitialLat = 41.2959319;
        double InitialLong = 2.0798492;
        double lat;
        double lng;
        Bitmap original = new Bitmap(7,7);
        Bitmap cat10Bmp = new Bitmap(Properties.Resources.cat10, new Size(14, 14));
        Bitmap cat21Bmp = new Bitmap(Properties.Resources.cat21, new Size(14, 14));
        double[] Initialcoords = new double[2];
        int velocidad = 1;
        bool viewOld = true;
        int avance = 0;
//        Boolean seePrevius = true;

        public Map(List<Flight> listaflights)
        {
            InitializeComponent();
            Initialcoords[0] = 41.4706278;
            Initialcoords[1] = 2.18447222;
            this.flights = listaflights;
            for (int i = 0; i < flights.Count; i++)
            {
                flightsMarkers.Add(new GMapOverlay(flights[i].GetIdentification()));
                gMapControl1.Overlays.Add(flightsMarkers[i]);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void Map_Load(object sender, EventArgs e)
        {
            this.Show();

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Latitude", typeof(double)));
            dt.Columns.Add(new DataColumn("Longitude", typeof(double)));
            dt.Columns[0].Unique = true;
            var key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key ;
            
            //add point to the datatable
            //dt.Rows.Add("Ubication1:", InitialLat, InitialLong);
            dataGridView1.DataSource = dt;
            //desactivate colums lat long
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;


            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(InitialLat, InitialLong);
            gMapControl1.MinZoom = 4;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            cat21Bmp.MakeTransparent();
            cat10Bmp.MakeTransparent();



            //markerOverlay = new GMapOverlay("marker");

            //marker = new GMarkerGoogle(new PointLatLng(InitialLat, InitialLong), GMarkerGoogleType.green);
            //markerOverlay.Markers.Add(marker);//add mapp
            ////add tooltiptext to the marker
            //marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipText = string.Format("Ubication: \n Latitude:{0} \n Longitude:{1}", InitialLat, InitialLong);
            ////now add the map and the marquer to the controler

            //gMapControl1.Overlays.Add(markerOverlay);

        }

        private void SelectRegister(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //obtain the coordinates of the user click on the map
            lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            txtlatitude.Text = lat.ToString();
            txtlongitude.Text = lng.ToString();

            //change marker to the new position
            //marker.Position = new PointLatLng(lat, lng);
            //marker.ToolTipText = string.Format("Ubication:\n Latitude:{0} \n Longitude:{1}", lat, lng);



        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            //aqui debemos de hacer un for de todos los datos para añadir todsos los vuelos para cat10 antes se debe rotar
            dt.Rows.Add(txtdescription.Text, txtlatitude.Text, txtlongitude.Text);
        }

        private void btnEliminate_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(rowSelected);
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            GMapOverlay polygon = new GMapOverlay("Polygon");
            List<PointLatLng> puntos = new List<PointLatLng>();
            double lng, lat;
            for (int filas = 0; filas < 5; filas++) // dataGridView1.Rows.Count -1 ojo que le pomngo -1 porqeu el grid me añade un elemento en blanco
            {
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }


            GMapPolygon PuntosPoligono = new GMapPolygon(puntos, "Polygon");
            polygon.Polygons.Add(PuntosPoligono);
            gMapControl1.Overlays.Add(polygon);
            //Reset map
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;



        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            GMapOverlay route = new GMapOverlay("RouteLAyer");
            List<PointLatLng> puntos = new List<PointLatLng>();
            double lng, lat;
            for (int filas = 0; filas < dataGridView1.Rows.Count - 1; filas++)// ojo que le pongo -1 porqeu el grid me añade un elemento en blanco
            {
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));
            }


            GMapRoute PuntosRoute = new GMapRoute(puntos, "Route");
            route.Routes.Add(PuntosRoute);
            gMapControl1.Overlays.Add(route);
            //Reset map
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSat_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
        }

        private void btnRelieve_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleChinaTerrainMap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackZoom.Value = Convert.ToInt32(gMapControl1.Zoom);
        }


        private void trackZoom_ValueChanged(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackZoom.Value;
        }
        public void SetFlights(List<Flight> fligths)
        {
            this.flights = fligths;

        }



           /* 
                //marker.ToolTipMode = MarkerTooltipMode.Always;
                //marker.ToolTipText = string.Format("Ubication: \n Latitude:{0} \n Longitude:{1}", flightLat, flightLng);
                //now add the map and the marquer to the controler
            }
            gMapControl1.Overlays.Add(markerOverlay);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;


            for (int i = 1; i < 50; i++)
            {
                Flight flight = flights[i];
                double flightLat = flight.GetLat();
                double flightLng = flight.GetLng();
                //dt.Rows.Add(txtdescription.Text, txtlatitude.Text, txtlongitude.Text);
                //txtdescription.Text = flight.GetIdentification();
                dt.Rows.Add(flight.GetIdentification(), flightLat, flightLng);
            }
        } */

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelected = e.RowIndex;//selected row
            txtdescription.Text = dataGridView1.Rows[rowSelected].Cells[0].Value.ToString();
            txtlatitude.Text = dataGridView1.Rows[rowSelected].Cells[1].Value.ToString();
            txtlongitude.Text = dataGridView1.Rows[rowSelected].Cells[2].Value.ToString();
            //focus teh point in the screen
            gMapControl1.Position = new PointLatLng(Convert.ToDouble(txtlatitude.Text), Convert.ToDouble(txtlongitude.Text));
            for (int i = 0; i < gMapControl1.Overlays.Count; i++) {
                if (gMapControl1.Overlays[i].Id != txtdescription.Text)
                {
                    gMapControl1.Overlays[i].IsVisibile = false;
                }
                else
                {
                    gMapControl1.Overlays[i].IsVisibile = true;
                }
            }
        }

        private void pratbtn_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 14;
            gMapControl1.Position = new PointLatLng(InitialLat, InitialLong);
        }

        private void earthbtn_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 3;
            gMapControl1.Position = new PointLatLng(Initialcoords[0], Initialcoords[1]);
        }

        private void catabtn_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 8;
            gMapControl1.Position = new PointLatLng(Initialcoords[0], Initialcoords[1]);
        }

        private void spnbtn_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 5;
            gMapControl1.Position = new PointLatLng(Initialcoords[0], Initialcoords[1]);
        }
        private void sumarSegundos(int cont)
        {
            if (cont > 0)
            {
                if (Int32.Parse( segFin.Text)>=59)
                {
                    if (Int32.Parse(minFin.Text) >= 59)
                    {
                        horaFin.Text = (Int32.Parse(horaFin.Text) +1).ToString();
                        minFin.Text = "0";
                        segFin.Text = (Int32.Parse(segFin.Text) -60 + cont).ToString();
                    }
                    else
                    {
                        minFin.Text = (Int32.Parse(minFin.Text) + 1).ToString();
                        segFin.Text = (Int32.Parse(segFin.Text) - 60 + cont).ToString();

                    }
                }
                else
                    segFin.Text = (Int32.Parse(segFin.Text) + cont).ToString();
            }
            else
            {
                if (Int32.Parse(segFin.Text)-cont <= 0)
                {
                    if (Int32.Parse(minFin.Text) - cont <= 0)
                    {
                        horaFin.Text = (Int32.Parse(horaFin.Text) -1).ToString();
                        minFin.Text = "59";
                        segFin.Text = (Int32.Parse(segFin.Text) + 60 + cont).ToString(); 
                    }
                    else
                    {
                        minFin.Text = (Int32.Parse(minFin.Text) -1).ToString();
                        segFin.Text = (Int32.Parse(segFin.Text) + 60 + cont).ToString(); ;

                    }
                }
                else
                    segFin.Text = (Int32.Parse(segFin.Text) + cont).ToString();
            }
        }

        private void cargarVuelos(TimeSpan tiempoInicio,TimeSpan tiempoActual)
        {
            Flight flight;
            double flightLat=0;
            double flightLng=0;
            bool found=false;
            for (int i = 0; i < flights.Count; i++)
            {
                flight = flights[i];

                for (int j = 0; j < flight.GetCount(); j++)
                {

                    if (flight.GetTime(j).CompareTo(tiempoInicio) == 1 && flight.GetTime(j).CompareTo(tiempoActual) <= 0)
                    {
                        flightLat = flight.GetLat(j);
                        flightLng = flight.GetLng(j);
                        if (flight.GetCat() == 21)
                        {
                            marker = new GMarkerGoogle(new PointLatLng(flightLat, flightLng), cat21Bmp); // GMarkerGoogleType.green
                            flightsMarkers[i].Markers.Add(marker);
                        }
                        else
                        {
                            marker = new GMarkerGoogle(new PointLatLng(flightLat, flightLng), cat10Bmp);
                            flightsMarkers[i].Markers.Add(marker);

                        }

                        found = true;
                    }
                    
                }
                if (found && dt.Rows.Find(flight.GetIdentification())==null)
                {
                    dt.Rows.Add(flight.GetIdentification(), flightLat, flightLng);
                }
                else if(found)
                {
                    dt.Rows.Find(flight.GetIdentification()).SetField(1, flightLat);
                    dt.Rows.Find(flight.GetIdentification()).SetField(2, flightLng);

                }
                found = false;


            }

            


        }
        private void timeButton_Click(object sender, EventArgs e)
        {


            TimeSpan tiempoInicio = new TimeSpan(Int32.Parse(horaInicio.Text), Int32.Parse(minInicio.Text), Int32.Parse(segInicio.Text));
            TimeSpan tiempoActual = new TimeSpan(Int32.Parse(horaFin.Text), Int32.Parse(minFin.Text), Int32.Parse(segFin.Text));
            for (int i = 0; i < flightsMarkers.Count; i++) {
                flightsMarkers[i].Markers.Clear();
            }
            cargarVuelos(tiempoInicio,tiempoActual);

        }



        private void PlayPause_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
                timer2.Stop();
            else
                timer2.Start();
        }
        private void x1_Click(object sender, EventArgs e)
        {
            velocidad = 1;
        }
        private void x2_Click(object sender, EventArgs e)
        {
            velocidad = 2;
        }

        private void x3_Click(object sender, EventArgs e)
        {
            velocidad = 3;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (viewOld)
            {
                for (int i = 0; i < flightsMarkers.Count; i++)
                {
                    flightsMarkers[i].Markers.Clear();
                }
            }
            TimeSpan tiempoInicio = new TimeSpan(Int32.Parse(horaInicio.Text), Int32.Parse(minInicio.Text), Int32.Parse(segInicio.Text));
            TimeSpan tiempoActual = new TimeSpan(Int32.Parse(horaFin.Text), Int32.Parse(minFin.Text), Int32.Parse(segFin.Text));

            sumarSegundos(velocidad);
            TimeSpan tiempoActualNuevo = new TimeSpan(Int32.Parse(horaFin.Text), Int32.Parse(minFin.Text), Int32.Parse(segFin.Text));
            cargarVuelos(tiempoActual, tiempoActualNuevo);
        }

        private void SearchId_Click(object sender, EventArgs e)
        {
            var row =dt.Rows.Find(txtdescription.Text).ItemArray;

            txtlatitude.Text = row[1].ToString();
            txtlongitude.Text = row[2].ToString();
            //focus teh point in the screen
            gMapControl1.Position = new PointLatLng(Convert.ToDouble(txtlatitude.Text), Convert.ToDouble(txtlongitude.Text));
            for (int i = 0; i < gMapControl1.Overlays.Count; i++)
            {
                if (gMapControl1.Overlays[i].Id != txtdescription.Text)
                {
                    gMapControl1.Overlays[i].IsVisibile = false;
                }
                else
                {
                    gMapControl1.Overlays[i].IsVisibile = true;
                }
            }
        }

        private void viewAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gMapControl1.Overlays.Count; i++)
            {

                gMapControl1.Overlays[i].IsVisibile = true;
                
            }
        }


        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                if (checkBox1.Checked == true&&flights[i].GetSensor()=="SMR")
                    gMapControl1.Overlays[i].IsVisibile = true;
                else if(flights[i].GetSensor() == "SMR")
                    gMapControl1.Overlays[i].IsVisibile = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                if (checkBox2.Checked == true && flights[i].GetSensor() == "MLAT")
                    gMapControl1.Overlays[i].IsVisibile = true;
                else if (flights[i].GetSensor() == "MLAT")
                    gMapControl1.Overlays[i].IsVisibile = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                if (checkBox3.Checked == true && flights[i].GetSensor() == "ADSB")
                    gMapControl1.Overlays[i].IsVisibile = true;
                else if (flights[i].GetSensor() == "ADSB")
                    gMapControl1.Overlays[i].IsVisibile = false;
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            viewOld = !viewOld;
            if (!viewOld)
            {
                TimeSpan tiempoInicio = new TimeSpan(Int32.Parse(horaInicio.Text), Int32.Parse(minInicio.Text), Int32.Parse(segInicio.Text));
                TimeSpan tiempoActual = new TimeSpan(Int32.Parse(horaFin.Text), Int32.Parse(minFin.Text), Int32.Parse(segFin.Text));
                for (int i = 0; i < flightsMarkers.Count; i++)
                {
                    flightsMarkers[i].Markers.Clear();
                }
                cargarVuelos(tiempoInicio, tiempoActual);
            }


        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            sumarSegundos(trackBar2.Value - avance);
            if (avance != trackBar2.Value) { 
                avance = trackBar2.Value;
                TimeSpan tiempoInicio = new TimeSpan(Int32.Parse(horaInicio.Text), Int32.Parse(minInicio.Text), Int32.Parse(segInicio.Text));
                TimeSpan tiempoActual = new TimeSpan(Int32.Parse(horaFin.Text), Int32.Parse(minFin.Text), Int32.Parse(segFin.Text));
                for (int i = 0; i < flightsMarkers.Count; i++)
                {
                    flightsMarkers[i].Markers.Clear();
                }
                cargarVuelos(tiempoInicio, tiempoActual);
                //trackBar2.Value = 0;
            }
        }

    }
}