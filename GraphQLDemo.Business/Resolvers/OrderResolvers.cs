using GraphQLDemo.Business.DataLoaders;
using GraphQLDemo.Data.Data;
using GraphQLDemo.Data.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo.Business.Resolvers
{
    [ExtendObjectType<Order>]
    public class OrderResolvers
    {
        //public Customer? GetCustomer(
        //    [Parent] Order order)
        //{
        //    Console.WriteLine($"Loading customer: Resolver: {order.CustomerId}");

        //    return DemoData.Customers
        //        .FirstOrDefault(c => c.Id == order.CustomerId);
        //}

        public IEnumerable<OrderItem> GetOrderItems(
            [Parent] Order order)
        {
            return DemoData.OrderItems
                .Where(oi => oi.OrderId == order.Id);
        }

        public async Task<Customer?> GetCustomer([Parent] Order order,CustomerDataLoader customerDataLoader, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Loading customer: Resolver: {order.CustomerId}");

            return await customerDataLoader.LoadAsync(
                order.CustomerId,
                cancellationToken);
        }
    }
}
