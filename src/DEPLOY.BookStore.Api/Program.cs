using DEPLOY.BookStore.Api.FilterType;
using DEPLOY.BookStore.Api.Swagger;
using DEPLOY.BookStore.Infra.CrossCutting;
using DEPLOY.BookStore.Infra.Database.Maps.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DEPLOY.BookStore.Api
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        protected Program() { }
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddControllers(config =>
                {
                    config.Filters.Add<ExceptionFilter>();
                    config.RequireHttpsPermanent = true;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.AllowTrailingCommas = false;
                });

            builder.Services
                .AddRouting(opt =>
                {
                    opt.LowercaseUrls = true;
                    opt.LowercaseQueryStrings = true;
                });

            builder.Services.AddSwaggerExtension();
            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddRegisterDependencyInjections();

            SetupMap.ConfigureMaps();



            var app = builder.Build();

            app.UseSwaggerExtension();

            //app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapControllers();

            await app.RunAsync();
        }
    }
}