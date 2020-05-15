using Futuristic.ViewModel;
using MobileApp1.APIService;
using MobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp1.ViewModel
{
   public class StoreListViewModel : BaseViewModel
    {
        public ObservableCollection<Store> stores { get; set; }
        public Command LoadItemsCommand { get; set; }
        private  StoreService _storeService;

        public StoreListViewModel()
        {
            stores = new ObservableCollection<Store>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
   
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var user = new User();
                _storeService = new StoreService();
                var userLocation = await user.CurrentLocation();
                var parameters = "latitude=" + userLocation.Latitude + "&longtitude=" + userLocation.Longitude + "&live=true";
                var asnycList = await _storeService.GetList(parameters);
                foreach (var item in asnycList)
                {
                    stores.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
