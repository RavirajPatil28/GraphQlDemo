using GraphQLDemo.Data.Data;
using GraphQLDemo.Data.Models;
using GreenDonut;

namespace GraphQLDemo.Business.DataLoaders
{
    public class CustomerDataLoader : BatchDataLoader<int, Customer>
    {
        public CustomerDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
        }

        protected override Task<IReadOnlyDictionary<int, Customer>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Loading customers: DataLoader: {string.Join(",", keys)}");

            var customers = DemoData.Customers
                .Where(c => keys.Contains(c.Id))
                .ToDictionary(c => c.Id);

            return Task.FromResult<IReadOnlyDictionary<int, Customer>>(customers);
        }
    }
}
