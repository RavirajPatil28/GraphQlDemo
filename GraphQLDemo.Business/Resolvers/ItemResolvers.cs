using GraphQLDemo.Business.DataLoaders;
using GraphQLDemo.MockData.Data;
using GraphQLDemo.Data.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo.Business.Resolvers
{
    [ExtendObjectType<Item>]
    public class ItemResolvers
    {
        public IEnumerable<OrderItem> GetOrderItems([Parent] Item item)
        {
            return DemoData.OrderItems
                .Where(oi => oi.ItemId == item.Id);
        }

    }
}
