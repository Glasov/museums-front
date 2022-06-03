using System.Net.Http.Json;
using BlazorApp2.Data.Dtos;
using Newtonsoft.Json;

namespace BlazorApp2.Services
{
    public class ExhibitionItemProvider : IExhibitionItemsProvider
    {
        private HttpClient httpClient;

        public ExhibitionItemProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<ExhibitionItemDto>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<ExhibitionItemDto>>("/api/ExhibitionItems");
        }

        public async Task<ExhibitionItemDto> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<ExhibitionItemDto>($"/api/ExhibitionItems/{id}");
        }

        public async Task<bool> Add(ExhibitionItemDto item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await httpClient.PostAsync($"/api/ExhibitionItems", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<ExhibitionItemDto> Edit(ExhibitionItemDto item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await httpClient.PutAsync($"/api/ExhibitionItems", httpContent);
            ExhibitionItemDto author = JsonConvert.DeserializeObject<ExhibitionItemDto>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(author);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await httpClient.DeleteAsync($"/api/ExhibitionItems/${id}");
            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

        public async Task<List<ExhibitionItemDto>> GetWithOffset(int count, int offset)
        {
            return await httpClient.GetFromJsonAsync<List<ExhibitionItemDto>>($"/api/ExhibitionItems/next/{count}/{offset}");
        }
    }
}
