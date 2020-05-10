using Android.Locations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileApp1.Models
{
    //TODO make this singletion

    public class User
    {
        public Guid ApplicationId { get; set; }
        public double CurrentLat { get; set; }
        public double CurrentLong { get; set; }
        public DateTime TimeStamp { get; set;}
        public  TimeZoneInfo CurrentTimeZone { get; set; }
        public string Name { get; set; }
        public int LocationRefreshIntervalinMinutes { get; set; }
        public User()
        {
            CurrentLat = 0;
            CurrentLong = 0;
            TimeStamp = DateTime.Now;
        }
        public async Task<Xamarin.Essentials.Location> CurrentLocation()
        {
            var currentLocation = new Xamarin.Essentials.Location();
            try
            {
                var locationManager = new LocationMonanager();
                currentLocation = await locationManager.GetLocationCache();
                return currentLocation;
            }
            catch 
            {
                throw;
            }
           
        }
        // other information available in from the store


        //#if DEBUG
        //                var currentLocation = new Location(43.842330, -79.074900);
        //#else
        //                 var currentLocation = await locationManager.GetLocationCache();
        //#endif
    }
}
