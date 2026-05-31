using GraphQLDemo.MockData.Data;
using GreenDonut;
using CustomerModel = GraphQLDemo.Data.Models.Customer;

namespace GraphQLDemo.Business.DataLoaders.Customer
{
    public class CustomerDataLoader : BatchDataLoader<int, CustomerModel>
    {
        public CustomerDataLoader(
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
        }

        protected override Task<IReadOnlyDictionary<int, CustomerModel>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Loading customers: DataLoader: {string.Join(",", keys)}");

            var customers = DemoData.Customers
                .Where(c => keys.Contains(c.Id))
                .ToDictionary(c => c.Id);

            return Task.FromResult<IReadOnlyDictionary<int, CustomerModel>>(customers);
        }
    }
}
