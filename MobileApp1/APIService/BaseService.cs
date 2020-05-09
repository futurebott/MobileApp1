using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp1.APIService
{
   public class BaseService<T>
    {
        HttpClient _client;
        const string _ListMethod = "GetList";
        const string _AddUpdateMethod = "AddUpdate";
        const string APIBaseUrl = "https://localhost:44338/api/";//"https://futuristicapi20200429024818.azurewebsites.net/api/";
        public BaseService(string apiPath)
        {
            _client = new HttpClient();
        }
        public BaseService()
        {
            
        }
        public async Task<List<T>> GetList(string filter = "")
        {
            List<T> list = new List<T>();
            var uri = new Uri(string.Format(APIBaseUrl+_ListMethod));
            if (string.IsNullOrWhiteSpace(filter))
                filter +="?";

            var response = await _client.GetAsync(uri + _ListMethod + filter);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return list;
        }
        public async Task<List<T>> AddUpdateEntity()
        {
            List<T> list = new List<T>();
            var uri = new Uri(string.Format(APIBaseUrl + "StoreList"));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return list;
        }
        public async Task<List<T>> DeleteEntity()
        {
            List<T> list = new List<T>();
            var uri = new Uri(string.Format(APIBaseUrl + "StoreList"));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return list;
        }
    }
}
