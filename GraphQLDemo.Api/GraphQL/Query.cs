using GraphQLDemo.MockData.Data;
using GraphQLDemo.Data.Models;

namespace GraphQLDemo.Api.GraphQL
{
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Customer> GetCustomers()
        {
            return DemoData.Customers;
        }

        [UseFiltering]
        [UseSorting]
        public IEnumerable<Order> GetOrders()
        {
            return DemoData.Orders;
        }

        [UseFiltering]
        [UseSorting]
        public IEnumerable<Item> GetItems()
        {
            return DemoData.Items;
        }
    }
}
