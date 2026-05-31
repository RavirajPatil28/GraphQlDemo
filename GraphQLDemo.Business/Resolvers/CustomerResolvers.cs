using GraphQLDemo.MockData.Data;
using GraphQLDemo.Data.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLDemo.Business.Resolvers
{
    [ExtendObjectType<Customer>]
    public class CustomerResolvers
    {
        public IEnumerable<Order> GetOrders([Parent] Customer customer)
        {
            return DemoData.Orders
                .Where(o => o.CustomerId == customer.Id);
        }
    }
}
