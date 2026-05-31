using GraphQLDemo.MockData.Data;
using GreenDonut;
using OrderModel = GraphQLDemo.Data.Models.Order;

namespace GraphQLDemo.Business.DataLoaders.Order
{
    public class OrderDataLoader : BatchDataLoader<int, OrderModel>
    {
        public OrderDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
        }

        protected override Task<IReadOnlyDictionary<int, OrderModel>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Loading orders: DataLoader: {string.Join(",", keys)}");

            var orders = DemoData.Orders
                .Where(o => keys.Contains(o.Id))
                .ToDictionary(o => o.Id);

            return Task.FromResult<IReadOnlyDictionary<int, OrderModel>>(orders);
        }
    }
}
