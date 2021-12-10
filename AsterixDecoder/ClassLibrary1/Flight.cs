using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Flight
    {
        string identification;
        int category;
        string sensor;
        List<double> speed;
        List<double> heading;
        List<Coordinates> coordinates;
        List<TimeSpan> timestamps;

        public Flight(string id, int category,string sensor)
        {
            this.sensor = sensor;
            this.category = category;
            this.identification = id;
            coordinates = new List<Coordinates>();
            timestamps = new List<TimeSpan>();
            heading = new List<double>();
            speed = new List<double>();
        }
        public string GetIdentification()
        {
            return this.identification;
        }
        public TimeSpan GetTime(int i)
        {
            return timestamps[i];
        }

        public int GetCount()
        {
            return coordinates.Count;
        }
        public string GetSensor()
        {
            return this.sensor;
        }
        public double GetLat(int i)
        {
            return Convert.ToDouble(this.coordinates[i].GetLatitude());
        }
        public double GetLng(int i)
        {
            return Convert.ToDouble(this.coordinates[i].GetLongitude());
        }
        public void SetCoordinates(Coordinates coord)
        {
            this.coordinates.Add(coord);
        }
        public void SetTimestamps(TimeSpan time)
        {
            this.timestamps.Add(time);

        }
        public void SetHeading(double heading)
        {
            this.heading.Add(heading);

        }
        public void SetSpeed(double speed)
        {
            this.speed.Add(speed);

        }
        public int GetCat()
        {
            return this.category;
        }
        public double GetHeading(int i)
        {
            try { return this.heading[i]; }catch(ArgumentOutOfRangeException e) { return 0; }
        }
        public double GetSpeed(int i)
        {
            try { return this.speed[i]; } catch (ArgumentOutOfRangeException e) { return 0; }
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
