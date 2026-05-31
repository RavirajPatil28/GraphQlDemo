namespace GraphQLDemo.Data.InputTypes
{
    public class CreateOrderItemInput
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
