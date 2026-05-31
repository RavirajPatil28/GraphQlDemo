using GraphQLDemo.MockData.Data;
using GreenDonut;
using ItemModel = GraphQLDemo.Data.Models.Item;

namespace GraphQLDemo.Business.DataLoaders.Item
{
    public class ItemDataLoader : BatchDataLoader<int, ItemModel>
    {
        public ItemDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
        }

        protected override Task<IReadOnlyDictionary<int, ItemModel>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Loading items: DataLoader: {string.Join(",", keys)}");

            var items = DemoData.Items
                .Where(i => keys.Contains(i.Id))
                .ToDictionary(i => i.Id);

            return Task.FromResult<IReadOnlyDictionary<int, ItemModel>>(items);
        }
    }
}
