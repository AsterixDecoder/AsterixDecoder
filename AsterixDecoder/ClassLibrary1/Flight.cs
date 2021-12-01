using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Flight
    {
        string identification;
        int category;
        List<Coordinates> coordinates;
        List<TimeSpan> timestamps;

        public Flight(string id, int category)
        {
            this.category = category;
            this.identification = id;
            coordinates = new List<Coordinates>();
            timestamps = new List<TimeSpan>();
        }
        public string GetIdentification()
        {
            return this.identification;
        }
        public double GetLat()
        {
            Console.WriteLine("here coordinates");
            Console.WriteLine(coordinates[0]);
            return Convert.ToDouble(this.coordinates[0].GetLatitude());
        }
        public double GetLng()
        {
            return Convert.ToDouble(this.coordinates[0].GetLongitude());
        }
        public void SetCoordinates(Coordinates coord)
        {
            this.coordinates.Add(coord);
        }
        public void SetTimestamps(TimeSpan time)
        {
            this.timestamps.Add(time);

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
