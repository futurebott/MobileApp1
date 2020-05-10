using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;

namespace MobileApp1.Models
{
    public class LocationMonanager
    {

        public LocationMonanager()
        {

        }
        public async Task<Location> GetLocationCache()
        {
            Location location = new Location();
            try
            {
#if DEBUG
                location = new Location(43.842330, -79.074900);
#endif
                
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    return location;
                }
                else
                {
                    try
                    {
                        var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                        location = await Geolocation.GetLocationAsync(request);
                        if (location != null)
                        {
                            return location;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            catch
            {
                throw;
            }
            // if this is being thrown we are screwed
            return location;
        }

        public async Task<Location> GetLocationByAddress(string address)
        {
            var location = new Location();
            try
            {
                //TODO P:3 Code to Cach
                //before you get the location check if you have it cached
                var addressLocations = await Geocoding.GetLocationsAsync(address);
                location = addressLocations.FirstOrDefault();
            }
            catch
            {
                throw;
            }
            return location;
        }


    }
}
