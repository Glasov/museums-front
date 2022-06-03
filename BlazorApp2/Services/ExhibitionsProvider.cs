using System.Net.Http.Json;
using BlazorApp2.Data.Dtos;
using Newtonsoft.Json;

namespace BlazorApp2.Services
{
    public class ExhibitionsProvider : IExhibitionsProvider
    {
        private HttpClient httpClient;

        public ExhibitionsProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<ExhibitionDto>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<ExhibitionDto>>("/api/Exhibition");
        }

        public async Task<ExhibitionDto> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<ExhibitionDto>($"/api/Exhibition/{id}");
        }

        public async Task<bool> Add(ExhibitionDto item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await httpClient.PostAsync($"/api/Exhibition", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<ExhibitionDto> Edit(ExhibitionDto item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var respons = await httpClient.PutAsync($"/api/Exhibition", httpContent);
            ExhibitionDto exhibition = JsonConvert.DeserializeObject<ExhibitionDto>(respons.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(exhibition);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await httpClient.DeleteAsync($"/api/Exhibition/${id}");
            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
