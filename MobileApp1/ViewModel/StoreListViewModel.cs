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
            PopulateStores();
        }
        void PopulateStores()
        {
            List<Store> list;
            Task.Run(async () =>
            {
                string parameters = "";
               list = await _storeService.GetList(parameters);
               stores = new ObservableCollection<Store>(list);
            });
    }
       
    }
}
