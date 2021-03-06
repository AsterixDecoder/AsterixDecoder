using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using ClassLibrary;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public class AsterixFile
    {
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        DataTable tablaCAT10 = new DataTable();
        DataTable tablaCAT21 = new DataTable();
        List<Flight> flights = new List<Flight>();

        public AsterixFile(string nombre,ProgressBar p)
        {
            leer(p,nombre);
        }

        public List<CAT10> getListCAT10()
        {
            return listaCAT10;
        }

        public List<CAT21> getListCAT21()
        {
            return listaCAT21;
        }

        public void leer(ProgressBar p, string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);
            List<byte[]> listabyte = new List<byte[]>();
            int i = 0;
            int contador = fileBytes[2];

            
            
            while (i < fileBytes.Length)
            {
                byte[] array = new byte[contador];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = fileBytes[i];
                    i++;
                }
                listabyte.Add(array);
                if (i + 2 < fileBytes.Length)
                {
                    contador = fileBytes[i + 2];
                }


            }
            p.Maximum = listabyte.Count;
            for (int q = 0; q < listabyte.Count; q++)
            {
                byte[] arraystring = listabyte[q];

                int CAT = arraystring[0];
                if (CAT == 10)
                {
                    CAT10 newcat10 = new CAT10(arraystring);
                    listaCAT10.Add(newcat10);
                }

                else if (CAT == 21)
                {
                    CAT21 newcat21 = new CAT21(arraystring);
                    listaCAT21.Add(newcat21);
                }
                p.PerformStep();
            }
            this.DecodeFlights(p);

        }

        public void DecodeFlights(ProgressBar p)
        {
            p.Value = 0;
            p.Maximum = listaCAT21.Count + listaCAT10.Count;
            for (int i = 0; i < listaCAT21.Count; i++)
            {
                p.PerformStep();
                CAT21 cat21 = listaCAT21[i];
                if (cat21.GetTargetIdentification() != "N/A")
                {
                    Flight foundFlight = flights.FirstOrDefault(flight => flight.GetIdentification() == cat21.GetTargetIdentification());
                    if (foundFlight != null)
                    {
                        Coordinates coordinates = new Coordinates(cat21.GetLatitudeWGS84(), cat21.GetLongitudeWGS84());
                        TimeSpan time = cat21.GetTime();
                        foundFlight.SetCoordinates(coordinates);
                        foundFlight.SetTimestamps(time);
                        foundFlight.SetHeading(Convert.ToDouble(cat21.GetAirborneVector()[1]));
                        foundFlight.SetSpeed(Convert.ToDouble(cat21.GetAirborneVector()[0]));
                    }
                    else
                    {
                        Flight newFlight = new Flight(cat21.GetTargetIdentification(),21,"ADSB");
                        Coordinates coordinates = new Coordinates(cat21.GetLatitudeWGS84(), cat21.GetLongitudeWGS84());
                        TimeSpan time = cat21.GetTime();
                        newFlight.SetCoordinates(coordinates);
                        newFlight.SetTimestamps(time);
                        newFlight.SetHeading(Convert.ToDouble(cat21.GetAirborneVector()[1]));
                        newFlight.SetSpeed(Convert.ToDouble(cat21.GetAirborneVector()[0]));
                        flights.Add(newFlight);
                    }
                }
            }
           for (int i = 0; i < listaCAT10.Count; i++)
            {
                p.PerformStep();
                CAT10 cat10 = listaCAT10[i];
                if (cat10.GetTrackNum() != "N/A"&& cat10.GetTrackNum() != "0")
                {
                    Flight foundFlight = flights.FirstOrDefault(flight => flight.GetIdentification() == cat10.GetTrackNum());
                    if (foundFlight != null)
                    {
                        Coordinates coordinates = new Coordinates(cat10.GetLatLong(cat10.GetSensor() == "MLAT" ? 1 : 0)[0], cat10.GetLatLong(cat10.GetSensor() == "MLAT" ? 1 : 0)[1]);
                        TimeSpan time = cat10.GetTime();
                        foundFlight.SetCoordinates(coordinates);
                        foundFlight.SetTimestamps(time);
                        foundFlight.SetHeading(cat10.GetHeading());
                        foundFlight.SetSpeed(cat10.GetSpeed());

                    }
                    else
                    {
                        Flight newFlight = new Flight(cat10.GetTrackNum(), 10,cat10.GetSensor());
                        Coordinates coordinates = new Coordinates(cat10.GetLatLong(cat10.GetSensor() == "MLAT" ? 1 : 0)[0], cat10.GetLatLong(cat10.GetSensor() == "MLAT" ? 1 : 0)[1]);
                        TimeSpan time = cat10.GetTime();
                        newFlight.SetCoordinates(coordinates);
                        newFlight.SetTimestamps(time);
                        newFlight.SetHeading(cat10.GetHeading());
                        newFlight.SetSpeed(cat10.GetSpeed());
                        flights.Add(newFlight);
                    }
                }
            }
            p.Visible = false;
        }


        public DataTable getTablaCAT10()
        {
            return tablaCAT10;
        }

        public DataTable getTablaCAT21()
        {
            return tablaCAT21;
        }

        public List<Flight> getFlights()
        {
            return flights;
        }
    }

}

