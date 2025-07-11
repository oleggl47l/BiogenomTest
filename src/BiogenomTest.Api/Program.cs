using System.Text.Json.Serialization;
using BiogenomTest.Application.Extensions;
using BiogenomTest.Infrastructure.Extensions;

namespace BiogenomTest.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDatabase(configuration);
        builder.Services.AddSwaggerGen();
        builder.Services.AddApplication();
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
        // app.UseExceptionHandler();
        
        app.Run();
    }
}