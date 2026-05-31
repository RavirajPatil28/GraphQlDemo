using GraphQLDemo.Business.DataLoaders;
using GraphQLDemo.Business.Resolvers;

namespace GraphQLDemo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<CustomerResolvers>()
                .AddTypeExtension<OrderResolvers>()
                .AddTypeExtension<OrderItemResolvers>()
                .AddTypeExtension<ItemResolvers>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();

            builder.Services.AddDataLoader<CustomerDataLoader>();
            builder.Services.AddDataLoader<ItemDataLoader>();
            builder.Services.AddDataLoader<OrderDataLoader>();

            /*
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            */

            var app = builder.Build();

            /*
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            */

            app.MapGraphQL();

            app.Run();
        }
    }
}
