namespace BlazorApp2.Data.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExhibitionId { get; set; }
        public double Cost { get; set; }
        public double Discount { get; set; }
        public long CreationTimestamp { get; set; }
    }
}
