using MobileApp1.APIService;
using MobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp1.ViewModel
{
   public class StoreListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Store> stores { get; set; }
        private  StoreService _storeService;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public StoreListViewModel()
        {
            _storeService = new StoreService();
            var user = new User();
           
            Task.Run(async() =>
            {
                var userLocation= await user.CurrentLocation();
                PopulateStores("latitude="+userLocation.Latitude+ "&longtitude="+userLocation.Longitude+"&live=true");

            });
            var currentLocation = user.CurrentLocation();
        }
        void PopulateStores(string parameters = "")
        {
            Task.Run(async () =>
            {
               var alist = await _storeService.GetList(parameters);
                stores = new ObservableCollection<Store>();
                try
                {
                    stores = new ObservableCollection<Store>(alist);
                }
                catch (Exception ex)
                {
                    ex = ex;
                }
            });
    }
       
    }
}
