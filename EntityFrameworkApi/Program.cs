
using EntityFrameworkApi.Data;
using EntityFrameworkApi.Interfaces;
using EntityFrameworkApi.Repositories;
using EntityFrameworkApi.Service;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<TripContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TripsDB")));
        
        builder.Services.AddScoped<ITripRepository, TripRepository>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();

        builder.Services.AddScoped<ITripService, TripService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers().AddXmlSerializerFormatters();
        
        var app = builder.Build();

        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}