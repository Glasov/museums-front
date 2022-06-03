using BlazorApp2.Data.Dtos;

namespace BlazorApp2.Services;
public interface IOrdersProvider
{
    Task<OrderDto?> GetById(int id);
    Task<OrderDto?> Add(OrderCreationDto item);
    Task<OrderDto?> Edit(OrderUpdateDto item);
    Task<bool> Remove(int id);
}
