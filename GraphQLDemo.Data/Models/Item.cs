namespace GraphQLDemo.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string ItemCode { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
