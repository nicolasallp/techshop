using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using techshop.Models.Entities;

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

        public static async Task<T?> GetDataById<T>(string url, int id)
        {
            HttpResponseMessage response = await HttpClient.GetAsync($"{url}/{id}");
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public static async Task PostData(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await HttpClient.PostAsync(url, content);
        }

        public static async Task DeleteData(string url, int id)
        {
            await HttpClient.DeleteAsync($"{url}/{id}");
        }
    }
}
