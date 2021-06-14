using System;

namespace ParksLookupApi.Models
{
  public class ParkDistance
  {
    public Park Park { get; set; }
    public decimal DistanceFromInMiles { get; set; }

    public ParkDistance(Park park)
    {
      this.Park = park;
      this.DistanceFromInMiles = 0M;
    }

    public ParkDistance(Park park, Location inputLocation)
    {
      this.Park = park;
      this.SetDistanceFromLocationInMiles(inputLocation);
    }

    public void SetDistanceFromLocationInMiles(Location location)
    {
      double radiusOfEarthInMiles = 3956;

      double parkLatitudeInRadians = ConvertAngleToRadians(this.Park.Latitude);
      double parkLongitudeInRadians = ConvertAngleToRadians(this.Park.Longitude);

      double locationLatitudeInRadians = ConvertAngleToRadians(location.Latitude);
      double locationLongitudeInRadians = ConvertAngleToRadians(location.Longitude);

      double differenceInLatitude = parkLatitudeInRadians - locationLatitudeInRadians;
      double differenceInLongitude = parkLongitudeInRadians - locationLongitudeInRadians;

      double haversine = Math.Pow(Math.Sin(differenceInLatitude / 2), 2) +
        Math.Cos(parkLatitudeInRadians) *
        Math.Cos(locationLatitudeInRadians) *
        Math.Pow(Math.Sin(differenceInLongitude / 2), 2);

      double distanceInMiles = 2 * radiusOfEarthInMiles * Math.Asin(Math.Sqrt(haversine));

      this.DistanceFromInMiles = (decimal)distanceInMiles;
    }

    private static double ConvertAngleToRadians(decimal angleInDegrees)
    {
      double angleInRadians = ((double)angleInDegrees * Math.PI) / 180;
      return angleInRadians;
    }


  }
}