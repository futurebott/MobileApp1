using MobileApp1.Models;
using MobileApp1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new StoreListViewModel();
           
            //TODO -Now-
            //TOD - global Start backgroud tasks on separate thread
            //3 - Load check if we all the images
            //2- Any available updates
            //1 - Initialize user session
        }
       

        #region testing code
        //        public async void btnGetLocationAsync(object sender, EventArgs e)
        //        {
        //            try
        //            {
        //                var locationManager = new LocationMonanager();
        //#if DEBUG
        //                var currentLocation = new Location(43.842330, -79.074900);
        //#else
        //                 var currentLocation = await locationManager.GetLocationCache();
        //#endif

        //                if (currentLocation.IsFromMockProvider)
        //                {
        //                    Console.WriteLine("This is a mock location");
        //                }
        //                var address = editor.Text;
        //                var addressLocation = await locationManager.GetLocationByAddress(address);
        //                double miles = Location.CalculateDistance(currentLocation, addressLocation, DistanceUnits.Kilometers);
        //                Distance.Text = miles + "Miles";
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message); 
        //            }
        //        }


        //        public async void btnAddAsync(object sender, EventArgs e)
        //        {
        //            await Navigation.PushAsync(new AddFeedBack());
        //        }

        //        public async void btnCheckAsync(object sender, EventArgs e)
        //        {
        //            await Navigation.PushAsync(new Check());
        //        }
        #endregion
    }
}
