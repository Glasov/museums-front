namespace BlazorApp2.Data.Dtos
{
    public class ExhibitionItemDto
    {
        public int Id { get; set; }
        public int ExhibitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
