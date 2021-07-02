using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ICM.Integration.Extensions
{
    public static class StartUpServiceManager
    {
        public static IServiceCollection Configurate(
           this IServiceCollection services,
           IConfiguration config)
           => services
                .Setting(config)
                .Mapping()
                .Service();

        private static IServiceCollection Service(this IServiceCollection services)
        {
            services.AddTransient<ICM.Taxes.Calculator.Abstractions.ITaxServices, ICM.Taxes.Calculator.TaxServices>();
            services.AddTransient<ICM.Taxes.Calculator.Abstractions.ITaxCalculatorService, ICM.WSI.TaxJar.Services.TaxJarCalculatorService>();
            services.AddTransient<ICM.Taxes.Calculator.Abstractions.IGeoServices, ICM.Taxes.Calculator.GeoServices>();
            services.AddTransient<ICM.WSI.TaxJar.Abstractions.IRateService, ICM.WSI.TaxJar.Services.RateService>();
            services.AddTransient<ICM.WSI.TaxJar.Abstractions.ITaxOrderService, ICM.WSI.TaxJar.Services.TaxOrderService>();
            services.AddTransient<ICM.Tools.WebTools.Abstractions.IHttpClientService, ICM.Tools.WebTools.HttpClientService>();
            services.AddTransient<ICM.Tools.WebTools.Abstractions.IHttpClientService, ICM.Tools.WebTools.HttpClientService>();
            return services;
        }

        private static IServiceCollection Setting(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ICM.WSI.TaxJar.ConfigTaxJar>(config.GetSection("WebApiConfig:TaxJarConfig"));
            var tJar = config.GetSection("WebApiConfig:TaxJarConfig").Get<ICM.WSI.TaxJar.ConfigTaxJar>();
            services.AddSingleton(tJar);
            return services;
        }

        private static IServiceCollection Mapping(this IServiceCollection services)
        {
            services.AddAutoMapper(
                System.Reflection.Assembly.GetExecutingAssembly(),
                System.Reflection.Assembly.Load("ICM.Taxes.Calculator"),
                System.Reflection.Assembly.Load("ICM.WSI.TaxJar"));
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Internacional Market Center",
                    Version = "v1",
                    Description = "Tax Calculator.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Mariannis Berovides"
                    },
                });
            });

            return services;
        }
    }
}
