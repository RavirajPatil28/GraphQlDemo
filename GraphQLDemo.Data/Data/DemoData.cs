using GraphQLDemo.Data.Models;

namespace GraphQLDemo.Data.Data
{
    public static class DemoData
    {
        public static List<Customer> Customers { get; } =
        [
            new Customer
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@test.com"
            },
            new Customer
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@test.com"
            },
            new Customer
            {
                Id = 3,
                Name = "Bob Wilson",
                Email = "bob.wilson@test.com"
        }
        ];

        public static List<Item> Items { get; } =
        [
            new Item
            {
                Id = 1,
                ItemCode = "LAPTOP001",
                Description = "Dell Laptop",
                Price = 55000
            },
            new Item
            {
                Id = 2,
                ItemCode = "MOUSE001",
                Description = "Wireless Mouse",
                Price = 1200
            },
            new Item
            {
                Id = 3,
                ItemCode = "KEYBOARD001",
                Description = "Mechanical Keyboard",
                Price = 3500
            },
            new Item
            {
                Id = 4,
                ItemCode = "MONITOR001",
                Description = "27 Inch Monitor",
                Price = 18000
            }
        ];

        public static List<Order> Orders { get; } =
        [
            new Order
            {
                Id = 1,
                OrderNumber = "ORD-1001",
                OrderDate = DateTime.UtcNow.AddDays(-5),
                CustomerId = 1
            },
            new Order
            {
                Id = 2,
                OrderNumber = "ORD-1002",
                OrderDate = DateTime.UtcNow.AddDays(-3),
                CustomerId = 1
            },
            new Order
            {
                Id = 3,
                OrderNumber = "ORD-1003",
                OrderDate = DateTime.UtcNow.AddDays(-1),
                CustomerId = 2
            }
        ];

        public static List<OrderItem> OrderItems { get; } =
        [
            new OrderItem
            {
                OrderId = 1,
                ItemId = 1,
                Quantity = 1
            },
            new OrderItem
            {
                OrderId = 1,
                ItemId = 2,
                Quantity = 2
            },
            new OrderItem
            {
                OrderId = 2,
                ItemId = 3,
                Quantity = 1
            },
            new OrderItem
            {
                OrderId = 3,
                ItemId = 1,
                Quantity = 1
            },
            new OrderItem
            {
                OrderId = 3,
                ItemId = 4,
                Quantity = 2
            }
        ];
    }
}
