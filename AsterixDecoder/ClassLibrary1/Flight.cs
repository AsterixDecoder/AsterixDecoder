using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Flight
    {
        string identification;
        List<Coordinates> coordinatesCAT21;
        List<TimeSpan> timestampsCAT21;
        List<Coordinates> coordinatesCAT10;
        List<TimeSpan> timestampsCAT10;
        public Flight(string id)
        {
            this.identification = id;
            coordinatesCAT21 = new List<Coordinates>();
            timestampsCAT21 = new List<TimeSpan>();
            coordinatesCAT10 = new List<Coordinates>();
            timestampsCAT10 = new List<TimeSpan>();
        }

    }
    public class Coordinates
    {
        double latitude;
        double longitude;

        public Coordinates(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double GetLatitude()
        {
            return this.latitude;
        }

        public double GetLongitude()
        {
            return this.longitude;
        }
    }
}
