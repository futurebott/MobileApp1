using MobileApp1.APIService;
using MobileApp1.Models;
using MobileApp1.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreList : ContentPage
    {
        public StoreList()
        {
            InitializeComponent();
            BindingContext = new StoreListViewModel();
        }
        
    }
}
