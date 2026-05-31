using GraphQLDemo.Data.Data;
using GraphQLDemo.Data.InputTypes;
using GraphQLDemo.Data.Models;

namespace GraphQLDemo.Api
{
    public class Mutation
    {
        public Customer CreateCustomer(CreateCustomerInput input)
        {
            var customer = new Customer
            {
                Id = DemoData.Customers.Max(c => c.Id) + 1,
                Name = input.Name,
                Email = input.Email
            };

            DemoData.Customers.Add(customer);

            return customer;
        }

        public Item CreateItem(CreateItemInput input)
        {
            var item = new Item
            {
                Id = DemoData.Items.Max(x => x.Id) + 1,
                ItemCode = input.ItemCode,
                Description = input.Description,
                Price = input.Price
            };

            DemoData.Items.Add(item);

            return item;
        }

        public Order CreateOrder(CreateOrderInput input)
        {
            var customer = DemoData.Customers
                .FirstOrDefault(x => x.Id == input.CustomerId);

            if (customer is null)
            {
                throw new GraphQLException("Customer not found.");
            }

            var order = new Order
            {
                Id = DemoData.Orders.Max(x => x.Id) + 1,
                OrderNumber = input.OrderNumber,
                OrderDate = DateTime.UtcNow,
                CustomerId = input.CustomerId
            };

            DemoData.Orders.Add(order);

            return order;
        }

        public OrderItem AddItemToOrder(CreateOrderItemInput input)
        {
            var order = DemoData.Orders
                .FirstOrDefault(x => x.Id == input.OrderId);

            if (order is null)
            {
                throw new GraphQLException("Order not found.");
            }

            var item = DemoData.Items
                .FirstOrDefault(x => x.Id == input.ItemId);

            if (item is null)
            {
                throw new GraphQLException("Item not found.");
            }

            var orderItem = new OrderItem
            {
                OrderId = input.OrderId,
                ItemId = input.ItemId,
                Quantity = input.Quantity
            };

            DemoData.OrderItems.Add(orderItem);

            return orderItem;
        }
    }
}
