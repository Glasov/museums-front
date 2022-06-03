using BlazorApp2.Data.Dtos;
using Newtonsoft.Json;

namespace BlazorApp2.Services
{
    public class OrdersProvider : IOrdersProvider
    {
        private HttpClient httpClient;

        public OrdersProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<OrderDto?> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<OrderDto>($"/api/Orders/{id}");
        }

        public async Task<OrderDto?> Add(OrderCreationDto item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"/api/Orders", httpContent);
            OrderDto? orderDto = JsonConvert.DeserializeObject<OrderDto>(response.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(orderDto);
        }

        public async Task<OrderDto> Edit(OrderUpdateDto item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"/api/Orders", httpContent);
            OrderDto? orderDto = JsonConvert.DeserializeObject<OrderDto>(response.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(orderDto);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await httpClient.DeleteAsync($"/api/Orders/${id}");
            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
