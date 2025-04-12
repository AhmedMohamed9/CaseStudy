using Core.Interfaces;
using Infra.Data;
using Infra.Repositories;
using Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("DefaultConnection")
				));
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IOrderStatusHistoryRepository, OrderStatusHistoryRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<CustomerService, CustomerService>();
			services.AddScoped<OrderService, OrderService>();
			services.AddScoped<ProductService, ProductService>();

			return services;
		}
	}
}
