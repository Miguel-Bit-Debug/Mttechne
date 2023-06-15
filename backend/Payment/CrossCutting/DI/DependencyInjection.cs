using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using InfraData.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Product.InfraData.Data;

namespace CrossCutting.DI;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors();
        builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();
        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
        builder.Services.AddScoped<IPaymentService, PaymentService>();
    }
}
