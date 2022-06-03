namespace BlazorApp2.Data.Dtos
{
    public class MuseumDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] ExhibitionIds { get; set; }
    }
}
