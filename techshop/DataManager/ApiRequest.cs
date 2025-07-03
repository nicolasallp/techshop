using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using techshop.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace techshop.DataManager
{
    public class ApiRequest
    {
        static HttpClient HttpClient = new();

        public static async Task<List<T>?> GetData<T>(string url)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(responseData);
        }

        public static async Task<List<T>?> GetData<T>(string url, string? userId)
        {
            HttpResponseMessage response = await HttpClient.GetAsync($"{url}/ByUser/{userId}");
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(responseData);
        }

        public static async Task<T?> GetDataById<T>(string url, string? id)
        {
            HttpResponseMessage response = await HttpClient.GetAsync($"{url}/{id}");
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public static async Task CreateData(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await HttpClient.PostAsync(url, content);
        }

        public static async Task UpdateData(string url, string id, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await HttpClient.PutAsync($"{url}/{id}", content);
        }

        public static async Task DeleteData(string url, string id)
        {
            await HttpClient.DeleteAsync($"{url}/{id}");
        }
    }
}
