namespace GraphQLDemo.Data.InputTypes
{
    public class CreateOrderInput
    {
        public string OrderNumber { get; set; } = string.Empty;

        public int CustomerId { get; set; }
    }
}
