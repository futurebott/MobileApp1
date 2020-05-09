using MobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp1.APIService
{
   public class StoreService :BaseService<Store>
    {
        public StoreService():base("Store")
        {
        }
    }
}
