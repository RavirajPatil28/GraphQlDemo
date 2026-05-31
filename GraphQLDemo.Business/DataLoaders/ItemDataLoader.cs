using GraphQLDemo.Data.Data;
using GraphQLDemo.Data.Models;
using GreenDonut;

namespace GraphQLDemo.Business.DataLoaders
{
    public class ItemDataLoader : BatchDataLoader<int, Item>
    {
        public ItemDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
        }

        protected override Task<IReadOnlyDictionary<int, Item>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Loading items: DataLoader: {string.Join(",", keys)}");

            var items = DemoData.Items
                .Where(i => keys.Contains(i.Id))
                .ToDictionary(i => i.Id);

            return Task.FromResult<IReadOnlyDictionary<int, Item>>(items);
        }
    }
}
