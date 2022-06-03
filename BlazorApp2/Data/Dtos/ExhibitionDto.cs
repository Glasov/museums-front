namespace BlazorApp2.Data.Dtos
{
    public class ExhibitionDto
    {
        public int Id { get; set; }
        public MuseumDto Museum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long StartTimestamp { get; set; }
        public long EndTimestamp { get; set; }
        public double Cost { get; set; }
        public int[] ExhibitionItemIds { get; set; }
        public int[] OrderIds { get; set; }
    }
}
