using BlazorApp2.Data.Dtos;

namespace BlazorApp2.Services;
public interface IExhibitionsProvider
{
    Task<List<ExhibitionDto>> GetAll();
    Task<ExhibitionDto> GetById(int id);
    Task<bool> Add(ExhibitionDto item);
    Task<ExhibitionDto> Edit(ExhibitionDto item);
    Task<bool> Remove(int id);
}
