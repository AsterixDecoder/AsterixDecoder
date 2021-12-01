using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using ClassLibrary;

namespace AsterixDecoder
{
    public class AsterixFile
    {
        string path;
        List<CAT10> listaCAT10 = new List<CAT10>();
        //List<CAT20> listaCAT20 = new List<CAT20>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        DataTable tablaCAT10 = new DataTable();
        DataTable tablaCAT21 = new DataTable();
        List<Flight> flights = new List<Flight>();

        public AsterixFile(string nombre)
        {
            this.path = nombre;
            Console.WriteLine("Hello World");
            leer();
        }

        public List<CAT10> getListCAT10()
        {
            return listaCAT10;
        }
        //public List<CAT20> getListCAT20()
        //{
        //    return listaCAT20;
        //}
        public List<CAT21> getListCAT21()
        {
            return listaCAT21;
        }

        public void leer()
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

            }
            this.DecodeFlights();

        }

        public void DecodeFlights()
        {
            for (int i = 0; i < listaCAT21.Count; i++)
            {
                CAT21 cat21 = listaCAT21[i];
                if (cat21.GetTargetIdentification() != "N/A")
                {
                    Flight foundFlight = flights.FirstOrDefault(flight => flight.GetIdentification() == cat21.GetTargetIdentification());
                    if (foundFlight != null)
                    {
                        Coordinates coordinates = new Coordinates(cat21.GetLatitudeWGS84(), cat21.GetLongitudeWGS84());
                        foundFlight.SetcoordinatesCAT21(coordinates);
                    }
                    else
                    {
                        Flight newFlight = new Flight(cat21.GetTargetIdentification(),21);
                        Coordinates coordinates = new Coordinates(cat21.GetLatitudeWGS84(), cat21.GetLongitudeWGS84());
                        newFlight.SetcoordinatesCAT21(coordinates);
                        flights.Add(newFlight);
                    }
                }
            }
           for (int i = 0; i < listaCAT10.Count; i++)
            {
                CAT10 cat10 = listaCAT10[i];
                if (cat10.GetTrackNum() != "N/A")
                {
                    Flight foundFlight = flights.FirstOrDefault(flight => flight.GetIdentification() == cat10.GetTrackNum());
                    if (foundFlight != null)
                    {
                        Coordinates coordinates = new Coordinates(cat10.GetLatLong(0)[0], cat10.GetLatLong(0)[1]);
                        foundFlight.SetcoordinatesCAT21(coordinates);
                    }
                    else
                    {
                        Flight newFlight = new Flight(cat10.GetTrackNum(), 21);
                        Coordinates coordinates = new Coordinates(cat10.GetLatLong(0)[0], cat10.GetLatLong(0)[1]);
                        newFlight.SetcoordinatesCAT21(coordinates);
                        flights.Add(newFlight);
                    }
                }
            }
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

