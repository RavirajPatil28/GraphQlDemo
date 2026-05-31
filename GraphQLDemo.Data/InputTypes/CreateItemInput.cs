namespace GraphQLDemo.Data.InputTypes
{
    public class CreateItemInput
    {
        public string ItemCode { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
