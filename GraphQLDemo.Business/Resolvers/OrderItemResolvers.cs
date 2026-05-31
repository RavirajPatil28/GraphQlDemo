using GraphQLDemo.Business.DataLoaders;
using GraphQLDemo.Data.Data;
using GraphQLDemo.Data.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo.Business.Resolvers
{
    [ExtendObjectType<OrderItem>]
    public class OrderItemResolvers
    {
        /*
        public Item? GetItem([Parent] OrderItem orderItem)
        {
            return DemoData.Items
                .FirstOrDefault(i => i.Id == orderItem.ItemId);
        }

        public Order? GetOrder([Parent] OrderItem orderItem)
        {
            return DemoData.Orders
                .FirstOrDefault(o => o.Id == orderItem.OrderId);
        }
        */

        public async Task<Item?> GetItem([Parent] OrderItem orderItem, ItemDataLoader itemDataLoader, CancellationToken cancellationToken)
        {
            return await itemDataLoader.LoadAsync(
                orderItem.ItemId,
                cancellationToken);
        }

        public async Task<Order?> GetOrder([Parent] OrderItem orderItem, OrderDataLoader orderDataLoader, CancellationToken cancellationToken)
        {
            return await orderDataLoader.LoadAsync(
                orderItem.OrderId,
                cancellationToken);
        }
    }
}
