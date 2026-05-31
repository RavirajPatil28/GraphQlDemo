using GraphQLDemo.Data.Data;
using GraphQLDemo.Data.Models;
using GreenDonut;

namespace GraphQLDemo.Business.DataLoaders
{
    public class OrderDataLoader : BatchDataLoader<int, Order>
    {
        public OrderDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
        }

        protected override Task<IReadOnlyDictionary<int, Order>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Loading orders: DataLoader: {string.Join(",", keys)}");

            var orders = DemoData.Orders
                .Where(o => keys.Contains(o.Id))
                .ToDictionary(o => o.Id);

            return Task.FromResult<IReadOnlyDictionary<int, Order>>(orders);
        }
    }
}
