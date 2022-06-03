using BlazorApp2.Data.Dtos;

namespace BlazorApp2.Services;
public interface IExhibitionItemsProvider
{
    Task<List<ExhibitionItemDto>> GetAll();
    Task<ExhibitionItemDto> GetById(int id);
    Task<bool> Add(ExhibitionItemDto item);
    Task<ExhibitionItemDto> Edit(ExhibitionItemDto item);
    Task<bool> Remove(int id);
    Task<List<ExhibitionItemDto>> GetWithOffset(int count, int offset);
}
