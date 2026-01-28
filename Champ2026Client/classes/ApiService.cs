using Champ2026Client.ModelsDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Champ2026Client.classes
{
    internal class ApiService
    {
        private HttpClient _httpClient;
        private string baseUrl = "https://localhost:7039/api/";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<DisplayVmDTO>> GetDisplayVmAsync()
        {
            var response = await _httpClient.GetAsync("DisplayVm");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DisplayVmDTO>>(json);
        }
    }
}
