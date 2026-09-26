using Microsoft.Extensions.DependencyInjection;
using MinieCommerce.Core.Context;
using MinieCommerce.Core.Services.Implementation;
using MinieCommerce.Core.Services.Interfaces;

namespace MinieCommerce.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<CommerceDb>();

            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IPaymentService, PaymentService>();

            var provider = serviceCollection.BuildServiceProvider();


        }
    }
}
